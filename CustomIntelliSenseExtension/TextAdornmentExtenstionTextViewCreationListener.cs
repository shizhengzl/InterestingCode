﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using Core.UsuallyCommon;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;
using System.Xml.XPath;
using System.Xml.Linq;
using VSBussinessExtenstion;
using Microsoft.VisualStudio.Shell;
using EnvDTE80;
using EnvDTE;

namespace CustomIntelliSenseExtension
{
    [Export(typeof(ICompletionSourceProvider))]  
 
    [ContentType("text")] 
    [Name("UeqtDynamicCompletion")]
    internal class UeqtDynamicCompletionSourceProvider : ICompletionSourceProvider
    {
        public ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer)
        {
            return new UeqtDynamicCompletionSource(this, textBuffer);
        }
        [Import]
        internal ITextStructureNavigatorSelectorService NavigatorService { get; set; }
        [Import]
        internal IGlyphService GlyphService { get; set; }

     

    }

    public class ListChar
    {
        public static List<string> chars = new List<string>();

        public static List<Intellisence> listsnippet = new List<Intellisence>();

        public DefaultSqlite defaultSqlite = new DefaultSqlite();

        public void InitDatabaseConfig()
        {
            IsInit = true;
            ListChar.listsnippet =   defaultSqlite.Intellisences.ToList();
            ListChar.chars = ListChar.listsnippet.Select(x => x.StartChar).ToList<string>().Distinct().ToList();
        }

        public static bool IsInit = false;
    }

    internal class UeqtDynamicCompletionSource : ICompletionSource
    {
        public DefaultSqlite defaultSqlite = new DefaultSqlite();

        public ITextBuffer m_textBuffer { get; set; }
        UeqtDynamicCompletionSourceProvider m_sourceProvider { get; set; }



        public UeqtDynamicCompletionSource(UeqtDynamicCompletionSourceProvider t, ITextBuffer tb)
        {
            m_textBuffer = tb;
            m_sourceProvider = t;
            new ListChar().InitDatabaseConfig();
        }


        void ICompletionSource.AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            if (completionSets.Count != 0)
                return;
            ThreadHelper.ThrowIfNotOnUIThread();
            DTE2 dte = (DTE2)ServiceProvider.GetGlobalServiceAsync(typeof(DTE)).Result;
            var filename = dte.ActiveDocument.Name.Replace(".cs", string.Empty).Replace("Entity", string.Empty) ;
            string inputtext = session.TextView.Caret.Position.BufferPosition.GetContainingLine().GetText();
            var alltext = m_textBuffer.CurrentSnapshot.GetText();
            var inputlist = Core.UsuallyCommon.StringHelper.GetStringSingleColumn(inputtext);

            foreach (var item in ListChar.chars)
            {

                var starttext = inputlist.FirstOrDefault(x => x.IndexOf(item) > 0);
                var replacechar = starttext;
                if (string.IsNullOrEmpty(starttext))
                    continue;

                string lastChar = starttext.Substring(starttext.Length - 1, 1);
                starttext = starttext.Replace(lastChar, "").Trim();


                if (lastChar == item.ToString())
                {
                    var mCompList = new List<Completion>();
                    try
                    {
                        List<Intellisence> list = new List<Intellisence>();
                        list.AddRange(ListChar.listsnippet.Where(x => x.StartChar == item
                        && string.IsNullOrEmpty(x.DefinedSql)
                        && (  item == "^"  || StringHelper.SearchWordExists(starttext, new string[] { x.DisplayText }))
                        ));

                      

                        var sqllist = ListChar.listsnippet.Where(x => x.StartChar == item && !string.IsNullOrEmpty(x.DefinedSql));
                        
                        foreach (var sql in sqllist)
                        {
                            var sqls = sql.DefinedSql.Replace("@REPLACENAME", starttext);
                            if (m_textBuffer.ContentType.ToString().ToLower().Equals("xml"))
                            { 
                                sqls = BatchContext(alltext.Replace(replacechar, string.Empty), sqls);
                                sqls = BatchCurrentLineContext(inputtext.Replace(replacechar, string.Empty), sqls);

                            }
                            defaultSqlite.Database.Connection.ConnectionString = sql.ConnectionString; 
                            list.AddRange(defaultSqlite.Database.SqlQuery< Intellisence>(sqls).ToList<Intellisence>());
                            defaultSqlite.Database.Connection.ConnectionString = DefaultSqlite.DefaultSqltiteConnection;
                            list = list.Where(x => StringHelper.SearchWordExists(starttext, new string[] { x.DisplayText })
                                           ||    StringHelper.SearchWordExists(starttext, new string[] { x.Description })
                            ).ToList();
                        }
                       
                        foreach (var intellisences in list)
                        {
                            mCompList.Add(new Completion(
                           intellisences.DisplayText
                           , intellisences.InsertionText.Replace("@REPLACENAME", starttext).Replace("@TableName", filename)
                           , intellisences.Description
                           , m_sourceProvider.GlyphService.GetGlyph(StandardGlyphGroup.GlyphGroupProperty, StandardGlyphItem.GlyphItemPublic)
                           , "72"));

                        }
                        mCompList.Add(new Completion(
                        "不吃肉的狮子"
                        , "不吃肉的狮子"
                        , "不吃肉的狮子"
                        , m_sourceProvider.GlyphService.GetGlyph(StandardGlyphGroup.GlyphExtensionMethod, StandardGlyphItem.GlyphItemPublic)
                        , "72"));


                        var set = new CompletionSet(
                              "moniker",//"施政的智能提示",
                              "施政的智能提示",
                              FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer), session),
                              mCompList,
                              null);

                        completionSets.Add(set);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }


        public string BatchCurrentLineContext(string context, string sql)
        {
            var element = Core.UsuallyCommon.XmlParser.GetCurrentLineElement(context);

            if (element == null)
                return sql;

            var attributes = element.Attributes();

            foreach (var arr in attributes)
            {
                sql = sql.Replace($"@{arr.Name}", $"{arr.Value}");
            }

            return sql;
        }
        public string BatchContext(string context, string sql)
        {
            var arrs = StringHelper.GetStringListByStartAndEndInner(sql, "[[", "]]");
            foreach (var arr in arrs)
            {
                var rs = arr.Replace("[[", string.Empty).Replace("]]", string.Empty);
                var result = string.Empty;
                if (rs.IndexOf(".") > 0)
                    result = XmlParser.GetElementAttributteValueByPath(context, rs.Split('.')[0], rs.Split('.')[1]);

                else
                    result = XmlParser.GetElementValueByPath(context, rs);
                sql = sql.Replace($"[[{rs}]]", $"{result}");
            }
            return sql;
        }

        ITrackingSpan FindTokenSpanAtPosition(ITrackingPoint point, ICompletionSession session)
        {
            SnapshotPoint currentPoint = (session.TextView.Caret.Position.BufferPosition) - 1;
            ITextStructureNavigator navigator = m_sourceProvider.NavigatorService.GetTextStructureNavigator(m_textBuffer);
            TextExtent extent = navigator.GetExtentOfWord(currentPoint);
            return currentPoint.Snapshot.CreateTrackingSpan(extent.Span, SpanTrackingMode.EdgeInclusive);
        }

        public void Dispose()
        {

        }
    }



    [Export(typeof(IVsTextViewCreationListener))]
    [Name("ueqt completion handler")]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    internal sealed class UeqtVsTextViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        IVsEditorAdaptersFactoryService AdaptersFactory = null;
        [Import]
        ICompletionBroker CompletionBroker = null;

        [Import]
        internal SVsServiceProvider ServiceProvider = null;
        //[Import(typeof(SVsServiceProvider))]
        //internal Microsoft.VisualStudio.OLE.Interop.IServiceProvider ServiceProvider { get; set; }

        [Import]
        internal IEditorOperationsFactoryService EditorOperationsFactoryService
        {
            get;
            set;
        }

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            IWpfTextView view = AdaptersFactory.GetWpfTextView(textViewAdapter);
            if (view == null) return;

            UeqtCommandFilter filter = new UeqtCommandFilter(view, CompletionBroker);
            IOleCommandTarget next;
            textViewAdapter.AddCommandFilter(filter, out next);
            filter._Next = next;

        }
    }

    internal sealed class UeqtCommandFilter : IOleCommandTarget
    {
        /// <summary>
        /// 当前会话
        /// </summary>
        ICompletionSession _CurrentSession;

        /// <summary>
        /// TextView(WPF)
        /// </summary>
        IWpfTextView _TextView { get; set; }

        /// <summary>
        /// 代理
        /// </summary>
        ICompletionBroker _Broker { get; set; }

        /// <summary>
        /// 执行由VMCommandFilter未执行完的命令
        /// </summary>
        public IOleCommandTarget _Next { get; set; }

        public UeqtCommandFilter(IWpfTextView textView, ICompletionBroker broker)//, IOleCommandTarget next)
        {
            this._TextView = textView;
            this._Broker = broker;

            //this._Next = next;
        }

        /// <summary>
        /// 获取输入的字符
        /// </summary>
        /// <param name="pvaIn">输入指针</param>
        private char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            bool handled = false;
            int hresult = VSConstants.S_OK;

            // 1. Pre-process
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                char typedChar = char.MinValue;
                //make sure the input is a char before getting it
                if (pguidCmdGroup == VSConstants.VSStd2K && nCmdID == (uint)VSConstants.VSStd2KCmdID.TYPECHAR)
                {
                    typedChar = (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
                }
                if ((VSConstants.VSStd2KCmdID)nCmdID == VSConstants.VSStd2KCmdID.AUTOCOMPLETE || (VSConstants.VSStd2KCmdID)nCmdID == VSConstants.VSStd2KCmdID.COMPLETEWORD)
                {
                    handled = true;// StartSession();
                }
                else if (nCmdID == (uint)VSConstants.VSStd2KCmdID.RETURN
                   || nCmdID == (uint)VSConstants.VSStd2KCmdID.TAB
                   || (char.IsWhiteSpace(typedChar) || char.IsPunctuation(typedChar)) && typedChar != '.')
                {
                    if (nCmdID == (uint)VSConstants.VSStd2KCmdID.RETURN
                   || nCmdID == (uint)VSConstants.VSStd2KCmdID.TAB)
                    {
                        if (_CurrentSession != null && _CurrentSession.SelectedCompletionSet != null)
                        {
                            // 自动完成后不输入回车和Tab
                            handled = true;
                        }
                    }
                    else
                    {
                        handled = false;
                    }

                    Complete(true);
                }
                else if ((VSConstants.VSStd2KCmdID)nCmdID == VSConstants.VSStd2KCmdID.CANCEL)
                {
                    handled = false;//Cancel();
                }
            }

            if (!handled)
                hresult = _Next.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);

            if (ErrorHandler.Succeeded(hresult))
            {
                if (pguidCmdGroup == VSConstants.VSStd2K)
                {
                    switch ((VSConstants.VSStd2KCmdID)nCmdID)
                    {
                        case VSConstants.VSStd2KCmdID.TYPECHAR:
                            new ListChar().InitDatabaseConfig();
                            char ch = GetTypeChar(pvaIn);
                            //如果当前的会话已经被启动
                            if (_CurrentSession != null && _CurrentSession.IsStarted && ch != '.')
                            {
                                //执行过滤
                                _CurrentSession.SelectedCompletionSet.Filter();
                                //选择最佳匹配
                                _CurrentSession.SelectedCompletionSet.SelectBestMatch();
                                //重新计算CompletionSet
                                _CurrentSession.SelectedCompletionSet.Recalculate();

                            }

                            if (ListChar.chars.Any(x => x == ch.ToString()) || ch == '.')
                            {

                             
                            
                                //获取插入符号,也就是光标位置.
                                SnapshotPoint caret = _TextView.Caret.Position.BufferPosition;
                                //文本快照
                                ITextSnapshot snapShot = caret.Snapshot;
                                //在当前插入符号位置创建积极的。。跟踪点
                                ITrackingPoint trackingPoint = snapShot.CreateTrackingPoint(caret, PointTrackingMode.Positive);
                                //由代理创建Completion会话
                                _CurrentSession = _Broker.CreateCompletionSession(_TextView, trackingPoint, true);
                               

                                //添加放弃事件
                                _CurrentSession.Dismissed += (sender, args) => _CurrentSession = null;
                                //启动该会话. 
                                _CurrentSession.Start();
                               // _CurrentSession.Filter();

                            }
                            //if (ch == ' ')
                            //    StartSession();
                            //else if (_CurrentSession != null && _CurrentSession.SelectedCompletionSet != null)
                            //    _CurrentSession.Filter();
                            break;
                        case VSConstants.VSStd2KCmdID.BACKSPACE:
                            if (_CurrentSession != null && _CurrentSession.SelectedCompletionSet != null)
                            {
                                _CurrentSession.Filter();
                            }
                            break;
                    }
                }
            }

            return hresult;
        }

        /// <summary>
        /// 查询该对象以获得由用户界面事件生成的一个或多个命令的状态
        /// </summary>
        /// <param name="pguidCmdGroup">命令组的 GUID</param>
        /// <param name="cCmds">命令数</param>
        /// <param name="prgCmds">数组指示命令调用方需要状态信息的 OLECMD 结构</param>
        /// <param name="pCmdText">由OLECMDTEXT返回的单个命令的状态信息</param>
        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return _Next.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        /// <summary>
        /// 确认完成或者丢弃
        /// </summary>
        private bool Complete(bool force)
        {
            if (_CurrentSession == null || !_CurrentSession.IsStarted)
                return false;

            //如果用户没有选择并且主动丢弃
            if (!_CurrentSession.SelectedCompletionSet.SelectionStatus.IsSelected && !force)
            {
                _CurrentSession.Dismiss();
                return false;
            }
            else
            {
                ITextEdit edit = _CurrentSession.TextView.TextBuffer.CreateEdit();
                ITextSnapshot snapshot = edit.Snapshot;


                string inputtext = _CurrentSession.TextView.Caret.Position.BufferPosition.GetContainingLine().GetText();

               
                var inputlist = Core.UsuallyCommon.StringHelper.GetStringSingleColumn(inputtext);

                var starttext = string.Empty;
                foreach (var chars in ListChar.chars)
                {
                    starttext = inputlist.FirstOrDefault(x => x.Contains(chars));
                    if(!string.IsNullOrEmpty(starttext))
                        break;
                } 
                string lastChar = starttext.Substring(starttext.Length - 1, 1);

                starttext = starttext.Replace(lastChar, "").Trim();

                int position = (starttext.LastIndexOf(" ") > 0) ? (starttext.Length + 1 - starttext.LastIndexOf(" "))
                        : (starttext.LastIndexOf("\t") > 0 ? (starttext.Length + 1 - starttext.LastIndexOf("\t")) : starttext.Length + 1);

                if (ListChar.chars.Any(x => x == lastChar))
                {

                    edit.Delete(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position
                        , position);

                    string text = _CurrentSession.SelectedCompletionSet.SelectionStatus.Completion.InsertionText;

                    edit.Insert(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position, text);
                }

                edit.Apply();
                if (_CurrentSession != null)
                    _CurrentSession.Dismiss();
                //_CurrentSession.Commit();
                return true;
            }

        }
    }
}

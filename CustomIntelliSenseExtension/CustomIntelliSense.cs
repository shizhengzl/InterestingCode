using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualStudio.Utilities;

namespace CustomIntelliSenseExtension
{
    internal sealed class CustomIntelliSense
    {
        /// <summary>
        /// The layer of the adornment.
        /// </summary>
        private readonly IAdornmentLayer layer;

        /// <summary>
        /// Text view where the adornment is created.
        /// </summary>
        private readonly IWpfTextView view;

        /// <summary>
        /// Adornment brush.
        /// </summary>
        private readonly Brush brush;

        /// <summary>
        /// Adornment pen.
        /// </summary>
        private readonly Pen pen;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomIntelliSense"/> class.
        /// </summary>
        /// <param name="view">Text view to create the adornment for</param>
        public CustomIntelliSense(IWpfTextView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.layer = view.GetAdornmentLayer("CustomIntelliSense");

            this.view = view;
            this.view.LayoutChanged += this.OnLayoutChanged;

            // Create the pen and brush to color the box behind the a's
            this.brush = new SolidColorBrush(Color.FromArgb(0x20, 0x00, 0x00, 0xff));
            this.brush.Freeze();

            var penBrush = new SolidColorBrush(Colors.Red);
            penBrush.Freeze();
            this.pen = new Pen(penBrush, 0.5);
            this.pen.Freeze();
        }

        /// <summary>
        /// Handles whenever the text displayed in the view changes by adding the adornment to any reformatted lines
        /// </summary>
        /// <remarks><para>This event is raised whenever the rendered text displayed in the <see cref="ITextView"/> changes.</para>
        /// <para>It is raised whenever the view does a layout (which happens when DisplayTextLineContainingBufferPosition is called or in response to text or classification changes).</para>
        /// <para>It is also raised whenever the view scrolls horizontally or when its size changes.</para>
        /// </remarks>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            foreach (ITextViewLine line in e.NewOrReformattedLines)
            {
                this.CreateVisuals(line);
            }
        }

        /// <summary>
        /// Adds the scarlet box behind the 'a' characters within the given line
        /// </summary>
        /// <param name="line">Line to add the adornments</param>
        private void CreateVisuals(ITextViewLine line)
        {
            IWpfTextViewLineCollection textViewLines = this.view.TextViewLines;

            // Loop through each character, and place a box around any 'a'
            for (int charIndex = line.Start; charIndex < line.End; charIndex++)
            {
                if (this.view.TextSnapshot[charIndex] == 'a')
                {
                    SnapshotSpan span = new SnapshotSpan(this.view.TextSnapshot, Span.FromBounds(charIndex, charIndex + 1));
                    Geometry geometry = textViewLines.GetMarkerGeometry(span);
                    if (geometry != null)
                    {
                        var drawing = new GeometryDrawing(this.brush, this.pen, geometry);
                        drawing.Freeze();

                        var drawingImage = new DrawingImage(drawing);
                        drawingImage.Freeze();

                        var image = new Image
                        {
                            Source = drawingImage,
                        };

                        // Align the image with the top of the bounds of the text geometry
                        Canvas.SetLeft(image, geometry.Bounds.Left);
                        Canvas.SetTop(image, geometry.Bounds.Top);

                        this.layer.AddAdornment(AdornmentPositioningBehavior.TextRelative, span, null, image, null);
                    }
                }
            }
        }
    }






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

    internal class UeqtDynamicCompletionSource : ICompletionSource
    {

        ITextBuffer m_textBuffer { get; set; }
        UeqtDynamicCompletionSourceProvider m_sourceProvider { get; set; }
        public UeqtDynamicCompletionSource(UeqtDynamicCompletionSourceProvider t, ITextBuffer tb)
        {
            m_textBuffer = tb;
            m_sourceProvider = t;
        }


        void ICompletionSource.AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            if (session.TextView.TextBuffer.ContentType.TypeName == "CSharp"
                || session.TextView.TextBuffer.ContentType.TypeName == "projection"
                || session.TextView.TextBuffer.ContentType.TypeName == "JScript")
            {
                if (completionSets.Count != 0)
                    return;
                string currentStr = session.TextView.Caret.Position.BufferPosition.GetContainingLine().GetText();

                string lastChar = currentStr.Substring(currentStr.Length - 1, 1);

                if (lastChar == ".")
                {
                    if (currentStr.LastIndexOf(" ") > 0)
                    {
                        currentStr = currentStr.Substring(currentStr.LastIndexOf(" ") + 1);
                    }
                    if (currentStr.LastIndexOf("\t") > 0)
                    {
                        currentStr = currentStr.Substring(currentStr.LastIndexOf("\t") + 1);
                    }
                    // 判断.的个数
                    string searchNode = string.Empty;
                    if (currentStr.Length - currentStr.Replace(".", "").Length == 1)
                    {
                        if (currentStr.Replace(".", "").ToLower() == "szcommon")
                            searchNode = currentStr.Replace(".", "");
                        else
                            return;
                    }
                    else
                    {
                        // 判断第一个点之前是不是szcommon 如果不是则马上返回
                        if (currentStr.Substring(0, currentStr.IndexOf(".")).Replace(".", "").ToLower() != "szcommon")
                            return;
                        searchNode = currentStr.Substring(0, currentStr.Length - 1).Replace(".", "//");
                    }

                    var mCompList = new List<Completion>();
                    try
                    {

                        mCompList.Add(new Completion(
                            ".不吃肉的狮子"
                            , "不吃肉的狮子"
                            , "不吃肉的狮子"
                            , m_sourceProvider.GlyphService.GetGlyph(StandardGlyphGroup.GlyphGroupProperty, StandardGlyphItem.GlyphItemInternal)
                            , "72"));

                        var set = new CompletionSet(
                                   "szCommon",//"施政的智能提示",
                                   "施政的智能提示",
                                   FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer), session),
                                   mCompList,
                                   null);
                        if (!completionSets.Contains(set))
                            completionSets.Insert(0, set);

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }

                }

                if (lastChar == "$")
                {
                    currentStr = currentStr.Replace("$", "").Trim();

                    var mCompList = new List<Completion>();
                    try
                    {
                        mCompList.Add(new Completion(
                            "不吃肉的狮子"//list[i].Attributes["Model"].Value.ToString(),
                            , "不吃肉的狮子"//list[i].Attributes["SQL"].Value.ToString(),
                            , "生成成功!"
                            , m_sourceProvider.GlyphService.GetGlyph(StandardGlyphGroup.GlyphGroupProperty, StandardGlyphItem.GlyphItemPublic)
                            , "72"));

                        mCompList.Add(new Completion(
                           "不吃肉的狮子1"//list[i].Attributes["Model"].Value.ToString(),
                           , "不吃肉的狮子1"//list[i].Attributes["SQL"].Value.ToString(),
                           , "生成成功!"
                           , m_sourceProvider.GlyphService.GetGlyph(StandardGlyphGroup.GlyphGroupProperty, StandardGlyphItem.GlyphItemPublic)
                           , "72"));

                        var set = new CompletionSet(
                                   "施政的智能提示",//"施政的智能提示",
                                   "施政的智能提示",
                                   FindTokenSpanAtPosition(session.GetTriggerPoint(m_textBuffer), session),
                                   mCompList,
                                   null);
                        if (!completionSets.Contains(set))
                            completionSets.Insert(0, set);

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
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
    [ContentType("CSharp")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    internal sealed class UeqtVsTextViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        IVsEditorAdaptersFactoryService AdaptersFactory = null;
        [Import]
        ICompletionBroker CompletionBroker = null;

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
                            if (ch == '$' || ch == '.')
                            {
                                //获取插入符号,也就是光标位置.
                                SnapshotPoint caret = _TextView.Caret.Position.BufferPosition;
                                //文本快照
                                ITextSnapshot snapShot = caret.Snapshot;
                                //在当前插入符号位置创建积极的。。跟踪点
                                ITrackingPoint trackingPoint = snapShot.CreateTrackingPoint(caret, PointTrackingMode.Positive);
                                //由代理创建Completion会话
                                _CurrentSession = _Broker.CreateCompletionSession(_TextView, trackingPoint, true);
                                //启动该会话.
                                _CurrentSession.Start();
                                // _CurrentSession.SelectedCompletionSet.SelectionStatus = new  CompletionSelectionStatus(_CurrentSession.SelectedCompletionSet.Completions[0],true,true);
                                //添加放弃事件
                                _CurrentSession.Dismissed += (sender, args) => _CurrentSession = null;
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

                string currentString = _CurrentSession.TextView.Caret.Position.BufferPosition.GetContainingLine().GetText();
                string lastChar = currentString.Substring(currentString.Length - 1, 1);
                int position = (currentString.LastIndexOf(" ") > 0) ? (currentString.Length - currentString.LastIndexOf(" "))
                        : (currentString.LastIndexOf("\t") > 0 ? (currentString.Length - currentString.LastIndexOf("\t")) : currentString.Length);

                if (lastChar == "$")
                {
                    //判断table
                    string tableName = currentString;
                    if (tableName.LastIndexOf('.') > 0)
                    {
                        tableName = tableName.Substring(tableName.LastIndexOf('.') + 1);
                    }
                    if (tableName.LastIndexOf(" ") > 0)
                    {
                        tableName = tableName.Substring(tableName.LastIndexOf(" ") + 1);
                    }
                    if (tableName.LastIndexOf("\t") > 0)
                    {
                        tableName = tableName.Substring(tableName.LastIndexOf("\t") + 1);
                    }
                    if (tableName.IndexOf("$") > 0)
                    {
                        tableName = tableName.Replace("$", "").Trim();
                    }
                    edit.Delete(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position, position);

                    //string text = _CurrentSession.SelectedCompletionSet.SelectionStatus.Completion.InsertionText.ToString();
                    // 从数据库读取
                    string sqlConstr = _CurrentSession.SelectedCompletionSet.Moniker.ToString();
                    string sql = _CurrentSession.SelectedCompletionSet.SelectionStatus.Completion.InsertionText;
                    sql = sql.Replace("@TableName", tableName);



                    string text = "不吃肉的狮子";// DbHelper.DbHelperSQL.ExecScalar(sql);

                    edit.Insert(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position, text);
                }
                else
                {
                    if (lastChar == ".")
                    {
                        if (_CurrentSession.SelectedCompletionSet.SelectionStatus.Completion.Description.ToString() == "hasChild")
                            position = 0;
                        else
                            edit.Delete(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position, position);
                    }
                    else
                    {
                        if (_CurrentSession.SelectedCompletionSet.SelectionStatus.Completion.Description.ToString() == "hasChild")
                            position = currentString.Length - currentString.LastIndexOf('.') - 1;
                        edit.Delete(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position, position);
                    }
                    edit.Insert(_CurrentSession.TextView.Caret.Position.BufferPosition.Position - position, _CurrentSession.SelectedCompletionSet.SelectionStatus.Completion.InsertionText);

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

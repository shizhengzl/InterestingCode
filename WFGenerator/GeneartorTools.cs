﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;
using System.Data.Entity;
using System.Linq.Expressions;
using VSBussinessExtenstion.DataBaseHelper;
using Core.UsuallyCommon.DataBase;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using Core.UsuallyCommon;
using System.Reflection;
using System.Xml;

namespace WFGenerator
{
    public partial class GeneartorTools : Form
    {
        public GeneartorTools()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitSystemConfig();
        }
         
        private void GeneartorTools_Load(object sender, EventArgs e)
        {
            ServerTree.sqlite = sqlite;
            ServerTree.sh = sh;
            ServerTree.ImageList = imageList;
            ServerTree.treeType = TreeType.DataBase;
            ServerTree.Refreshs();

            SnippetTree.sqlite = sqlite;
            SnippetTree.CheckBoxes = false;
            SnippetTree.ImageList = imageList;
            SnippetTree.treeType = TreeType.Snippte;
            SnippetTree.Refreshs();

            ClassTree.ImageList = imageList;
            ClassTree.treeType = TreeType.Class;
        }
        
        #region Variabled 
        public DefaultSqlite sqlite = new DefaultSqlite();
        public ServicesAddressHelper sh = new ServicesAddressHelper();
        public List<Table> listAllTalbe = new List<Table>();
        public GeneratorClass generatorClass = new GeneratorClass();
        #endregion

        #region SystemConfig

        public void InitSystemConfig()
        {
            InitClass<ConnectionString>();
            InitClass<DataBaseAddress>();
            InitClass<SQLConfig>();
            InitClass<Variable>();
            InitClass<DataTypeConfig>();
            InitClass<Snippet>();
        }

        public void InitClass<T>() where T : class, new()
        {
            var type = typeof(T);
            var className = type.Name;
            TabPage tpclass = new TabPage() { Name = className, Text = className };

            PanelExtension<T> panel = new PanelExtension<T>();
            tpclass.Controls.Add(panel);
            tabControlSet.TabPages.Add(tpclass);
        }
        #endregion 

        #region Filter 
        private void btnSearch_Click(object sender, EventArgs e)
        { 
            var context = txtSearch.Text;
            var listdata = StringHelper.GetStringSingleColumn(context);
            SelectDataSoruceType selecttype = Core.UsuallyCommon.Extensions.EnumParse<SelectDataSoruceType>(tabControlSelect.SelectedIndex.ToString());

            if (listdata.Count == 0) 
                return; 

            if (rdLikdSearch.Checked)
            {
                if (rdFilterTable.Checked)
                {
                    switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            ServerTree.listSelect.Clear();
                            ServerTree.Refreshs(listdata, SearchType.LikeSearch);
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
                else
                {

                }
            }

            if (rdFuzzySearch.Checked)
            {
                if (rdFilterTable.Checked)
                {
                    switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            ServerTree.listSelect.Clear();
                            ServerTree.Refreshs(listdata, SearchType.FuzzySearch, txtFuzzyPercent.Text.ToDouble() / 100.00);
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
                else
                {

                }
            }

            if (rdComplete.Checked)
            {
                if (rdFilterTable.Checked)
                {
                     switch (selecttype)
                    {
                        case SelectDataSoruceType.DataBase:
                            ServerTree.listSelect.Clear();
                            ServerTree.Refreshs(listdata,SearchType.Complete);
                            break;
                        case SelectDataSoruceType.Class:
                            break;
                        case SelectDataSoruceType.XML:
                            break;
                    }
                }
                else
                {

                }
            }
        }
         
        private void btnClear_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Generator 
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            ServerTree.Refresh();
        }

        private void tGenerator_Click(object sender, EventArgs e)
        {

        }

        private void SnippetTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var snippet = e.Node.Tag as Snippet;
            if (snippet.IsFloder)
                return;
            txtGenerator.Text = string.Empty;
            SelectDataSoruceType selecttype = Core.UsuallyCommon.Extensions.EnumParse<SelectDataSoruceType>(tabControlSelect.SelectedIndex.ToString());

            switch (selecttype)
            {
                case SelectDataSoruceType.DataBase:
                    if (snippet.DataSourceType == DataSourceType.DatabaseType)
                        txtGenerator.AppendText(generatorClass.GetGenerator(snippet, ServerTree.listSelect, sh));
                    break;
                case SelectDataSoruceType.Class:
                    if (snippet.DataSourceType == DataSourceType.CSharpType)
                        txtGenerator.AppendText(generatorClass.GetGenerator(snippet, ClassTree.listSelect));
                    break;
                case SelectDataSoruceType.XML:
                    break;
            }
        }

        private void tGeneratorFile_Click(object sender, EventArgs e)
        {

        }

        private void txtXmlSelect_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.txtXmlSelect.Cursor = System.Windows.Forms.Cursors.Arrow;  //指定鼠标形状（更好看）
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtXmlSelect_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            var context = Core.UsuallyCommon.IoHelper.FileReader(path);

            txtXmlSelect.Text = context;

            //还原鼠标形状        
            this.txtXmlSelect.Cursor = System.Windows.Forms.Cursors.IBeam;

            if (!string.IsNullOrEmpty(context))
            {
                GeneratorClass(context);
            }
        }

        private void btnString_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXmlSelect.Text))
            {
                return;
            }
            GeneratorClass(txtXmlSelect.Text);
        }

        private void GeneratorClass(string context)
        {
            CSharpParser cSharpParser = new CSharpParser(context);
            try
            {
                ClassTree.Refreshs(null,0,0,cSharpParser.GetClass());
                tabControlSelect.SelectedIndex = (int)SelectDataSoruceType.Class;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }

    public class ExtenstionClass
    {
        public static List<T> GetList<T>(DefaultSqlite sqlite)
        {
            var tables = FindTable<T>(sqlite);
            var query = (IEnumerable<T>)
                sqlite.GetType().GetProperty(tables).GetValue(sqlite, null);
            return query.ToList<T>();

        }

        public static string FindTable<T>(DefaultSqlite sqlite)
        {
            var metadata = ((IObjectContextAdapter)sqlite).ObjectContext.MetadataWorkspace;

            var tables = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>()
                .Where(s => !s.MetadataProperties.Contains("Type")
                || s.MetadataProperties["Type"].ToString() == "Tables");

            return tables.FirstOrDefault(x => x.Name == typeof(T).Name).Table;
        }
    }
}

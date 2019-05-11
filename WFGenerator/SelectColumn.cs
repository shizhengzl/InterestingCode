using Core.UsuallyCommon.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Core.UsuallyCommon;
using VSBussinessExtenstion;

namespace WFGenerator

{
    public partial class SelectColumn : Form
    {
        public Table table { get; set; }

        private ComboBox Score_ComboBox = new ComboBox();

        public DefaultSqlite dbcontext = new DefaultSqlite();

        public List<Core.UsuallyCommon.DataBase.Control> controls = new List<Core.UsuallyCommon.DataBase.Control>();

        public void DataBindCompobox()
        {
            controls = dbcontext.Controls.ToList();
            Score_ComboBox.ValueMember = "ControlName";
            Score_ComboBox.DisplayMember = "ControlName";
            Score_ComboBox.DataSource = controls;
            this.Score_ComboBox.Visible = false;
            this.Score_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public SelectColumn(Table _table)
        {
            InitializeComponent();
            DataBindCompobox();
            this.Score_ComboBox.Leave += Score_ComboBox_Leave;
            this.Score_ComboBox.SelectedIndexChanged += Score_ComboBox_SelectedIndexChanged;

            this.datagrid.Controls.Add(Score_ComboBox);

            this.Text = $"数据库：{_table.DataBaseName} 表：{_table.TableName }({_table.TableDescription})";
            table = _table;
            DataBind();
        }

        public void DataBind()
        { 
            table.Columns.ForEach(x =>
            {
                if (string.IsNullOrEmpty(x.CreateControls))
                {
                    var types = x.CSharpType.ToUpper();

                    var serachcontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Search && (y.CsharpType.ToUpper().Contains(types)));
                    var gridcontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Grid && (y.CsharpType.ToUpper().Contains(types)));
                    var createcontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Create && (y.CsharpType.ToUpper().Contains(types)));
                    var modifycontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Modify && (y.CsharpType.ToUpper().Contains(types)));
                    if (serachcontrols == null)
                        serachcontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Search && y.IsDefault);
                    if (gridcontrols == null)
                        gridcontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Grid && y.IsDefault);
                    if (createcontrols == null)
                        createcontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Create && y.IsDefault);
                    if (modifycontrols == null)
                        modifycontrols = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Modify && y.IsDefault);

                    x.SearchControl = serachcontrols;
                    x.GridControl = gridcontrols;
                    x.CreateControl = createcontrols;
                    x.ModifyControl = modifycontrols;

                    x.SearchControls = serachcontrols?.ControlName;
                    x.GridControls = gridcontrols?.ControlName;
                    x.CreateControls = createcontrols?.ControlName;
                    x.ModifyControls = modifycontrols?.ControlName;
                }
            });



            this.datagrid.DataSource = table.Columns;
            this.datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void Score_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cindex = datagrid.CurrentCell.ColumnIndex;
            var rindex = datagrid.CurrentCell.RowIndex;

            var property = typeof(Column).GetProperties().ToList().Skip(cindex).FirstOrDefault();

            var controlname = ((ComboBox)sender).Text;
            var c = controls.FirstOrDefault(x => x.ControlName == controlname.ToStringExtension());

            var s = new Core.UsuallyCommon.DataBase.Control()
            {
                Id = c.Id,
                ControlDataSources = c.ControlDataSources,
                ControlMode = c.ControlMode,
                ControlName = c.ControlName,
                ControlText = c.ControlText
            ,
                CsharpType = c.CsharpType,
                IsDefault = c.IsDefault,
                NeedDataSource = c.NeedDataSource
            };



            table.Columns[rindex].SetPropertyValue(property.Name, controlname);
            table.Columns[rindex].SetPropertyValue(property.Name.TrimEnd('s') ,s);
          

        }

        private void Score_ComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                ComboBox bx = (ComboBox)sender;
                //int row_index = this.datagrid.CurrentCell.RowIndex;
                this.Score_ComboBox.Visible = false;
                  
            }
            catch (Exception ex)
            {
            }
        }

        private void tok_Click(object sender, EventArgs e)
        {
            datagrid.EndEdit();
            try
            {
                for (int i = 0; i < this.table.Columns.Count; i++)//得到总行数并在之内循环    
                {
                    Column col = this.table.Columns[i];
                    var piar = col.GetType().GetProperties().ToList();
                    foreach (PropertyInfo pi in piar)
                    {
                        if (pi.PropertyType.IsGenericType)
                            continue;
                        col.SetPropertyValue(pi.Name, datagrid.Rows[i].Cells[pi.Name].Value);
                    }
                }
                var search = table.Columns.Where(x => (x.SearchControl != null && x.SearchControl.NeedDataSource)
                || (x.GridControl != null && x.GridControl.NeedDataSource)
                || (x.CreateControl != null && x.CreateControl.NeedDataSource)
                || (x.ModifyControl != null && x.ModifyControl.NeedDataSource)).ToList<Column>();

                foreach (var s in search)
                {
                    ControlDataSource cd = new ControlDataSource();
                    if (s.SearchControl != null && s.SearchControl.NeedDataSource)
                    {
                        SelectDataSource selectDataSource = new SelectDataSource(s, s.SearchControl.ControlDataSources,"查询列");
                        if (selectDataSource.ShowDialog() == DialogResult.OK)
                        {
                            s.SearchControl.ControlDataSources = selectDataSource._controlDataSource;
                        }
                    }

                    if (s.GridControl != null && s.GridControl.NeedDataSource)
                    {
                        SelectDataSource selectDataSource = new SelectDataSource(s, s.GridControl.ControlDataSources, "列表");
                        if (selectDataSource.ShowDialog() == DialogResult.OK)
                        {
                            s.GridControl.ControlDataSources = selectDataSource._controlDataSource;
                        }
                    }
                    if (s.CreateControl != null && s.CreateControl.NeedDataSource)
                    {
                        SelectDataSource selectDataSource = new SelectDataSource(s, s.CreateControl.ControlDataSources, "创建列");
                        if (selectDataSource.ShowDialog() == DialogResult.OK)
                        {
                            s.CreateControl.ControlDataSources = selectDataSource._controlDataSource;
                        }
                    }

                    if (s.ModifyControl != null && s.ModifyControl.NeedDataSource)
                    {
                        SelectDataSource selectDataSource = new SelectDataSource(s, s.ModifyControl.ControlDataSources, "修改列");
                        if (selectDataSource.ShowDialog() == DialogResult.OK)
                        {
                            s.ModifyControl.ControlDataSources = selectDataSource._controlDataSource;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void tcansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tselectAll_Click(object sender, EventArgs e)
        {
            this.datagrid.DataSource = null;
            table.Columns.ForEach(x => x.IsSelect = true);
            DataBind();
        }

        private void treverse_Click(object sender, EventArgs e)
        {
            this.datagrid.DataSource = null;
            table.Columns.ForEach(x => x.IsSelect = !x.IsSelect);
            DataBind();
        }

        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                var cindex = this.datagrid.CurrentCell.ColumnIndex;
                if (cindex == 1 || cindex == 2 || cindex == 3 || cindex == 4)
                {
                    List<Core.UsuallyCommon.DataBase.Control> list = new List<Core.UsuallyCommon.DataBase.Control>();
                    if (cindex == 1)
                        list = controls.Where(x => x.ControlMode == ControlMode.Search).ToList();
                    if (cindex == 2)
                        list = controls.Where(x => x.ControlMode == ControlMode.Grid).ToList();
                    if (cindex == 3)
                        list = controls.Where(x => x.ControlMode == ControlMode.Create).ToList();
                    if (cindex == 4)
                        list = controls.Where(x => x.ControlMode == ControlMode.Modify).ToList();

                    Core.UsuallyCommon.DataBase.Control[] con = new Core.UsuallyCommon.DataBase.Control[list.Count];
                    list.CopyTo(con);
                    Score_ComboBox.DataSource = con.ToList();
                    Rectangle rect = datagrid.GetCellDisplayRectangle(datagrid.CurrentCell.ColumnIndex, datagrid.CurrentCell.RowIndex, false);
                     
                    Score_ComboBox.Left = rect.Left;
                    Score_ComboBox.Top = rect.Top;
                    Score_ComboBox.Width = rect.Width;
                    Score_ComboBox.Height = rect.Height;
                    Score_ComboBox.Visible = true;
                }
                else
                {
                    Score_ComboBox.Visible = false;
                }
            }
            catch
            {
            }
        }
    }
}

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

namespace  WFGenerator

{
    public partial class SelectColumn : Form
    {
        public Table table { get; set; }

        private ComboBox Score_ComboBox = new ComboBox();

        public DefaultSqlite dbcontext = new DefaultSqlite();

        public List<VSBussinessExtenstion.Control> controls = new List<VSBussinessExtenstion.Control>();

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
           

            table.Columns.ForEach(x=> {
                var types = x.CSharpType.ToUpper();
                 

                // 处理Grid
                var search = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Search && y.CsharpType.ToUpper().Contains(types));
                if(search != null) 
                    x.GridControls = search.ControlName; 

                var create = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Create 
                         && y.CsharpType.ToUpper().Contains(types));
                if (create != null)
                    x.CreateControls = create.ControlName;
               
                var modify = controls.FirstOrDefault(y => y.ControlMode == ControlMode.Modify
                         && y.CsharpType.ToUpper().Contains(types));

                if (modify != null)
                    x.ModifyControls = modify.ControlName;

            });

              

            this.datagrid.DataSource = table.Columns;
            this.datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
             
        }

        private void Score_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cindex = datagrid.CurrentCell.ColumnIndex ;
            var rindex = datagrid.CurrentCell.RowIndex ;

            var column = table.Columns.Skip(rindex).FirstOrDefault();

            var property = typeof(Column).GetProperties().ToList().Skip(cindex).FirstOrDefault();

            column.SetPropertyValue(property.Name, ((ComboBox)sender).SelectedValue);

            DataBind();
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
                        //col.GetType().GetProperty(pi.Name).SetValue(col, Convert.ChangeType(datagrid.Rows[i].Cells[pi.Name].Value, datagrid.Rows[i].Cells[pi.Name].ValueType), null);
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
                    Rectangle rect = datagrid.GetCellDisplayRectangle(datagrid.CurrentCell.ColumnIndex, datagrid.CurrentCell.RowIndex, false);
                    var  Value = datagrid.CurrentCell.Value.ToStringExtension();

                    Score_ComboBox.Text = Value;

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

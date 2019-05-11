using Core.UsuallyCommon.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion.DataBaseHelper;

namespace WFGenerator
{
    public partial class SelectDataSource : Form
    {
        public SelectDataSource(Column c, ControlDataSource controlDataSource,string name)
        {
            InitializeComponent();
            this.Text = $"为表{c.TableName}列{c.ColumnName}--{name}选择数据源";
            _controlDataSource = controlDataSource;
        }

        public ControlDataSource _controlDataSource { get; set; }

        private void btnChose_Click(object sender, EventArgs e)
        {

            SelectTables selectTables = new SelectTables(table);
            DialogResult dia = selectTables.ShowDialog();
            if (dia == DialogResult.OK)
            {
                table = selectTables.table;
            }
                sh.InitColumn(table);
            InitData();


        }
        public ServicesAddressHelper sh = new ServicesAddressHelper();
        public Table table = new Table();
        private void btnEnum_Click(object sender, EventArgs e)
        {

        }

        public void GetData()
        { 
            _controlDataSource =   new ControlDataSource()
            {
                DataSourceKey = comkey.Text,
                DataSourceUrl = txturl.Text,
                DataSourceName = txtname.Text,
                DataSourceVlaue = comvalue.Text,
                DataSourceParentId = comparent.Text
            };
        }


        public void InitData()
        {
            txturl.Text = txturl.Text.Replace("@TableName", table.TableName);
            txtname.Text = table.TableName;

            comkey.DisplayMember = "ColumnName";
            comkey.ValueMember = "Id";


            comvalue.DisplayMember = "ColumnName";
            comvalue.ValueMember = "Id";


            comparent.DisplayMember = "ColumnName";
            comparent.ValueMember = "Id";

            comkey.DataSource = table.Columns;
            Column[] v = new Column[table.Columns.Count];
            Column[] p = new Column[table.Columns.Count];
            table.Columns.CopyTo(v);
            table.Columns.CopyTo(p);
            comvalue.DataSource = v.ToList();
            comparent.DataSource = p.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

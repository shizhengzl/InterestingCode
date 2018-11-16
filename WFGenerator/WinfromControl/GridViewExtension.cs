using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;

namespace WFGenerator
{
    public class GridViewExtension<T> : DataGridView where T : class, new()
    {

        public GeneartorTools tools { get; set; }

        public GridViewExtension(GeneartorTools _tools)
        {
            tools = _tools;
            this.Dock = DockStyle.Fill;
            this.DataSource = ExtenstionClass.GetList<T>(new DefaultSqlite());
            this.AutoGenerateColumns = true;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = Color.White;
            this.CellDoubleClick += GridViewExtension_CellDoubleClick;
        }

        private void GridViewExtension_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var objects = (T)this.CurrentRow.DataBoundItem;//visit  相当于一个实体

            WindowExtension<T> window = new WindowExtension<T>(objects, false, tools);

            DialogResult dialog = window.ShowDialog();

            this.DataSource = ExtenstionClass.GetList<T>(new DefaultSqlite());
        }
    }
}

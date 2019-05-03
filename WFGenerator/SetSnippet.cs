using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;
using Core.UsuallyCommon;

namespace WFGenerator
{
    public partial class SetSnippet : Form
    {
        public Snippet _snippet { get; set; }
        public Snippet _father { get; set; }
        public SetSnippet(Snippet snippet,Snippet father)
        {
            InitializeComponent();
            BindDataSourceType();
            _father = father;
            _snippet = snippet;
            if (snippet!= null)
            {

                txtName.Text = snippet.Name;
                txtDataSourceType.Text = snippet.DataSourceType.ToString();
                txtParentId.Text = father == null ? string.Empty :  father.Name;
                txtOutputPath.Text = snippet.OutputPath;

                IsFloder.Checked = snippet.IsFloder;
                IsEnabled.Checked = snippet.IsEnabled;
                IsMergin.Checked = snippet.IsMergin;
                IsAutoFind.Checked = snippet.IsAutoFind;
                IsSelectGenerator.Checked = snippet.IsSelectGenerator;

                txtText.Text = snippet.Context;
            }
        }

        DefaultSqlite defaultSqlite = new DefaultSqlite();

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            if(_snippet == null)
            {
                _snippet = new Snippet();
                isEdit = false;
            }
            else
            {
                _snippet = defaultSqlite.Snippets.FirstOrDefault(x => x.Id == _snippet.Id);
            }

            _snippet.Name = txtName.Text;
            _snippet.DataSourceType =  txtDataSourceType.Text.ToEnum<DataSourceType>();
            _snippet.ParentId = _father.Id;
            _snippet.OutputPath = txtOutputPath.Text;

            _snippet.IsFloder = IsFloder.Checked;
            _snippet.IsEnabled = IsEnabled.Checked;
            _snippet.IsMergin = IsMergin.Checked;
            _snippet.IsAutoFind = IsAutoFind.Checked;
            _snippet.IsSelectGenerator = IsSelectGenerator.Checked;
            _snippet.Context  = txtText.Text ;

            if(!isEdit)
            {
                defaultSqlite.Snippets.Add(_snippet);
            }

            defaultSqlite.SaveChanges();
            this.Close();
        }

        public void BindDataSourceType()
        {

            txtDataSourceType.Items.AddRange(Core.UsuallyCommon.Extensions.EnumToList(typeof(DataSourceType)).ToArray());
        }
    }
}

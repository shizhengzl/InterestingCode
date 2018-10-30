using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;

namespace WFGenerator
{
    public class ToolScriptExtension<T> : ToolStrip where T : class, new()
    {
      
        public PanelExtension<T> Panel { get; set; }
        public ToolScriptExtension(PanelExtension<T> panel)
        { 
            Panel = panel;
            this.Dock = DockStyle.Fill;  
            List<string> btn = Core.UsuallyCommon.Extensions.EnumToList<ToolScriptButton>();
            foreach (var item in btn)
            {
                // add button 
                ToolStripButton button = new ToolStripButton() { Text = item, Name = $"btn{item}" };
                button.Click += Button_Click;
               
                var btnenum = item.ToEnum<ToolScriptButton>();

                switch (btnenum)
                {
                    case ToolScriptButton.Insert:
                        //button.Image = imageListone.Images[(int)ImageEnum.Add]; 
                        break;
                    case ToolScriptButton.Update:
                        //button.Image = imageListone.Images[(int)ImageEnum.Edit]; 
                        break;
                    case ToolScriptButton.Delete:
                        //button.Image = imageListone.Images[(int)ImageEnum.Remove]; 
                        break;
                    case ToolScriptButton.Refresh:
                        //button.Image = imageListone.Images[(int)ImageEnum.Refresh]; 
                        break;
                }
                this.Items.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            var btnenum = button.Text.ToEnum<ToolScriptButton>();
            switch (btnenum)
            {
                case ToolScriptButton.Insert:
                    WindowExtension<T> windowinsert = new WindowExtension<T>(new T(), true);
                    DialogResult dialoginsert = windowinsert.ShowDialog();
                    break;
                case ToolScriptButton.Update:
                    var rows = Panel.gridView.SelectedRows;
                    if (rows.Count == 0)
                    {
                        return;
                    }
                    var result = ExtenstionClass.GetList<T>(new DefaultSqlite()).Skip(Panel.gridView.SelectedRows[0].Index).Take(1).FirstOrDefault();
                    WindowExtension<T> windowupdate = new WindowExtension<T>(result, false);
                    DialogResult dialogupdate = windowupdate.ShowDialog();
                    break;
                case ToolScriptButton.Delete:
                    DefaultSqlite db = new DefaultSqlite();
                    var resultDelete = ExtenstionClass.GetList<T>(new DefaultSqlite()).Skip(Panel.gridView.SelectedRows[0].Index).Take(1).FirstOrDefault();
                    DbEntityEntry entry = db.Entry<T>(resultDelete);
                    var entity = db.Set(typeof(T)).Attach(resultDelete);
                    entry.State = EntityState.Deleted;
                    db.SaveChanges();
                    break;
                case ToolScriptButton.Refresh:
                    break;
            }
            Panel.gridView.DataSource = ExtenstionClass.GetList<T>(new DefaultSqlite());
        }

   
    }
}

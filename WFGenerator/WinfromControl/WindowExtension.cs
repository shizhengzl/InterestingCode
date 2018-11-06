using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSBussinessExtenstion;

namespace WFGenerator
{
    public class WindowExtension<T> : Form where T : class, new()
    {
        Type type = typeof(T);
        public T objectself { get; set; }

        public bool IsInsert { get; set; }

        public List<Type> enumList = new List<Type>() { typeof(DataBaseType), typeof(DataSourceType), typeof(CharStatu) };
        public WindowExtension(T objects, bool isInsert)
        {
            IsInsert = isInsert;
            objectself = objects;
            var list = objects.GetPropertyList();

            var propretylist = objects.GetType().GetProperties();

            Int32 startIndexX = 20;
            Int32 startIndexY = 20;
            foreach (var proprety in propretylist)
            {
                if (proprety.PropertyType.Name == "List`1")
                    continue;
                var val = proprety.GetValue(objects, null).ToStringExtension();
                Label label = new Label() { Name = $"lbl{proprety.Name}", Text = proprety.Name };

                dynamic textBox;
                if (enumList.Any(x => x.Name == proprety.PropertyType.Name))
                {
                    textBox = new ComboBox() { Name = $"{proprety.Name}" };
                    var firstenum = enumList.FirstOrDefault(x => x.Name == proprety.PropertyType.Name);
                    textBox.Items.AddRange(Core.UsuallyCommon.Extensions.EnumToList(firstenum).ToArray());
                    
                    textBox.SelectedText = val;
                }
                else if ("Boolean" == proprety.PropertyType.Name)
                {
                    textBox = new CheckBox() { Name = $"{proprety.Name}", Checked = val.ToBool() };
                }
                else
                {
                    textBox = new TextBox() { Name = $"{proprety.Name}", Text = val, Width = 400, Multiline = true, Height = 60, ScrollBars = ScrollBars.Both };
                }

                if (proprety.Name.ToUpper() == "ID")
                    textBox.ReadOnly = true;

                label.Location = new Point(startIndexX, startIndexY);
                textBox.Location = new Point(label.Location.X + 100, label.Location.Y);

                this.Controls.Add(label);
                this.Controls.Add(textBox);
                startIndexY += 70;
            }

            Button btnSave = new Button() { Text = ButtonTextEnum.Save.ToStringExtension() };
            Button btnCanel = new Button() { Text = ButtonTextEnum.Canel.ToStringExtension() };

            btnSave.Click += BtnSave_Click;
            btnCanel.Click += BtnCanel_Click;
            btnSave.Location = new Point(startIndexX, startIndexY);
            btnCanel.Location = new Point(startIndexX + 80, startIndexY);

            this.Height = 700;
            this.AutoScroll = true;
            this.Width = 700;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = type.Name;

            this.Controls.Add(btnSave);
            this.Controls.Add(btnCanel);
        }

        private void BtnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetPropertyInfo(PropertyInfo property, dynamic value)
        {
            if (enumList.Any(x => x.Name == property.PropertyType.Name))
            {
                var firstenum = enumList.FirstOrDefault(x => x.Name == property.PropertyType.Name);
                var intValue = firstenum.EnumToDictionaryReverse().First(x => x.Key == value).Value.ToInt32();
                property.SetValue(objectself, intValue, null);
            }
            else
            {
                property.SetValue(objectself, Convert.ChangeType(value, property.PropertyType), null);

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // get value save
            foreach (var item in this.Controls)
            {
                dynamic tb = string.Empty;
                
                switch(item.GetType().Name)
                {
                    case "ComboBox":
                        tb = (item as ComboBox); 
                        SetPropertyInfo(objectself.GetType().GetProperties().FirstOrDefault(x => x.Name == tb.Name), tb.Text);
                        break;
                    case "CheckBox":
                        tb = (item as CheckBox); 
                        SetPropertyInfo(objectself.GetType().GetProperties().FirstOrDefault(x => x.Name == tb.Name), tb.Checked);
                        break;
                    case "TextBox":
                        tb = (item as TextBox); 
                        SetPropertyInfo(objectself.GetType().GetProperties().FirstOrDefault(x => x.Name == tb.Name), tb.Text);
                        break;
                } 
            }
            DbEntityEntry entry = db.Entry<T>(objectself);
            var entity = db.Set(typeof(T)).Attach(objectself);
            entry.State = IsInsert ? EntityState.Added : EntityState.Modified;
            db.SaveChanges();
            this.Close();
        }

        DefaultSqlite db = new DefaultSqlite();
    }
}

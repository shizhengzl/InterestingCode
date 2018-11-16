using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFGenerator
{
    public class PanelExtension<T> : Panel where T : class, new()
    {
        public GridViewExtension<T> gridView { get; set; }

        public ToolScriptExtension<T> toolScript { get; set; }
        public PanelExtension(GeneartorTools tools)
        {
            this.Dock = DockStyle.Fill;
            toolScript = new ToolScriptExtension<T>(this, tools);
            gridView = new GridViewExtension<T>(tools);

            Panel pt = new Panel() { Height = 40 };
            Panel ptg = new Panel();
            pt.Controls.Add(toolScript);
            ptg.Controls.Add(gridView);

            this.Controls.Add(ptg);
            this.Controls.Add(pt);
            pt.Dock = DockStyle.Top;
            ptg.Dock = DockStyle.Fill;

        }
    }
}

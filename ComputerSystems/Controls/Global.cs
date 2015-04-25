using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerSystems.Controls
{
    public partial class Global : UserControl
    {
        public Global()
        {
            InitializeComponent();
            textBox1.Tag = "Current tasks count";
            textBox2.Tag = "Number of Processors in System";
            textBox3.Tag = "General power of the System";
            textBox4.Tag = "General complexity of the System";
            textBox5.Tag = "Avarage complexity of the System";
            textBox6.Tag = "Avarage power of the System";
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ToolTip tp = new ToolTip();
                    tp.SetToolTip(item, item.Tag.ToString());
                    item.Tag = tp;
                    item.MouseHover += new System.EventHandler(show_ToolTip);
                }
            }
        }

        private void show_ToolTip(object sender, EventArgs e)
        {
            ToolTip tp = (ToolTip)(sender as TextBox).Tag;
            tp.ShowAlways = true;
        }

    }
}

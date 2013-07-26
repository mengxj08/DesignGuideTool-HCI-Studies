using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GuideTool
{
    public partial class GuidingTool : Form
    {
        int state;//record the state for different viewers

        public GuidingTool()
        {
            InitializeComponent();
			MessageBox.Show("Test Git");
        }

        private void GuidingTool_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
//private System.Windows.Forms.TextBox textBox1 is in the Main Window.
    
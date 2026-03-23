using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class frmClientDashboard : Form
    {
        public frmClientDashboard()
        {
            InitializeComponent();
        }

        private void frmClientDashboard_Load(object sender, EventArgs e)
        {

        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 25;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnlSearch.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnlSearch.Width - radius, pnlSearch.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnlSearch.Height - radius, radius, radius, 90, 90);
            pnlSearch.Region = new Region(path);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

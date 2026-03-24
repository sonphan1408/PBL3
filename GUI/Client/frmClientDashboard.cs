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
        private string username;

        ucClientHome home;
        ucFinancials financials;
        ucHistory history;
        ucInvoicePayment invoice;
        ucNotifications notifications;
        ucTransfer transfer;

        public frmClientDashboard(string username)
        {
            InitializeComponent();
            home = new ucClientHome();
            financials = new ucFinancials();
            history = new ucHistory();
            invoice = new ucInvoicePayment();
            notifications = new ucNotifications();
            transfer = new ucTransfer();
            this.username = username;
        }

        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            addUserControl(home);
        }

        private void btnFinancials_Click(object sender, EventArgs e)
        {
            addUserControl(financials);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            addUserControl(history);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            addUserControl(transfer);
        }

        private void frmClientDashboard_Load(object sender, EventArgs e) { }
        private void pnlLogo_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void pnlMain_Paint(object sender, PaintEventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }

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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Bổ sung thêm thư viện này để dùng được GraphicsPath
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class frmClientDashboard : Form
    {
        // Khai báo các biến UserControl (nếu file Designer của bạn chưa có)
        ucClientHome home;
        ucFinancials financials;
        ucHistory history;
        ucInvoicePayment invoice;
        ucNotifications notifications;
        ucTransfer transfer;

        // Parameterless constructor required by designer and other call sites
        public frmClientDashboard()
        {
            InitializeComponent(); // Lệnh này giúp vẽ pnlMain và các nút ra màn hình

            // Khởi tạo các trang con ở đây, sau khi giao diện chính đã load xong
            home = new ucClientHome();
            financials = new ucFinancials();
            history = new ucHistory();
            invoice = new ucInvoicePayment();
            notifications = new ucNotifications();
            transfer = new ucTransfer();
        }

        // Constructor that accepts username; chains to parameterless to reuse initialization
        public frmClientDashboard(string username) : this()
        {
            // You can use the username here (e.g. show it on the UI or store it)
            // lblPageTitle.Text = username; // example if you want to display it
        }

        // Hàm tráo đổi UserControl của bạn (Đã chuẩn)
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- CÁC SỰ KIỆN NÚT BẤM ---
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
        private void btnPayment_Click(object sender, EventArgs e)
        {
            addUserControl(invoice);
        }

        // --- CÁC SỰ KIỆN KHÁC CỦA BẠN (GIỮ NGUYÊN) ---
        private void frmClientDashboard_Load(object sender, EventArgs e) { }
        private void pnlLogo_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void pnlMain_Paint(object sender, PaintEventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }

        // Code bo góc thanh tìm kiếm của bạn (Đã chuẩn)
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

        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button8_Click(object sender, EventArgs e) { }
    }
}
using BLL.Services;
using DTO.Models;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class ucInvoicePayment : UserControl
    {
        // 1. Khai báo tầng Service để gọi các hàm nghiệp vụ
        private PaymentService _paymentService = new PaymentService();

        // 2. Cầu nối Delegate dùng để tráo đổi UserControl trên Form chính
        public Action<UserControl> NavigateTo { get; set; }

        public ucInvoicePayment()
        {
            InitializeComponent();
            // Đăng ký sự kiện Load cho UserControl
            this.Load += ucInvoicePayment_Load;
        }

        private void ucInvoicePayment_Load(object sender, EventArgs e)
        {
            // Tải toàn bộ các khoản thanh toán gần đây (tất cả dịch vụ) lên danh sách
            LoadAllPendingInvoices();
        }

        // 3. SỰ KIỆN CHUYỂN TRANG CHO CÁC NÚT DỊCH VỤ
        private void btnElectricity_Click(object sender, EventArgs e)
        {
            ucPaymentElectricity ucElectricity = new ucPaymentElectricity();

            // Chữ 'T' phải viết hoa cho đúng với khai báo Action bên trên
            ucElectricity.NavigateTo = this.NavigateTo;

            // Gọi hàm Delegate để yêu cầu Form mẹ đổi sang giao diện Điện
            NavigateTo?.Invoke(ucElectricity);          
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            ucPaymentWater ucWater = new ucPaymentWater();

            // Chữ 'T' phải viết hoa cho đúng với khai báo Action bên trên
            ucWater.NavigateTo = this.NavigateTo;

            // Gọi hàm Delegate để yêu cầu Form mẹ đổi sang giao diện Nước
            NavigateTo?.Invoke(ucWater);
        }

        private void btnInternet_Click(object sender, EventArgs e)
        {
            ucPaymentInternet ucInternet = new ucPaymentInternet();

            // Chữ 'T' phải viết hoa cho đúng với khai báo Action bên trên
            ucInternet.NavigateTo = this.NavigateTo;

            // Gọi hàm Delegate để yêu cầu Form mẹ đổi sang giao diện Internet
            NavigateTo?.Invoke(ucInternet);
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            ucPaymentPhone ucPhone = new ucPaymentPhone();

            // Chữ 'T' phải viết hoa cho đúng với khai báo Action bên trên
            ucPhone.NavigateTo = this.NavigateTo;

            // Gọi hàm Delegate để yêu cầu Form mẹ đổi sang giao diện Điện thoại
            NavigateTo?.Invoke(ucPhone);
        }


        // 4. HÀM XỬ LÝ GIAO DIỆN DANH SÁCH BÊN PHẢI
        private void LoadAllPendingInvoices()
        {
            // Giả sử panel bên phải của bạn tên là pnlUnpaidList (hoặc pnlRecentInvoices)
            pnlUnpaidList.Controls.Clear();

            try
            {
                string currentAccountNumber = GUI.Session.UserSession.CurrentUser.AccountNumber;
                List<InvoiceDTO> allInvoices = new List<InvoiceDTO>();

                // Kéo dữ liệu của cả Điện (1), Nước (2), Internet (3) gộp chung vào 1 danh sách
                var electricity = _paymentService.GetPendingInvoices(currentAccountNumber, 1);
                var water = _paymentService.GetPendingInvoices(currentAccountNumber, 2);
                var internet = _paymentService.GetPendingInvoices(currentAccountNumber, 3);

                if (electricity != null) allInvoices.AddRange(electricity);
                if (water != null) allInvoices.AddRange(water);
                if (internet != null) allInvoices.AddRange(internet);

                // Nếu không có nợ nào
                if (allInvoices.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Bạn không có khoản thanh toán nào gần đây.",
                        Font = new Font("Segoe UI", 10f, FontStyle.Italic),
                        ForeColor = Color.DimGray,
                        AutoSize = true,
                        Location = new Point(20, 20)
                    };
                    pnlUnpaidList.Controls.Add(lblEmpty);
                    return;
                }

                // Render danh sách thẻ
                int yPosition = 10;
                foreach (InvoiceDTO inv in allInvoices)
                {
                    KryptonGroup card = CreateInvoiceCard(inv, yPosition);
                    pnlUnpaidList.Controls.Add(card);
                    yPosition += card.Height + 15;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private KryptonGroup CreateInvoiceCard(InvoiceDTO invoice, int yPos)
        {
            KryptonGroup card = new KryptonGroup();
            card.Size = new Size(pnlUnpaidList.Width - 25, 110);
            card.Location = new Point(10, yPos);

            card.StateCommon.Border.Rounding = 12;
            card.StateCommon.Border.Color1 = Color.LightGray;
            card.StateCommon.Back.Color1 = Color.White;

            Label lblProvider = new Label
            {
                Text = invoice.ProviderName,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(21, 41, 88),
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblCode = new Label
            {
                Text = $"Mã KH: {invoice.BillCode}",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(15, 40),
                AutoSize = true
            };

            string formattedDate = invoice.DueDate.HasValue ? invoice.DueDate.Value.ToString("dd/MM/yyyy") : "Không giới hạn";
            Label lblDate = new Label
            {
                Text = $"Hạn: {formattedDate}",
                Font = new Font("Segoe UI", 9f, FontStyle.Italic),
                ForeColor = Color.DarkOrange,
                Location = new Point(15, 68),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = invoice.Amount.ToString("N0") + " VND",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.Crimson,
                Location = new Point(card.Width - 160, 40),
                AutoSize = true,
                TextAlign = ContentAlignment.TopRight
            };

            card.Panel.Controls.Add(lblProvider);
            card.Panel.Controls.Add(lblCode);
            card.Panel.Controls.Add(lblDate);
            card.Panel.Controls.Add(lblPrice);

            return card;
        }
    }
}
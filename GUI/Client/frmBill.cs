using System;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace GUI.Client
{
    public partial class frmBill : Form
    {
        // Padding nội dung bên trong textbox (khoảng cách an toàn để chữ không sát mép)
        private const int INNER_PADDING = 20;

        public frmBill(
            decimal amount,
            string senderAccount,
            string senderName,
            string recipientAccount,
            string recipientName,
            string notes = "Chuyển tiền")
        {
            InitializeComponent();

            // 2. ĐỔ DỮ LIỆU
            kryptonTextBox1.Text = amount.ToString("N0") + " VND";
            kryptonTextBox2.Text = senderAccount;
            kryptonTextBox3.Text = senderName;
            kryptonTextBox4.Text = recipientAccount;
            kryptonTextBox5.Text = recipientName;
            kryptonTextBox6.Text = DateTime.Now.ToString("HH:mm") + " - " + DateTime.Now.ToString("dd/MM/yyyy");
            kryptonTextBox7.Text = "Miễn phí";
            kryptonTextBox8.Text = string.IsNullOrWhiteSpace(notes) ? "Chuyển tiền" : notes;

            // 3. AUTO-RESIZE: Kéo giãn khung text nếu tên/số tài khoản quá dài
            this.Load += (s, e) =>
            {
                AutoResizeTextBox(kryptonTextBox2);
                AutoResizeTextBox(kryptonTextBox3);
                AutoResizeTextBox(kryptonTextBox4);
                AutoResizeTextBox(kryptonTextBox5);
                AutoResizeTextBox(kryptonTextBox6);
                AutoResizeTextBox(kryptonTextBox7);
                AutoResizeTextBox(kryptonTextBox8);
            };

            // 4. NÚT ĐÓNG
            kryptonButton1.Click += (s, e) => this.Close();
        }

        /// <summary>
        /// Tính chiều rộng cần thiết cho text, nếu lớn hơn width hiện tại
        /// thì mở rộng sang trái (tự động lấy lề phải hiện tại để giữ cố định).
        /// </summary>
        private void AutoResizeTextBox(KryptonTextBox tb)
        {
            // Lấy tọa độ cạnh phải HIỆN TẠI của textbox (Bất chấp mọi độ phân giải màn hình)
            int currentRightEdge = tb.Right;

            // Đo độ rộng thực của chuỗi text với font đang dùng
            Font font = tb.StateCommon.Content.Font ?? tb.Font;
            int textWidth = TextRenderer.MeasureText(tb.Text, font).Width + INNER_PADDING;
            // Chỉ mở rộng nếu text rộng hơn box hiện tại
            int newWidth = Math.Max(tb.Width, textWidth);

            if (newWidth != tb.Width)
            {
                // Dịch X sang trái dựa trên cạnh phải thực tế để lề phải không đổi
                int newX = currentRightEdge - newWidth;
                tb.Location = new Point(newX, tb.Location.Y);
                tb.Width = newWidth;
            }
        }

        private void kryptonTextBox2_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void kryptonTextBox5_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
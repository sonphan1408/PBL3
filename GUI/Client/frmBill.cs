using System;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace GUI.Client
{
    public partial class frmBill : Form
    {
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

            kryptonTextBox1.Text = amount.ToString("N0") + " VND";
            kryptonTextBox2.Text = senderAccount;
            kryptonTextBox3.Text = senderName;
            kryptonTextBox4.Text = recipientAccount;
            kryptonTextBox5.Text = recipientName;
            kryptonTextBox6.Text = DateTime.Now.ToString("HH:mm") + " - " + DateTime.Now.ToString("dd/MM/yyyy");
            kryptonTextBox7.Text = "Miễn phí";
            kryptonTextBox8.Text = string.IsNullOrWhiteSpace(notes) ? "Chuyển tiền" : notes;

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

            kryptonButton1.Click += (s, e) => this.Close();
        }

        private void AutoResizeTextBox(KryptonTextBox tb)
        {
            int currentRightEdge = tb.Right;

            Font font = tb.StateCommon.Content.Font ?? tb.Font;
            int textWidth = TextRenderer.MeasureText(tb.Text, font).Width + INNER_PADDING;
            int newWidth = Math.Max(tb.Width, textWidth);

            if (newWidth != tb.Width)
            {
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
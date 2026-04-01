using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class ucClientHome : UserControl
    {
        // Sample data for balance history
        private List<decimal> balanceData = new List<decimal> { 600, 500, 400, 400, 500, 400, 500, 600, 1000 };
        private List<string> dateLabels = new List<string> { "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025", "06/2025" };

        public ucClientHome()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Populate sample transaction history
            lstHistory.Items.Add("Deposit");
            lstHistory.Items.Add("$500.00");
            lstHistory.Items.Add("2025-06-12");
            lstHistory.Items.Add("");
            lstHistory.Items.Add("Transfer");
            lstHistory.Items.Add("$80.00");
            lstHistory.Items.Add("2025-06-11");
            lstHistory.Items.Add("");
            lstHistory.Items.Add("Transfer");
            lstHistory.Items.Add("$50.00");
            lstHistory.Items.Add("2025-06-10");

            // Populate sample savings items
            lstSavingsItems.Items.Add("House                    $1,800.00");
            lstSavingsItems.Items.Add("Car                        $500.00");
            lstSavingsItems.Items.Add("Education              $1,200.00");

            // Setup button click event
            btnTransfer.Click += BtnTransfer_Click;
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTransferAmount.Text))
            {
                MessageBox.Show($"Transfer of {txtTransferAmount.Text} initiated successfully!", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTransferAmount.Clear();
            }
            else
            {
                MessageBox.Show("Please enter an amount to transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Properties to allow binding/updating data from outside
        public string UserName
        {
            get { return lblUserName.Text; }
            set { lblUserName.Text = value; }
        }

        public string BalanceAmount
        {
            get { return lblBalanceAmount.Text; }
            set { lblBalanceAmount.Text = value; }
        }

        public string SavingsAmount
        {
            get { return lblSavingsAmount.Text; }
            set { lblSavingsAmount.Text = value; }
        }

        public string LoansAmount
        {
            get { return lblLoansAmount.Text; }
            set { lblLoansAmount.Text = value; }
        }

        public string CardNumber
        {
            get { return lblCardNumber.Text; }
            set { lblCardNumber.Text = value; }
        }

        private void pnlBalanceChart_Paint(object sender, PaintEventArgs e)
        {
            if (balanceData == null || balanceData.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Panel panel = sender as Panel;
            if (panel == null) return;

            int width = panel.Width;
            int height = panel.Height;

            // Padding
            int paddingLeft = 50;
            int paddingRight = 20;
            int paddingTop = 30;
            int paddingBottom = 40;

            int chartWidth = width - paddingLeft - paddingRight;
            int chartHeight = height - paddingTop - paddingBottom;

            // Find min and max values
            decimal maxValue = balanceData.Max();
            decimal minValue = balanceData.Min();
            decimal valueRange = maxValue - minValue;
            if (valueRange == 0) valueRange = 1;

            // Draw Y-axis labels and grid lines
            Brush gridBrush = new SolidBrush(Color.FromArgb(220, 220, 220));
            Brush labelBrush = new SolidBrush(Color.FromArgb(150, 150, 150));
            Font labelFont = new Font("Arial", 8);

            int gridLines = 5;
            for (int i = 0; i <= gridLines; i++)
            {
                decimal value = minValue + (valueRange / gridLines) * i;
                int y = paddingTop + chartHeight - (int)((value - minValue) / valueRange * chartHeight);

                // Draw grid line
                g.DrawLine(new Pen(gridBrush), paddingLeft, y, width - paddingRight, y);

                // Draw Y-axis label
                string label = ((int)value).ToString();
                SizeF labelSize = g.MeasureString(label, labelFont);
                g.DrawString(label, labelFont, labelBrush, paddingLeft - labelSize.Width - 5, y - labelSize.Height / 2);
            }

            // Draw X-axis
            g.DrawLine(new Pen(Color.FromArgb(100, 100, 100), 2), paddingLeft, paddingTop + chartHeight, width - paddingRight, paddingTop + chartHeight);

            // Draw data points and lines
            Pen chartLinePen = new Pen(Color.FromArgb(30, 144, 255), 2);
            Brush pointBrush = new SolidBrush(Color.FromArgb(30, 144, 255));

            List<PointF> points = new List<PointF>();

            for (int i = 0; i < balanceData.Count; i++)
            {
                decimal value = balanceData[i];
                int x = paddingLeft + (int)(i * (double)chartWidth / (balanceData.Count - 1));
                int y = paddingTop + chartHeight - (int)((value - minValue) / valueRange * chartHeight);

                points.Add(new PointF(x, y));
            }

            // Draw connecting lines
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(chartLinePen, points[i], points[i + 1]);
            }

            // Draw points
            for (int i = 0; i < points.Count; i++)
            {
                g.FillEllipse(pointBrush, points[i].X - 4, points[i].Y - 4, 8, 8);
                g.DrawEllipse(new Pen(Color.White, 2), points[i].X - 4, points[i].Y - 4, 8, 8);
            }

            // Draw X-axis labels (Month)
            for (int i = 0; i < dateLabels.Count; i++)
            {
                int x = paddingLeft + (int)(i * (double)chartWidth / (balanceData.Count - 1));
                string label = dateLabels[i];
                SizeF labelSize = g.MeasureString(label, labelFont);
                g.DrawString(label, labelFont, labelBrush, x - labelSize.Width / 2, paddingTop + chartHeight + 5);
            }

            // Cleanup
            chartLinePen.Dispose();
            pointBrush.Dispose();
            gridBrush.Dispose();
            labelBrush.Dispose();
            labelFont.Dispose();
        }

        private void lblViewAll1_Click(object sender, EventArgs e)
        {

        }

        private void pnlBalanceCards_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBalanceHistoryTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblMoreBanking_Click(object sender, EventArgs e)
        {

        }

        private void ucClientHome_Load(object sender, EventArgs e)
        {

        }

        private void pnlMyBalance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHistoryTransactions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTransfer_Click_1(object sender, EventArgs e)
        {

        }

        private void LLHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}

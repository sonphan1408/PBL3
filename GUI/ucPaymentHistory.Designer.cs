namespace GUI
{
    partial class ucPaymentHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlInterestRates = new System.Windows.Forms.Panel();
            this.lblInterestRatesTitle = new System.Windows.Forms.Label();
            this.pnlDigitalSavings = new System.Windows.Forms.Panel();
            this.lblDigitalSavingsAmount = new System.Windows.Forms.Label();
            this.lblDigitalSavings = new System.Windows.Forms.Label();
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.dgvPaymentHistory = new System.Windows.Forms.DataGridView();
            this.pnlTableHeader = new System.Windows.Forms.Panel();
            this.lblPaymentFor = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBillingTo = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            this.pnlInterestRates.SuspendLayout();
            this.pnlDigitalSavings.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.pnlTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlInterestRates);
            this.pnlTop.Controls.Add(this.pnlDigitalSavings);
            this.pnlTop.Controls.Add(this.pnlBalance);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTop.Size = new System.Drawing.Size(995, 140);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlInterestRates
            // 
            this.pnlInterestRates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(99)))));
            this.pnlInterestRates.Controls.Add(this.lblInterestRatesTitle);
            this.pnlInterestRates.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInterestRates.Location = new System.Drawing.Point(530, 20);
            this.pnlInterestRates.Name = "pnlInterestRates";
            this.pnlInterestRates.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInterestRates.Size = new System.Drawing.Size(445, 100);
            this.pnlInterestRates.TabIndex = 2;
            // 
            // lblInterestRatesTitle
            // 
            this.lblInterestRatesTitle.AutoSize = true;
            this.lblInterestRatesTitle.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterestRatesTitle.ForeColor = System.Drawing.Color.White;
            this.lblInterestRatesTitle.Location = new System.Drawing.Point(10, 29);
            this.lblInterestRatesTitle.Name = "lblInterestRatesTitle";
            this.lblInterestRatesTitle.Size = new System.Drawing.Size(347, 29);
            this.lblInterestRatesTitle.TabIndex = 0;
            this.lblInterestRatesTitle.Text = "LÃI SUẤT THEO KỲ HẠN";
            // 
            // pnlDigitalSavings
            // 
            this.pnlDigitalSavings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(99)))));
            this.pnlDigitalSavings.Controls.Add(this.pictureBox1);
            this.pnlDigitalSavings.Controls.Add(this.lblDigitalSavingsAmount);
            this.pnlDigitalSavings.Controls.Add(this.lblDigitalSavings);
            this.pnlDigitalSavings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDigitalSavings.Location = new System.Drawing.Point(324, 20);
            this.pnlDigitalSavings.Name = "pnlDigitalSavings";
            this.pnlDigitalSavings.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDigitalSavings.Size = new System.Drawing.Size(333, 100);
            this.pnlDigitalSavings.TabIndex = 1;
            // 
            // lblDigitalSavingsAmount
            // 
            this.lblDigitalSavingsAmount.AutoSize = true;
            this.lblDigitalSavingsAmount.Font = new System.Drawing.Font("Times New Roman", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigitalSavingsAmount.ForeColor = System.Drawing.Color.White;
            this.lblDigitalSavingsAmount.Location = new System.Drawing.Point(101, 62);
            this.lblDigitalSavingsAmount.Name = "lblDigitalSavingsAmount";
            this.lblDigitalSavingsAmount.Size = new System.Drawing.Size(67, 25);
            this.lblDigitalSavingsAmount.TabIndex = 1;
            this.lblDigitalSavingsAmount.Text = "$2000";
            // 
            // lblDigitalSavings
            // 
            this.lblDigitalSavings.AutoSize = true;
            this.lblDigitalSavings.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigitalSavings.ForeColor = System.Drawing.Color.White;
            this.lblDigitalSavings.Location = new System.Drawing.Point(101, 17);
            this.lblDigitalSavings.Name = "lblDigitalSavings";
            this.lblDigitalSavings.Size = new System.Drawing.Size(175, 29);
            this.lblDigitalSavings.TabIndex = 0;
            this.lblDigitalSavings.Text = "Tiết kiệm số";
            // 
            // pnlBalance
            // 
            this.pnlBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(99)))));
            this.pnlBalance.Controls.Add(this.pictureBox2);
            this.pnlBalance.Controls.Add(this.lblBalanceAmount);
            this.pnlBalance.Controls.Add(this.lblBalance);
            this.pnlBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBalance.Location = new System.Drawing.Point(20, 20);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBalance.Size = new System.Drawing.Size(304, 100);
            this.pnlBalance.TabIndex = 0;
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.Font = new System.Drawing.Font("Times New Roman", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.lblBalanceAmount.Location = new System.Drawing.Point(120, 62);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(67, 25);
            this.lblBalanceAmount.TabIndex = 1;
            this.lblBalanceAmount.Text = "$1459";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Times New Roman", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(120, 17);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(97, 29);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Số dư";
            // 
            // pnlTable
            // 
            this.pnlTable.Controls.Add(this.dgvPaymentHistory);
            this.pnlTable.Controls.Add(this.pnlTableHeader);
            this.pnlTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTable.Location = new System.Drawing.Point(0, 140);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTable.Size = new System.Drawing.Size(995, 559);
            this.pnlTable.TabIndex = 1;
            // 
            // dgvPaymentHistory
            // 
            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AllowUserToDeleteRows = false;
            this.dgvPaymentHistory.AllowUserToOrderColumns = true;
            this.dgvPaymentHistory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentHistory.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPaymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaymentHistory.Location = new System.Drawing.Point(20, 60);
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPaymentHistory.RowHeadersWidth = 56;
            this.dgvPaymentHistory.RowTemplate.Height = 24;
            this.dgvPaymentHistory.Size = new System.Drawing.Size(955, 479);
            this.dgvPaymentHistory.TabIndex = 1;
            // 
            // pnlTableHeader
            // 
            this.pnlTableHeader.BackColor = System.Drawing.Color.White;
            this.pnlTableHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableHeader.Controls.Add(this.lblPaymentFor);
            this.pnlTableHeader.Controls.Add(this.lblAmount);
            this.pnlTableHeader.Controls.Add(this.lblPaymentDate);
            this.pnlTableHeader.Controls.Add(this.lblStatus);
            this.pnlTableHeader.Controls.Add(this.lblBillingTo);
            this.pnlTableHeader.Controls.Add(this.lblInvoice);
            this.pnlTableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTableHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlTableHeader.Name = "pnlTableHeader";
            this.pnlTableHeader.Size = new System.Drawing.Size(955, 40);
            this.pnlTableHeader.TabIndex = 0;
            // 
            // lblPaymentFor
            // 
            this.lblPaymentFor.AutoSize = true;
            this.lblPaymentFor.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaymentFor.Location = new System.Drawing.Point(650, 10);
            this.lblPaymentFor.Name = "lblPaymentFor";
            this.lblPaymentFor.Size = new System.Drawing.Size(130, 24);
            this.lblPaymentFor.TabIndex = 5;
            this.lblPaymentFor.Text = "Nội dung";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(530, 10);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(83, 24);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Số tiền";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaymentDate.Location = new System.Drawing.Point(380, 10);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(141, 24);
            this.lblPaymentDate.TabIndex = 3;
            this.lblPaymentDate.Text = "Ngày thanh toán";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(290, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 24);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái";
            // 
            // lblBillingTo
            // 
            this.lblBillingTo.AutoSize = true;
            this.lblBillingTo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblBillingTo.Location = new System.Drawing.Point(150, 10);
            this.lblBillingTo.Name = "lblBillingTo";
            this.lblBillingTo.Size = new System.Drawing.Size(98, 24);
            this.lblBillingTo.TabIndex = 1;
            this.lblBillingTo.Text = "Đơn vị nhận";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.Location = new System.Drawing.Point(10, 10);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(77, 24);
            this.lblInvoice.TabIndex = 0;
            this.lblInvoice.Text = "Mã hóa đơn";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.pig;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 70);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GUI.Properties.Resources.pig1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(15, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 70);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // ucPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucPaymentHistory";
            this.Size = new System.Drawing.Size(995, 699);
            this.pnlTop.ResumeLayout(false);
            this.pnlInterestRates.ResumeLayout(false);
            this.pnlInterestRates.PerformLayout();
            this.pnlDigitalSavings.ResumeLayout(false);
            this.pnlDigitalSavings.PerformLayout();
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.pnlTableHeader.ResumeLayout(false);
            this.pnlTableHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBalance;
        private System.Windows.Forms.Panel pnlDigitalSavings;
        private System.Windows.Forms.Panel pnlInterestRates;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBalanceAmount;
        private System.Windows.Forms.Label lblDigitalSavings;
        private System.Windows.Forms.Label lblDigitalSavingsAmount;
        private System.Windows.Forms.Label lblInterestRatesTitle;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Panel pnlTableHeader;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblBillingTo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPaymentFor;
        private System.Windows.Forms.DataGridView dgvPaymentHistory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
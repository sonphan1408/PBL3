namespace GUI
{
    partial class ucBalanceChanges
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeaderBalance = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.picPiggyBank = new System.Windows.Forms.PictureBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlTransactions = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeaderBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPiggyBank)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderBalance
            // 
            this.pnlHeaderBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(99)))));
            this.pnlHeaderBalance.Controls.Add(this.lblBalance);
            this.pnlHeaderBalance.Controls.Add(this.lblCurrentBalance);
            this.pnlHeaderBalance.Controls.Add(this.picPiggyBank);
            this.pnlHeaderBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderBalance.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderBalance.Name = "pnlHeaderBalance";
            this.pnlHeaderBalance.Size = new System.Drawing.Size(1094, 100);
            this.pnlHeaderBalance.TabIndex = 0;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(147, 50);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(83, 35);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "$0.00";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Times New Roman", 16.06154F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.White;
            this.lblCurrentBalance.Location = new System.Drawing.Point(148, 9);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(222, 35);
            this.lblCurrentBalance.TabIndex = 1;
            this.lblCurrentBalance.Text = "Số dư hiện tại";
            // 
            // picPiggyBank
            // 
            this.picPiggyBank.BackgroundImage = global::GUI.Properties.Resources.pig;
            this.picPiggyBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPiggyBank.Location = new System.Drawing.Point(40, 12);
            this.picPiggyBank.Name = "picPiggyBank";
            this.picPiggyBank.Size = new System.Drawing.Size(90, 82);
            this.picPiggyBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPiggyBank.TabIndex = 0;
            this.picPiggyBank.TabStop = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 100);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1094, 60);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtSearch.Location = new System.Drawing.Point(30, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 32);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(99)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(320, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 32);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.AutoScroll = true;
            this.pnlTransactions.BackColor = System.Drawing.Color.White;
            this.pnlTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTransactions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlTransactions.Location = new System.Drawing.Point(0, 160);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlTransactions.Size = new System.Drawing.Size(1094, 476);
            this.pnlTransactions.TabIndex = 2;
            this.pnlTransactions.WrapContents = false;
            // 
            // ucBalanceChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTransactions);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeaderBalance);
            this.Name = "ucBalanceChanges";
            this.Size = new System.Drawing.Size(1094, 636);
            this.Load += new System.EventHandler(this.ucBalanceChanges_Load);
            this.pnlHeaderBalance.ResumeLayout(false);
            this.pnlHeaderBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPiggyBank)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.PictureBox picPiggyBank;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel pnlTransactions;
    }
}
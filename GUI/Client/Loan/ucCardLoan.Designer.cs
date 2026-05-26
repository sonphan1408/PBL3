namespace GUI.Client.Loan
{
    partial class ucCardLoan
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
        /// the contents of this method call.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCardLoan));
            this.lblLoanAmount = new System.Windows.Forms.Label();
            this.lblContractID = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblRemainingBalance = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblTermMonth = new System.Windows.Forms.Label();
            this.btnFinalSettlement = new Krypton.Toolkit.KryptonButton();
            this.btnDetail = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblLoanAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoanAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblLoanAmount.Location = new System.Drawing.Point(188, 80);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(205, 28);
            this.lblLoanAmount.TabIndex = 0;
            this.lblLoanAmount.Text = "Số tiền vay ban đầu:";
            // 
            // lblContractID
            // 
            this.lblContractID.AutoSize = true;
            this.lblContractID.BackColor = System.Drawing.Color.Transparent;
            this.lblContractID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblContractID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblContractID.Location = new System.Drawing.Point(247, 43);
            this.lblContractID.Name = "lblContractID";
            this.lblContractID.Size = new System.Drawing.Size(115, 23);
            this.lblContractID.TabIndex = 1;
            this.lblContractID.Text = "Mã số vay nợ:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStartDate.Location = new System.Drawing.Point(546, 14);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(91, 23);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Trạng thái:";
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainingBalance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRemainingBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRemainingBalance.Location = new System.Drawing.Point(189, 117);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(147, 25);
            this.lblRemainingBalance.TabIndex = 3;
            this.lblRemainingBalance.Text = "Tổng nợ còn lại:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDueDate.Location = new System.Drawing.Point(197, 190);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(196, 23);
            this.lblDueDate.TabIndex = 4;
            this.lblDueDate.Text = "Ngày đến hạn tiếp theo:";
            // 
            // lblTermMonth
            // 
            this.lblTermMonth.AutoSize = true;
            this.lblTermMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblTermMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTermMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTermMonth.Location = new System.Drawing.Point(189, 151);
            this.lblTermMonth.Name = "lblTermMonth";
            this.lblTermMonth.Size = new System.Drawing.Size(133, 23);
            this.lblTermMonth.TabIndex = 5;
            this.lblTermMonth.Text = "Tổng nợ còn lại:";
            this.lblTermMonth.Click += new System.EventHandler(this.lblTermMonth_Click);
            // 
            // btnFinalSettlement
            // 
            this.btnFinalSettlement.Location = new System.Drawing.Point(456, 190);
            this.btnFinalSettlement.Name = "btnFinalSettlement";
            this.btnFinalSettlement.Size = new System.Drawing.Size(171, 44);
            this.btnFinalSettlement.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnFinalSettlement.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnFinalSettlement.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalSettlement.StateCommon.Back.Image")));
            this.btnFinalSettlement.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnFinalSettlement.StateCommon.Border.Rounding = 20F;
            this.btnFinalSettlement.TabIndex = 12;
            this.btnFinalSettlement.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnFinalSettlement.Values.Text = "";
            this.btnFinalSettlement.Click += new System.EventHandler(this.btnFinalSettlement_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(553, 80);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(84, 44);
            this.btnDetail.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnDetail.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnDetail.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.StateCommon.Back.Image")));
            this.btnDetail.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnDetail.StateCommon.Border.Rounding = 20F;
            this.btnDetail.TabIndex = 13;
            this.btnDetail.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnDetail.Values.Text = "";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // ucCardLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.btnFinalSettlement);
            this.Controls.Add(this.lblTermMonth);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblRemainingBalance);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblContractID);
            this.Controls.Add(this.lblLoanAmount);
            this.Name = "ucCardLoan";
            this.Size = new System.Drawing.Size(700, 250);
            this.Load += new System.EventHandler(this.ucCardLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label lblContractID;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblRemainingBalance;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblTermMonth;
        private Krypton.Toolkit.KryptonButton btnFinalSettlement;
        private Krypton.Toolkit.KryptonButton btnDetail;
    }
}

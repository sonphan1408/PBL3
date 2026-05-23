namespace GUI.Client
{
    partial class ucNotifications
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlListArea = new System.Windows.Forms.Panel();
            this.pnlScrollList = new System.Windows.Forms.Panel();
            this.lblListHint = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlDetailCard = new System.Windows.Forms.Panel();
            this.picDetailIcon = new System.Windows.Forms.PictureBox();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblDetailTimeLabel = new System.Windows.Forms.Label();
            this.lblDetailTime = new System.Windows.Forms.Label();
            this.lblDetailContentLabel = new System.Windows.Forms.Label();
            this.lblDetailContent = new System.Windows.Forms.Label();
            this.lblNoDetail = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlListArea.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlDetailCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlListArea);
            this.pnlLeft.Controls.Add(this.pnlHeader);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(580, 700);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlListArea
            // 
            this.pnlListArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlListArea.Controls.Add(this.pnlScrollList);
            this.pnlListArea.Controls.Add(this.lblListHint);
            this.pnlListArea.Controls.Add(this.lblListTitle);
            this.pnlListArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListArea.Location = new System.Drawing.Point(0, 110);
            this.pnlListArea.Name = "pnlListArea";
            this.pnlListArea.Padding = new System.Windows.Forms.Padding(20, 15, 15, 15);
            this.pnlListArea.Size = new System.Drawing.Size(580, 590);
            this.pnlListArea.TabIndex = 1;
            // 
            // pnlScrollList
            // 
            this.pnlScrollList.AutoScroll = true;
            this.pnlScrollList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlScrollList.Location = new System.Drawing.Point(20, 70);
            this.pnlScrollList.Name = "pnlScrollList";
            this.pnlScrollList.Size = new System.Drawing.Size(540, 500);
            this.pnlScrollList.TabIndex = 2;
            // 
            // lblListHint
            // 
            this.lblListHint.AutoSize = true;
            this.lblListHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblListHint.ForeColor = System.Drawing.Color.Gray;
            this.lblListHint.Location = new System.Drawing.Point(20, 43);
            this.lblListHint.Name = "lblListHint";
            this.lblListHint.Size = new System.Drawing.Size(274, 23);
            this.lblListHint.TabIndex = 1;
            this.lblListHint.Text = "Nhấn vào thông báo để xem chi tiết";
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblListTitle.Location = new System.Drawing.Point(20, 15);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(188, 32);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Thông báo mới";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(580, 110);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(60, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông báo";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.White;
            this.lblSubTitle.Location = new System.Drawing.Point(10, 18);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(55, 72);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "🔔";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmpty
            // 
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmpty.ForeColor = System.Drawing.Color.Gray;
            this.lblEmpty.Location = new System.Drawing.Point(100, 200);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(340, 30);
            this.lblEmpty.TabIndex = 3;
            this.lblEmpty.Text = "Không có thông báo nào.";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.pnlDetailCard);
            this.pnlRight.Controls.Add(this.lblNoDetail);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(580, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(370, 700);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.BackColor = System.Drawing.Color.White;
            this.pnlDetailCard.Controls.Add(this.picDetailIcon);
            this.pnlDetailCard.Controls.Add(this.lblDetailTitle);
            this.pnlDetailCard.Controls.Add(this.lblDetailTimeLabel);
            this.pnlDetailCard.Controls.Add(this.lblDetailTime);
            this.pnlDetailCard.Controls.Add(this.lblDetailContentLabel);
            this.pnlDetailCard.Controls.Add(this.lblDetailContent);
            this.pnlDetailCard.Location = new System.Drawing.Point(20, 20);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Size = new System.Drawing.Size(320, 360);
            this.pnlDetailCard.TabIndex = 0;
            this.pnlDetailCard.Visible = false;
            // 
            // picDetailIcon
            // 
            this.picDetailIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.picDetailIcon.Location = new System.Drawing.Point(20, 20);
            this.picDetailIcon.Name = "picDetailIcon";
            this.picDetailIcon.Size = new System.Drawing.Size(50, 50);
            this.picDetailIcon.TabIndex = 0;
            this.picDetailIcon.TabStop = false;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(80, 28);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(220, 32);
            this.lblDetailTitle.TabIndex = 1;
            this.lblDetailTitle.Text = "Tiết kiệm";
            // 
            // lblDetailTimeLabel
            // 
            this.lblDetailTimeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailTimeLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDetailTimeLabel.Location = new System.Drawing.Point(20, 90);
            this.lblDetailTimeLabel.Name = "lblDetailTimeLabel";
            this.lblDetailTimeLabel.Size = new System.Drawing.Size(280, 24);
            this.lblDetailTimeLabel.TabIndex = 2;
            this.lblDetailTimeLabel.Text = "Thời gian thông báo";
            // 
            // lblDetailTime
            // 
            this.lblDetailTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetailTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDetailTime.Location = new System.Drawing.Point(20, 118);
            this.lblDetailTime.Name = "lblDetailTime";
            this.lblDetailTime.Size = new System.Drawing.Size(280, 24);
            this.lblDetailTime.TabIndex = 3;
            this.lblDetailTime.Text = "1 giờ trước";
            // 
            // lblDetailContentLabel
            // 
            this.lblDetailContentLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailContentLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDetailContentLabel.Location = new System.Drawing.Point(20, 160);
            this.lblDetailContentLabel.Name = "lblDetailContentLabel";
            this.lblDetailContentLabel.Size = new System.Drawing.Size(280, 24);
            this.lblDetailContentLabel.TabIndex = 4;
            this.lblDetailContentLabel.Text = "Nội dung thông báo";
            // 
            // lblDetailContent
            // 
            this.lblDetailContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetailContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDetailContent.Location = new System.Drawing.Point(20, 188);
            this.lblDetailContent.Name = "lblDetailContent";
            this.lblDetailContent.Size = new System.Drawing.Size(280, 140);
            this.lblDetailContent.TabIndex = 5;
            // 
            // lblNoDetail
            // 
            this.lblNoDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoDetail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNoDetail.ForeColor = System.Drawing.Color.Gray;
            this.lblNoDetail.Location = new System.Drawing.Point(20, 20);
            this.lblNoDetail.Name = "lblNoDetail";
            this.lblNoDetail.Size = new System.Drawing.Size(330, 660);
            this.lblNoDetail.TabIndex = 1;
            this.lblNoDetail.Text = "Chọn thông báo để xem chi tiết";
            this.lblNoDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "ucNotifications";
            this.Size = new System.Drawing.Size(950, 700);
            this.Load += new System.EventHandler(this.ucNotifications_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlListArea.ResumeLayout(false);
            this.pnlListArea.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlDetailCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDetailIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel pnlListArea;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblListHint;
        private System.Windows.Forms.Panel pnlScrollList;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.PictureBox picDetailIcon;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailTimeLabel;
        private System.Windows.Forms.Label lblDetailTime;
        private System.Windows.Forms.Label lblDetailContentLabel;
        private System.Windows.Forms.Label lblDetailContent;
        private System.Windows.Forms.Label lblNoDetail;
    }
}

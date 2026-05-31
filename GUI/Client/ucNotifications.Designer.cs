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
            this.lblEmpty = new System.Windows.Forms.Label();
            this.pnlDetailCard = new System.Windows.Forms.FlowLayoutPanel();
            this.picDetailIcon = new System.Windows.Forms.PictureBox();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblDetailTimeLabel = new System.Windows.Forms.Label();
            this.lblDetailTime = new System.Windows.Forms.Label();
            this.lblDetailContentLabel = new System.Windows.Forms.Label();
            this.lblDetailContent = new System.Windows.Forms.Label();
            this.pnlScrollList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDetailCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailIcon)).BeginInit();
            this.SuspendLayout();
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
            // pnlDetailCard
            // 
            this.pnlDetailCard.BackColor = System.Drawing.Color.White;
            this.pnlDetailCard.Controls.Add(this.picDetailIcon);
            this.pnlDetailCard.Controls.Add(this.lblDetailTitle);
            this.pnlDetailCard.Controls.Add(this.lblDetailTimeLabel);
            this.pnlDetailCard.Controls.Add(this.lblDetailTime);
            this.pnlDetailCard.Controls.Add(this.lblDetailContentLabel);
            this.pnlDetailCard.Controls.Add(this.lblDetailContent);
            this.pnlDetailCard.Location = new System.Drawing.Point(1064, 179);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Size = new System.Drawing.Size(390, 450);
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
            this.lblDetailContent.Size = new System.Drawing.Size(341, 262);
            this.lblDetailContent.TabIndex = 5;
            // 
            // pnlScrollList
            // 
            this.pnlScrollList.AutoScroll = true;
            this.pnlScrollList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlScrollList.Location = new System.Drawing.Point(75, 207);
            this.pnlScrollList.Name = "pnlScrollList";
            this.pnlScrollList.Size = new System.Drawing.Size(834, 528);
            this.pnlScrollList.TabIndex = 2;
            this.pnlScrollList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlScrollList.WrapContents = false;
            // 
            // ucNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GUI.Properties.Resources._5e8d3067_e393_482c_bd98_9ba6150ac11e;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlScrollList);
            this.Controls.Add(this.pnlDetailCard);
            this.Name = "ucNotifications";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucNotifications_Load);
            this.pnlDetailCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDetailIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Panel pnlDetailCard;
        private System.Windows.Forms.PictureBox picDetailIcon;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailTimeLabel;
        private System.Windows.Forms.Label lblDetailTime;
        private System.Windows.Forms.Label lblDetailContentLabel;
        private System.Windows.Forms.Label lblDetailContent;
        private System.Windows.Forms.FlowLayoutPanel pnlScrollList;
    }
}

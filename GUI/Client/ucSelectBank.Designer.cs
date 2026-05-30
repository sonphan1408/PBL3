namespace GUI.Client
{
    partial class ucSelectBank
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
            this.pnlBankList = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnlBankList
            // 
            this.pnlBankList.AutoScroll = true;
            this.pnlBankList.BackColor = System.Drawing.Color.White;
            this.pnlBankList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlBankList.Location = new System.Drawing.Point(3, 36);
            this.pnlBankList.Name = "pnlBankList";
            this.pnlBankList.Size = new System.Drawing.Size(374, 214);
            this.pnlBankList.TabIndex = 1;
            this.pnlBankList.WrapContents = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ucSelectBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBankList);
            this.Controls.Add(this.txtSearch);
            this.Name = "ucSelectBank";
            this.Size = new System.Drawing.Size(380, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBankList;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

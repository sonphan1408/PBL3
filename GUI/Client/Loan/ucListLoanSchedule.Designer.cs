namespace GUI.Client.Loan
{
    partial class ucListLoanSchedule
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
            this.dgvLoanSchedules = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoanSchedules
            // 
            this.dgvLoanSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanSchedules.Location = new System.Drawing.Point(64, 96);
            this.dgvLoanSchedules.Name = "dgvLoanSchedules";
            this.dgvLoanSchedules.RowHeadersWidth = 51;
            this.dgvLoanSchedules.RowTemplate.Height = 24;
            this.dgvLoanSchedules.Size = new System.Drawing.Size(1247, 629);
            this.dgvLoanSchedules.TabIndex = 0;
            // 
            // ucListLoanSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLoanSchedules);
            this.Name = "ucListLoanSchedule";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucListLoanSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanSchedules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoanSchedules;
    }
}

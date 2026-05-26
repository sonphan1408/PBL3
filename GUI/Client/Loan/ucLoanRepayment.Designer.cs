namespace GUI.Client.Loan
{
    partial class ucLoanRepayment
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
            this.dgvRepayments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepayments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRepayments
            // 
            this.dgvRepayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepayments.Location = new System.Drawing.Point(109, 84);
            this.dgvRepayments.Name = "dgvRepayments";
            this.dgvRepayments.RowHeadersWidth = 51;
            this.dgvRepayments.RowTemplate.Height = 24;
            this.dgvRepayments.Size = new System.Drawing.Size(1211, 673);
            this.dgvRepayments.TabIndex = 0;
            this.dgvRepayments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ucLoanRepayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRepayments);
            this.Name = "ucLoanRepayment";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucLoanRepayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRepayments;
    }
}

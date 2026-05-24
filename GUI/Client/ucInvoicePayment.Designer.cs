namespace GUI.Client
{
    partial class ucInvoicePayment
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
            this.Phone = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Refund = new System.Windows.Forms.Button();
            this.Electricity = new System.Windows.Forms.Button();
            this.Water = new System.Windows.Forms.Button();
            this.Internet = new System.Windows.Forms.Button();
            this.pnlUnpaidList = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUnpaidList)).BeginInit();
            this.SuspendLayout();
            // 
            // Phone
            // 
            this.Phone.BackColor = System.Drawing.Color.Transparent;
            this.Phone.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Phone.FlatAppearance.BorderSize = 0;
            this.Phone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Phone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Phone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Phone.Location = new System.Drawing.Point(159, 338);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(83, 40);
            this.Phone.TabIndex = 8;
            this.Phone.UseVisualStyleBackColor = false;
            this.Phone.Click += new System.EventHandler(this.btnPhone_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Save.FlatAppearance.BorderSize = 0;
            this.Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Location = new System.Drawing.Point(149, 673);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(136, 49);
            this.Save.TabIndex = 9;
            this.Save.UseVisualStyleBackColor = false;
            // 
            // Refund
            // 
            this.Refund.BackColor = System.Drawing.Color.Transparent;
            this.Refund.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Refund.FlatAppearance.BorderSize = 0;
            this.Refund.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Refund.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Refund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refund.Location = new System.Drawing.Point(323, 673);
            this.Refund.Name = "Refund";
            this.Refund.Size = new System.Drawing.Size(136, 49);
            this.Refund.TabIndex = 10;
            this.Refund.UseVisualStyleBackColor = false;
            // 
            // Electricity
            // 
            this.Electricity.BackColor = System.Drawing.Color.Transparent;
            this.Electricity.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Electricity.FlatAppearance.BorderSize = 0;
            this.Electricity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Electricity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Electricity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Electricity.Location = new System.Drawing.Point(159, 208);
            this.Electricity.Name = "Electricity";
            this.Electricity.Size = new System.Drawing.Size(83, 40);
            this.Electricity.TabIndex = 11;
            this.Electricity.UseVisualStyleBackColor = false;
            this.Electricity.Click += new System.EventHandler(this.btnElectricity_Click);
            // 
            // Water
            // 
            this.Water.BackColor = System.Drawing.Color.Transparent;
            this.Water.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Water.FlatAppearance.BorderSize = 0;
            this.Water.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Water.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Water.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Water.Location = new System.Drawing.Point(351, 208);
            this.Water.Name = "Water";
            this.Water.Size = new System.Drawing.Size(83, 40);
            this.Water.TabIndex = 12;
            this.Water.UseVisualStyleBackColor = false;
            this.Water.Click += new System.EventHandler(this.btnWater_Click);
            // 
            // Internet
            // 
            this.Internet.BackColor = System.Drawing.Color.Transparent;
            this.Internet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Internet.FlatAppearance.BorderSize = 0;
            this.Internet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Internet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Internet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Internet.Location = new System.Drawing.Point(544, 208);
            this.Internet.Name = "Internet";
            this.Internet.Size = new System.Drawing.Size(83, 40);
            this.Internet.TabIndex = 13;
            this.Internet.UseVisualStyleBackColor = false;
            this.Internet.Click += new System.EventHandler(this.btnInternet_Click);
            // 
            // pnlUnpaidList
            // 
            this.pnlUnpaidList.Location = new System.Drawing.Point(731, 221);
            this.pnlUnpaidList.Name = "pnlUnpaidList";
            this.pnlUnpaidList.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ContextMenuInner;
            this.pnlUnpaidList.Size = new System.Drawing.Size(575, 526);
            this.pnlUnpaidList.TabIndex = 14;
            // 
            // ucInvoicePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.Payment;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pnlUnpaidList);
            this.Controls.Add(this.Internet);
            this.Controls.Add(this.Water);
            this.Controls.Add(this.Electricity);
            this.Controls.Add(this.Refund);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Phone);
            this.DoubleBuffered = true;
            this.Name = "ucInvoicePayment";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucInvoicePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlUnpaidList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Phone;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Refund;
        private System.Windows.Forms.Button Electricity;
        private System.Windows.Forms.Button Water;
        private System.Windows.Forms.Button Internet;
        private Krypton.Toolkit.KryptonPanel pnlUnpaidList;
    }
}

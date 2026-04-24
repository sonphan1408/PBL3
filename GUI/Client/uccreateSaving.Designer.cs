namespace GUI.Client
{
    partial class uccreateSaving
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uccreateSaving));
            this.cbTermMonths = new Krypton.Toolkit.KryptonComboBox();
            this.txtPrincialAmount = new Krypton.Toolkit.KryptonTextBox();
            this.txtDesc = new Krypton.Toolkit.KryptonTextBox();
            this.btnPre = new Krypton.Toolkit.KryptonButton();
            this.btnContinue = new Krypton.Toolkit.KryptonButton();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnHouse = new Krypton.Toolkit.KryptonButton();
            this.btnWedding = new Krypton.Toolkit.KryptonButton();
            this.btnCar = new Krypton.Toolkit.KryptonButton();
            this.btnTour = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbTermMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTermMonths
            // 
            this.cbTermMonths.DropDownWidth = 471;
            this.cbTermMonths.Location = new System.Drawing.Point(145, 448);
            this.cbTermMonths.Name = "cbTermMonths";
            this.cbTermMonths.Size = new System.Drawing.Size(432, 35);
            this.cbTermMonths.StateCommon.ComboBox.Border.Rounding = 10F;
            this.cbTermMonths.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTermMonths.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(0);
            this.cbTermMonths.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbTermMonths.TabIndex = 0;
            // 
            // txtPrincialAmount
            // 
            this.txtPrincialAmount.Location = new System.Drawing.Point(145, 325);
            this.txtPrincialAmount.Multiline = true;
            this.txtPrincialAmount.Name = "txtPrincialAmount";
            this.txtPrincialAmount.Size = new System.Drawing.Size(395, 45);
            this.txtPrincialAmount.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtPrincialAmount.StateCommon.Border.Rounding = 15F;
            this.txtPrincialAmount.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtPrincialAmount.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrincialAmount.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(145, 561);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(395, 45);
            this.txtDesc.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtDesc.StateCommon.Border.Rounding = 15F;
            this.txtDesc.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtDesc.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.TabIndex = 2;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(160, 689);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(195, 68);
            this.btnPre.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnPre.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnPre.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.StateCommon.Back.Image")));
            this.btnPre.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnPre.StateCommon.Border.Rounding = 20F;
            this.btnPre.TabIndex = 3;
            this.btnPre.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnPre.Values.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnPre.Values.Text = "";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(382, 689);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(183, 68);
            this.btnContinue.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
            this.btnContinue.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.btnContinue.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnContinue.StateCommon.Back.Image")));
            this.btnContinue.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnContinue.StateCommon.Border.Rounding = 20F;
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnContinue.Values.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnContinue.Values.Text = "";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.ForeColor = System.Drawing.Color.Red;
            this.lblAccountNumber.Location = new System.Drawing.Point(131, 161);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Padding = new System.Windows.Forms.Padding(5);
            this.lblAccountNumber.Size = new System.Drawing.Size(74, 32);
            this.lblAccountNumber.TabIndex = 7;
            this.lblAccountNumber.Text = "label1";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Red;
            this.lblBalance.Location = new System.Drawing.Point(423, 161);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Padding = new System.Windows.Forms.Padding(5);
            this.lblBalance.Size = new System.Drawing.Size(74, 32);
            this.lblBalance.TabIndex = 8;
            this.lblBalance.Text = "label1";
            // 
            // btnHouse
            // 
            this.btnHouse.Location = new System.Drawing.Point(145, 629);
            this.btnHouse.Name = "btnHouse";
            this.btnHouse.Size = new System.Drawing.Size(90, 36);
            this.btnHouse.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnHouse.StateCommon.Back.Color2 = System.Drawing.Color.LightCyan;
            this.btnHouse.StateCommon.Border.Rounding = 15F;
            this.btnHouse.TabIndex = 9;
            this.btnHouse.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnHouse.Values.Text = "Nhà";
            this.btnHouse.Click += new System.EventHandler(this.btnHouse_Click);
            // 
            // btnWedding
            // 
            this.btnWedding.Location = new System.Drawing.Point(366, 629);
            this.btnWedding.Name = "btnWedding";
            this.btnWedding.Size = new System.Drawing.Size(115, 36);
            this.btnWedding.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnWedding.StateCommon.Back.Color2 = System.Drawing.Color.LightCyan;
            this.btnWedding.StateCommon.Border.Rounding = 15F;
            this.btnWedding.TabIndex = 10;
            this.btnWedding.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnWedding.Values.Text = "Đám cưới";
            this.btnWedding.Click += new System.EventHandler(this.btnWedding_Click);
            // 
            // btnCar
            // 
            this.btnCar.Location = new System.Drawing.Point(253, 629);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(90, 36);
            this.btnCar.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCar.StateCommon.Back.Color2 = System.Drawing.Color.LightCyan;
            this.btnCar.StateCommon.Border.Rounding = 15F;
            this.btnCar.TabIndex = 11;
            this.btnCar.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnCar.Values.Text = "Xe";
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // btnTour
            // 
            this.btnTour.Location = new System.Drawing.Point(505, 629);
            this.btnTour.Name = "btnTour";
            this.btnTour.Size = new System.Drawing.Size(90, 36);
            this.btnTour.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnTour.StateCommon.Back.Color2 = System.Drawing.Color.LightCyan;
            this.btnTour.StateCommon.Border.Rounding = 15F;
            this.btnTour.TabIndex = 12;
            this.btnTour.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnTour.Values.Text = "Du lịch";
            this.btnTour.Click += new System.EventHandler(this.btnTour_Click);
            // 
            // uccreateSaving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnTour);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.btnWedding);
            this.Controls.Add(this.btnHouse);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAccountNumber);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtPrincialAmount);
            this.Controls.Add(this.cbTermMonths);
            this.Name = "uccreateSaving";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.uccreateSaving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbTermMonths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonComboBox cbTermMonths;
        private Krypton.Toolkit.KryptonTextBox txtPrincialAmount;
        private Krypton.Toolkit.KryptonTextBox txtDesc;
        private Krypton.Toolkit.KryptonButton btnPre;
        private Krypton.Toolkit.KryptonButton btnContinue;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblBalance;
        private Krypton.Toolkit.KryptonButton btnHouse;
        private Krypton.Toolkit.KryptonButton btnWedding;
        private Krypton.Toolkit.KryptonButton btnCar;
        private Krypton.Toolkit.KryptonButton btnTour;
    }
}

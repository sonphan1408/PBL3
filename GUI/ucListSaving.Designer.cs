namespace GUI
{
    partial class ucListSaving
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucListSaving));
            this.flowLayoutListSaving = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalDeposit = new System.Windows.Forms.Label();
            this.lblTotalExpectedInterest = new System.Windows.Forms.Label();
            this.chartSavingType = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTerm = new Krypton.Toolkit.KryptonButton();
            this.btnInstallment = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartSavingType)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutListSaving
            // 
            this.flowLayoutListSaving.AutoScroll = true;
            this.flowLayoutListSaving.BackColor = System.Drawing.Color.White;
            this.flowLayoutListSaving.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutListSaving.Location = new System.Drawing.Point(41, 136);
            this.flowLayoutListSaving.Name = "flowLayoutListSaving";
            this.flowLayoutListSaving.Size = new System.Drawing.Size(627, 591);
            this.flowLayoutListSaving.TabIndex = 0;
            this.flowLayoutListSaving.WrapContents = false;
            this.flowLayoutListSaving.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutListSaving_Paint);
            // 
            // lblTotalDeposit
            // 
            this.lblTotalDeposit.AutoSize = true;
            this.lblTotalDeposit.BackColor = System.Drawing.Color.White;
            this.lblTotalDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeposit.Location = new System.Drawing.Point(754, 100);
            this.lblTotalDeposit.Name = "lblTotalDeposit";
            this.lblTotalDeposit.Size = new System.Drawing.Size(70, 25);
            this.lblTotalDeposit.TabIndex = 1;
            this.lblTotalDeposit.Text = "label1";
            // 
            // lblTotalExpectedInterest
            // 
            this.lblTotalExpectedInterest.AutoSize = true;
            this.lblTotalExpectedInterest.BackColor = System.Drawing.Color.White;
            this.lblTotalExpectedInterest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpectedInterest.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalExpectedInterest.Location = new System.Drawing.Point(786, 149);
            this.lblTotalExpectedInterest.Name = "lblTotalExpectedInterest";
            this.lblTotalExpectedInterest.Size = new System.Drawing.Size(53, 20);
            this.lblTotalExpectedInterest.TabIndex = 2;
            this.lblTotalExpectedInterest.Text = "label2";
            this.lblTotalExpectedInterest.Click += new System.EventHandler(this.label2_Click);
            // 
            // chartSavingType
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSavingType.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSavingType.Legends.Add(legend1);
            this.chartSavingType.Location = new System.Drawing.Point(825, 227);
            this.chartSavingType.Name = "chartSavingType";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSavingType.Series.Add(series1);
            this.chartSavingType.Size = new System.Drawing.Size(456, 254);
            this.chartSavingType.TabIndex = 3;
            this.chartSavingType.Text = "chart1";
            // 
            // btnTerm
            // 
            this.btnTerm.Location = new System.Drawing.Point(773, 543);
            this.btnTerm.Name = "btnTerm";
            this.btnTerm.Size = new System.Drawing.Size(237, 167);
            this.btnTerm.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnTerm.StateCommon.Back.Image")));
            this.btnTerm.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnTerm.StateCommon.Border.Rounding = 15F;
            this.btnTerm.TabIndex = 4;
            this.btnTerm.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnTerm.Values.Text = "";
            this.btnTerm.Click += new System.EventHandler(this.btnTerm_Click);
            // 
            // btnInstallment
            // 
            this.btnInstallment.Location = new System.Drawing.Point(1044, 543);
            this.btnInstallment.Name = "btnInstallment";
            this.btnInstallment.Size = new System.Drawing.Size(237, 167);
            this.btnInstallment.StateCommon.Back.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallment.StateCommon.Back.Image")));
            this.btnInstallment.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnInstallment.StateCommon.Border.Rounding = 15F;
            this.btnInstallment.TabIndex = 5;
            this.btnInstallment.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnInstallment.Values.Text = "";
            this.btnInstallment.Click += new System.EventHandler(this.btnInstallment_Click);
            // 
            // ucListSaving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnInstallment);
            this.Controls.Add(this.btnTerm);
            this.Controls.Add(this.chartSavingType);
            this.Controls.Add(this.lblTotalExpectedInterest);
            this.Controls.Add(this.lblTotalDeposit);
            this.Controls.Add(this.flowLayoutListSaving);
            this.Name = "ucListSaving";
            this.Size = new System.Drawing.Size(1387, 791);
            this.Load += new System.EventHandler(this.ucListSaving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSavingType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutListSaving;
        private System.Windows.Forms.Label lblTotalDeposit;
        private System.Windows.Forms.Label lblTotalExpectedInterest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSavingType;
        private Krypton.Toolkit.KryptonButton btnTerm;
        private Krypton.Toolkit.KryptonButton btnInstallment;
    }
}

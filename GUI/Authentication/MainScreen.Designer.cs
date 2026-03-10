namespace GUI.Authentication
{
    partial class MainScreen
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelAbout = new System.Windows.Forms.Label();
            this.labelContacts = new System.Windows.Forms.Label();
            this.labelServices = new System.Windows.Forms.Label();
            this.labelHome = new System.Windows.Forms.Label();
            this.labelBankName = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTagline = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            
            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelHeader.Controls.Add(this.labelAbout);
            this.panelHeader.Controls.Add(this.labelContacts);
            this.panelHeader.Controls.Add(this.labelServices);
            this.panelHeader.Controls.Add(this.labelHome);
            this.panelHeader.Controls.Add(this.labelBankName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 80);
            this.panelHeader.TabIndex = 0;
            
            // labelBankName
            this.labelBankName.AutoSize = true;
            this.labelBankName.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.labelBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBankName.Location = new System.Drawing.Point(30, 20);
            this.labelBankName.Name = "labelBankName";
            this.labelBankName.Size = new System.Drawing.Size(200, 37);
            this.labelBankName.TabIndex = 0;
            this.labelBankName.Text = "❖ Sigma Bank";
            
            // labelHome
            this.labelHome.AutoSize = true;
            this.labelHome.Font = new System.Drawing.Font("Arial", 12F);
            this.labelHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelHome.Location = new System.Drawing.Point(360, 30);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(50, 18);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Home";
            
            // labelServices
            this.labelServices.AutoSize = true;
            this.labelServices.Font = new System.Drawing.Font("Arial", 12F);
            this.labelServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelServices.Location = new System.Drawing.Point(450, 30);
            this.labelServices.Name = "labelServices";
            this.labelServices.Size = new System.Drawing.Size(70, 18);
            this.labelServices.TabIndex = 2;
            this.labelServices.Text = "Services";
            
            // labelContacts
            this.labelContacts.AutoSize = true;
            this.labelContacts.Font = new System.Drawing.Font("Arial", 12F);
            this.labelContacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelContacts.Location = new System.Drawing.Point(570, 30);
            this.labelContacts.Name = "labelContacts";
            this.labelContacts.Size = new System.Drawing.Size(70, 18);
            this.labelContacts.TabIndex = 3;
            this.labelContacts.Text = "Contacts";
            
            // labelAbout
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Arial", 12F);
            this.labelAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelAbout.Location = new System.Drawing.Point(684, 30);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(70, 18);
            this.labelAbout.TabIndex = 4;
            this.labelAbout.Text = "About Us";
            
            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.panelContent.Controls.Add(this.labelDescription);
            this.panelContent.Controls.Add(this.labelTagline);
            this.panelContent.Controls.Add(this.btnAdmin);
            this.panelContent.Controls.Add(this.btnClient);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1000, 520);
            this.panelContent.TabIndex = 1;
            
            // labelTagline
            this.labelTagline.AutoSize = true;
            this.labelTagline.Font = new System.Drawing.Font("Arial", 42F, System.Drawing.FontStyle.Bold);
            this.labelTagline.ForeColor = System.Drawing.Color.Black;
            this.labelTagline.Location = new System.Drawing.Point(155, 50);
            this.labelTagline.Name = "labelTagline";
            this.labelTagline.Size = new System.Drawing.Size(700, 65);
            this.labelTagline.TabIndex = 0;
            this.labelTagline.Text = "Where Money Meet Trust.";
            
            // labelDescription
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDescription.Location = new System.Drawing.Point(155, 130);
            this.labelDescription.MaximumSize = new System.Drawing.Size(600, 60);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(580, 36);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Our bank is committed to delivering safety, convenience,\r\nand trust in every transaction.";
            
            // btnClient
            this.btnClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnClient.ForeColor = System.Drawing.Color.White;
            this.btnClient.Location = new System.Drawing.Point(175, 220);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(100, 40);
            this.btnClient.TabIndex = 2;
            this.btnClient.Text = "Client";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            
            // btnAdmin
            this.btnAdmin.BackColor = System.Drawing.Color.White;
            this.btnAdmin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnAdmin.Location = new System.Drawing.Point(310, 220);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 40);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            
            // MainScreen
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "MainScreen";
            this.Text = "Sigma Bank - Where Money Meet Trust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelBankName;
        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.Label labelServices;
        private System.Windows.Forms.Label labelContacts;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelTagline;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnAdmin;
    }
}
namespace GUI.Client
{
    partial class ucChangePassword
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
            this.lblOldPassword = new Krypton.Toolkit.KryptonLabel();
            this.txtOldPassword = new Krypton.Toolkit.KryptonTextBox();
            this.lblNewPassword = new Krypton.Toolkit.KryptonLabel();
            this.lblConfirmPassword = new Krypton.Toolkit.KryptonLabel();
            this.txtNewPassword = new Krypton.Toolkit.KryptonTextBox();
            this.txtConfirmPassword = new Krypton.Toolkit.KryptonTextBox();
            this.btnConfirmPassword = new System.Windows.Forms.Button();
            this.Editprofile = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblOldPassword.Location = new System.Drawing.Point(429, 251);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lblOldPassword.Size = new System.Drawing.Size(174, 38);
            this.lblOldPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.TabIndex = 14;
            this.lblOldPassword.Values.Text = "Mật khẩu hiện tại";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(429, 295);
            this.txtOldPassword.Multiline = true;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(489, 40);
            this.txtOldPassword.StateCommon.Border.Rounding = 8F;
            this.txtOldPassword.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.TabIndex = 20;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblNewPassword.Location = new System.Drawing.Point(429, 350);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lblNewPassword.Size = new System.Drawing.Size(174, 38);
            this.lblNewPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.TabIndex = 21;
            this.lblNewPassword.Values.Text = "Mật khẩu mới";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.LabelStyle = Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblConfirmPassword.Location = new System.Drawing.Point(429, 456);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007BlueLightMode;
            this.lblConfirmPassword.Size = new System.Drawing.Size(230, 38);
            this.lblConfirmPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.TabIndex = 22;
            this.lblConfirmPassword.Values.Text = "Xác nhận mật khẩu mới";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(429, 403);
            this.txtNewPassword.Multiline = true;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(489, 40);
            this.txtNewPassword.StateCommon.Border.Rounding = 8F;
            this.txtNewPassword.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.TabIndex = 23;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(429, 507);
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(489, 40);
            this.txtConfirmPassword.StateCommon.Border.Rounding = 8F;
            this.txtConfirmPassword.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.TabIndex = 24;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnConfirmPassword
            // 
            this.btnConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmPassword.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirmPassword.FlatAppearance.BorderSize = 0;
            this.btnConfirmPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPassword.Location = new System.Drawing.Point(567, 590);
            this.btnConfirmPassword.Name = "btnConfirmPassword";
            this.btnConfirmPassword.Size = new System.Drawing.Size(204, 25);
            this.btnConfirmPassword.TabIndex = 25;
            this.btnConfirmPassword.UseVisualStyleBackColor = false;
            this.btnConfirmPassword.Click += new System.EventHandler(this.btnConfirmPassword_Click);
            // 
            // Editprofile
            // 
            this.Editprofile.BackColor = System.Drawing.Color.Transparent;
            this.Editprofile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Editprofile.FlatAppearance.BorderSize = 0;
            this.Editprofile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Editprofile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Editprofile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editprofile.Location = new System.Drawing.Point(90, 42);
            this.Editprofile.Name = "Editprofile";
            this.Editprofile.Size = new System.Drawing.Size(223, 15);
            this.Editprofile.TabIndex = 26;
            this.Editprofile.UseVisualStyleBackColor = false;
            this.Editprofile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.Transparent;
            this.Password.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Password.FlatAppearance.BorderSize = 0;
            this.Password.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Password.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Password.Location = new System.Drawing.Point(374, 42);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(109, 15);
            this.Password.TabIndex = 27;
            this.Password.UseVisualStyleBackColor = false;
            // 
            // ucChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // this.BackgroundImage = global::GUI.Properties.Resources.ChangePassword;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Editprofile);
            this.Controls.Add(this.btnConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.DoubleBuffered = true;
            this.Name = "ucChangePassword";
            this.Size = new System.Drawing.Size(1387, 791);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel lblOldPassword;
        private Krypton.Toolkit.KryptonTextBox txtOldPassword;
        private Krypton.Toolkit.KryptonLabel lblNewPassword;
        private Krypton.Toolkit.KryptonLabel lblConfirmPassword;
        private Krypton.Toolkit.KryptonTextBox txtNewPassword;
        private Krypton.Toolkit.KryptonTextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnConfirmPassword;
        private System.Windows.Forms.Button Editprofile;
        private System.Windows.Forms.Button Password;
    }
}

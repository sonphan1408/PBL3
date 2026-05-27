using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class ucChangePassword : UserControl
    {
        public Action<UserControl> NavigateTo { get; set; }
        public ucChangePassword()
        {
            InitializeComponent();
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            ucAccountInfo ucEditInfo = new ucAccountInfo();
            ucEditInfo.NavigateTo = this.NavigateTo;
            NavigateTo?.Invoke(ucEditInfo);
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            var currentAccount = GUI.Session.UserSession.CurrentUser;

            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            // De BLL xu ly logic doi mat khau va tra ve thong diep loi neu co
            string errorMessage = AccountService.ChangePassword(currentAccount.AccountNumber, oldPass, newPass, confirmPass);

            if (errorMessage == "")
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();

                // Cap nhat mat khau moi vao session
                GUI.Session.UserSession.CurrentUser.Password = newPass;
            }
            else
            {
                MessageBox.Show(errorMessage, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

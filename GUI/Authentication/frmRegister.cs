using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Models;
using BLL.Services;

namespace GUI.Authentication
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            CustomerDTO newCustomer = new CustomerDTO()
            {
                FullName = txtFullName.Text.Trim(),
                Gender = bxGender.Text,
                DateOfBirth = dtDayofBirth.Value,
                Address = txtAddress.Text.Trim(),
                PhoneNumber = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                CCCD = txtCCCD.Text.Trim()
            };

            AccountDTO newAccount = new AccountDTO()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text
            };

            AuthService authService = new AuthService();
            string ketQua = authService.RegisterNewCustomer(newCustomer, newAccount, txtConfirm.Text);

            if (ketQua.StartsWith("SUCCESS:"))
            {
                string soTaiKhoan = ketQua.Substring(8);
                MessageBox.Show($"Đăng ký thành công!\nSố tài khoản ngân hàng của bạn là: {soTaiKhoan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                frmLogin login = new frmLogin();
                login.Show();
            }
            else
            {
                MessageBox.Show(ketQua, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegister_Shown(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }
    }
}
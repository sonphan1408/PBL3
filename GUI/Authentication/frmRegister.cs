using BLL.Services;
using DTO.Models;
using System;
using System.Windows.Forms;

namespace GUI.Authentication
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        Boolean check_click_back = false;
        private void Back_Click(object sender, EventArgs e)
        {
            check_click_back = true;
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

            AccountCustomerDTO newAccount = new AccountCustomerDTO()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Role = "Customer"
            };

            AuthService authService = new AuthService();
            string ketQua = authService.RegisterNewCustomer(newCustomer, newAccount, txtConfirm.Text);

            if (ketQua.StartsWith("SUCCESS:"))
            {
                string soTaiKhoan = ketQua.Substring(8);
                MessageBox.Show($"Đăng ký thành công!\nSố tài khoản ngân hàng của bạn là: {soTaiKhoan}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(ketQua, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!check_click_back)
                Application.Exit();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
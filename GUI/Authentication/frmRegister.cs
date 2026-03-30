using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;

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
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create customer DTO
                CustomerDTO customer = new CustomerDTO
                {
                    FullName = txtFullName.Text,
                    Gender = bxGender.Text,
                    DateOfBirth = dtDayofBirth.Value,
                    Address = txtAddress.Text,
                    PhoneNumber = txtSDT.Text,
                    Email = txtEmail.Text,
                    IDCard = txtCCCD.Text
                };

                // Register customer
                string accountNumber = AuthService.RegisterCustomer(customer, txtUsername.Text, txtPassword.Text, txtConfirm.Text);

                MessageBox.Show($"Đăng ký thành công!\nSố tài khoản ngân hàng của bạn là: {accountNumber}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                frmLogin login = new frmLogin();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký:\n" + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}

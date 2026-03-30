using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Models; // Để lấy Thùng hàng
using BLL.Services; // Gọi thẳng Service, không dùng chung cái BLL.Validation cũ nữa

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
            // 1. Đóng gói dữ liệu từ giao diện vào DTO
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

            // 2. Giao cho BLL xử lý
            AuthService authService = new AuthService();
            string ketQua = authService.RegisterNewCustomer(newCustomer, newAccount, txtConfirm.Text);

            // 3. Phản hồi kết quả cho người dùng
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

        private void label2_Click(object sender, EventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
    }
}
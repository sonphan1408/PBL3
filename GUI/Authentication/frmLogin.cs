using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI.Authentication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Enter(object sender, EventArgs e)
        {
            if(TaiKhoan.Text == "Username")
            {
                TaiKhoan.Text = "";
                TaiKhoan.ForeColor = Color.Black;
            }
        }

        private void TaiKhoan_Leave(object sender, EventArgs e)
        {
            if (TaiKhoan.Text == "")
            {
                TaiKhoan.Text = "Username";
                TaiKhoan.ForeColor = Color.Gray;
            }
        }

        private void MatKhau_Enter(object sender, EventArgs e)
        {
            if (MatKhau.Text == "Password")
            {
                MatKhau.Text = "";
                MatKhau.ForeColor = Color.Black;
                MatKhau.UseSystemPasswordChar = true;
            }
        }

        private void MatKhau_Leave(object sender, EventArgs e)
        {
            if (MatKhau.Text == "")
            {
                MatKhau.Text = "Password";
                MatKhau.ForeColor = Color.Gray;
                MatKhau.UseSystemPasswordChar = false;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            // Mở frmFace
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
            //Close();
        }

        private void MatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Text == "Username" || TaiKhoan.Text == "" ||
                MatKhau.Text == "Password" || MatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Data Source=LAPTOP-IHOEII21\SQLEXPRESS;Initial Catalog=DigitalBankingDB;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Accounts WHERE Username = @user AND Password = @pass";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", TaiKhoan.Text);
                        cmd.Parameters.AddWithValue("@pass", MatKhau.Text);

                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                            this.Hide();

                            // Mở form giao diện chính
                        }
                        else
                        {
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối Database: " + ex.Message, "Lỗi Hệ Thống");
                }
            }
        }
    }
}

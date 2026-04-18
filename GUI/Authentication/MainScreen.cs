using System;
using System.Windows.Forms;

namespace GUI.Authentication
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            if (!this.IsDisposed)
            {
                this.Show();
            }
        }
    }
}

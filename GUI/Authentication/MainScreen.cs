using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Authentication
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            // TODO: Xử lý khi bấm nút Client
            MessageBox.Show("Client login", "Sigma Bank");
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // TODO: Xử lý khi bấm nút Admin
            MessageBox.Show("Admin login", "Sigma Bank");
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelBankName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

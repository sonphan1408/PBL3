using System.Windows.Forms;

namespace GUI.Admin
{
    public partial class frmAdminDashboard : Form
    {
        private string username;

        public frmAdminDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }
    }
}

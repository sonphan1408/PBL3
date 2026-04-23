using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucConfirmSaving : UserControl
    {
        public Action<UserControl> NavigateTo;
        public ucConfirmSaving()
        {
            InitializeComponent();
        }

        private void ucConfirmSaving_Load(object sender, EventArgs e)
        {

        }
    }
}

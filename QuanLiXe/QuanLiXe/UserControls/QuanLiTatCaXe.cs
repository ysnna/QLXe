using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiXe.UserControls
{
    public partial class QuanLiTatCaXe : UserControl
    {
        public QuanLiTatCaXe()
        {
            InitializeComponent();
        }

        private void btSua_Click(object sender, EventArgs e)
        {

        }

        private void QuanLiTatCaXe_Load(object sender, EventArgs e)
        {
            labelDauSaiViTri.Visible = false;
            labelQuaGioGui.Visible = false;
        }
    }
}

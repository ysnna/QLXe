using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiXe
{
    public partial class QuanLiForm : Form
    {
        public QuanLiForm()
        {
            InitializeComponent();
        }

        private void btGioiThieu_Click(object sender, EventArgs e)
        {
            panelClick.Height = btGioiThieu.Height;
            panelClick.Top = btGioiThieu.Top;
            gioiThieuUC.BringToFront();
        }

        private void QuanLiForm_Load(object sender, EventArgs e)
        {
            gioiThieuUC.Location = new Point(350, 0);
            thongTinKhachHangUC.Location = new Point(350, 0);
        }

        private void btThongTinKhachHang_Click(object sender, EventArgs e)
        {
            panelClick.BringToFront();
            panelClick.Height = btThongTinKhachHang.Height;
            panelClick.Top = btThongTinKhachHang.Top;
            thongTinKhachHangUC.BringToFront();
        }

        private void btQuanLiXe_Click(object sender, EventArgs e)
        {
            Manage mn = new Manage();
            mn.ShowDialog(this);
        }
    }
}
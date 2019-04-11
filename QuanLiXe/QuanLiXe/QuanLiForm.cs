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
            menuStrip.Visible = false;
            gioiThieuUC.BringToFront();
            gioiThieuUC.Location = new Point(350, 0);
            giaoDienQuanLiXeUC.Location = new Point(350, 0);
            quanLiTatCaXe.Location = new Point(350, 0);
            menuStrip.Location = new Point(350, 0);
            pictureBoxBack.Location = new Point(370, 12);
            pictureBoxBack.BackColor = quanLiTatCaXe.BackColor;
            tongDoanThuUC.Location = new Point(350, 0);

        }

        private void btThongTinKhachHang_Click(object sender, EventArgs e)
        {
            panelClick.BringToFront();
            panelClick.Height = btThongTinKhachHang.Height;
            panelClick.Top = btThongTinKhachHang.Top;
        }

        private void btQuanLiXe_Click(object sender, EventArgs e)
        {
            panelClick.BringToFront();
            panelClick.Height = btQuanLiXe.Height;
            panelClick.Top = btQuanLiXe.Top;
            giaoDienQuanLiXeUC.BringToFront();
            menuStrip.Visible = true;
            menuStrip.BringToFront();
        }

        private void btThongTinTho_Click(object sender, EventArgs e)
        {
            panelClick.BringToFront();
            panelClick.Height = btThongTinTho.Height;
            panelClick.Top = btThongTinTho.Top;
        }

        private void quanLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanLiTatCaXe.BringToFront();
            pictureBoxBack.BringToFront();
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            giaoDienQuanLiXeUC.BringToFront();
            menuStrip.BringToFront();
        }

        private void baiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaiXeForm baiXe = new BaiXeForm();
            baiXe.ShowDialog();
        }

        private void btTongDoanThu_Click(object sender, EventArgs e)
        {
            panelClick.BringToFront();
            panelClick.Height = btTongDoanThu.Height;
            panelClick.Top = btTongDoanThu.Top;
            tongDoanThuUC.BringToFront();
        }
    }
}
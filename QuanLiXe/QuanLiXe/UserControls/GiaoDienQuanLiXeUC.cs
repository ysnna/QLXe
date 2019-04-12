using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace QuanLiXe.UserControls
{
    public partial class GiaoDienQuanLiXeUC : UserControl
    {
        MY_DB mydb = new MY_DB();
        KhachHang kh = new KhachHang();
        public GiaoDienQuanLiXeUC()
        {
            InitializeComponent();
        }

        //Check xem xe gửi theo ngày tháng hay giờ
        private void btGuiTheoThang_Click(object sender, EventArgs e)
        {
            Month.Checked = true;
            Day.Checked = false;
            Hour.Checked = false;
        }

        private void btGuiTheoNgay_Click(object sender, EventArgs e)
        {
            Month.Checked = false;
            Day.Checked = true;
            Hour.Checked = false;
        }

        private void btGuiTheoGio_Click(object sender, EventArgs e)
        {
            Month.Checked = false;
            Day.Checked = false;
            Hour.Checked = true;
        }

        //Check xem xe gửi Loại Gì
        private void btOto_Click(object sender, EventArgs e)
        {
            Oto.Checked = true;
            XeMay.Checked = false;
            XeDap.Checked = false;
        }

        private void btXeMay_Click(object sender, EventArgs e)
        {
            Oto.Checked = false;
            XeMay.Checked = true;
            XeDap.Checked = false;
        }

        private void btXeDap_Click(object sender, EventArgs e)
        {
            Oto.Checked = false;
            XeMay.Checked = false;
            XeDap.Checked = true;
        }
        //Nút lưu xe (Lưu vào database rồi đổ lên Form Quản Lí Tất Cả Xe)
        private void btMoiXeVao_Click(object sender, EventArgs e)
        {
            string vitri = btKhuVuc.Text.ToString();
            string loaixe;
            if(Oto.Checked == true)
            {
                 loaixe = btOto.Text.ToString();
            }
            else if (XeMay.Checked == true)
            {
                loaixe = btXeMay.Text.ToString();
            }
            else
            {
                 loaixe = btXeDap.Text.ToString();
            }
            string yeucau;
            if (Month.Checked == true)
            {
                yeucau = Month.Text.ToString();
            }
            else if (Day.Checked == true)
            {
                yeucau = Day.Text.ToString();
            }
            else
            {
                yeucau = Hour.Text.ToString();
            }

            MemoryStream nguoigui = new MemoryStream();
            MemoryStream bienso = new MemoryStream();
            DateTime ngaygui = DTPNgayGui.Value;
            DateTime giogui = DTPGioGui.Value;
            pictureBoxBienSoXe.Image.Save(bienso, pictureBoxBienSoXe.Image.RawFormat);
            pictureBoxNguoiGui.Image.Save(nguoigui, pictureBoxNguoiGui.Image.RawFormat);

            if (kh.insertCus(vitri,loaixe,bienso,nguoigui,ngaygui,giogui,yeucau ))
                MessageBox.Show("Xe Đã Nhận Vào Bãi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Tao su kien khi Luu hinh anh
        private void pictureBoxNguoiGui_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "select image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
                pictureBoxNguoiGui.Image = Image.FromFile(open.FileName);
        }

        private void pictureBoxBienSoXe_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "select image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
                pictureBoxBienSoXe.Image = Image.FromFile(open.FileName);
        }

   
    }
}

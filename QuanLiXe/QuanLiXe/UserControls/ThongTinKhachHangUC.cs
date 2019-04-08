using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace QuanLiXe.UserControls
{
    public partial class ThongTinKhachHangUC : UserControl
    {
        public ThongTinKhachHangUC()
        {
            InitializeComponent();
        }
        KhachHang kh = new KhachHang();

        private void btThem_Click(object sender, EventArgs e)
        {
            //KhachHang kh = new KhachHang();
            int id = Convert.ToInt32(txtMaKH.Text);
            string ho = txtHoKH.Text;
            string ten = txtTenKH.Text;
            string diachi = txtDC.Text;
            int dienthoai =Convert.ToInt32( txtSDT.Text);
            int sohopdong = Convert.ToInt32(txtSoHD.Text);
            DateTime day_bd = dateTimePicker1.Value;
            DateTime day_kt = dateTimePicker2.Value;
            MemoryStream pic = new MemoryStream();

            int hour_start = dateTimePicker1.Value.Hour;
            int hour_end = dateTimePicker2.Value.Hour;
            try
            {
                if (dateTimePicker1.Value.Year.ToString() != dateTimePicker2.Value.Year.ToString())
                {
                    MessageBox.Show("Error", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (verif())
                {
                    picKH.Image.Save(pic, picKH.Image.RawFormat);

                    if (kh.insertKhachhang(id, ho, ten, diachi, dienthoai, day_bd, day_kt, sohopdong, pic))
                    {
                        MessageBox.Show("New hop dong create", "Khach Hang added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Empty", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }catch
            {
                MessageBox.Show("Invalid data!","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
            
            
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        bool verif()
        {
            if (txtMaKH.Text.Trim() == "" || txtDC.Text.Trim() == ""
                || txtMaKH.Text.Trim() == "" || txtSDT.Text.Trim() == "" ||
                txtSoHD.Text.Trim() == "" || txtTenKH.Text.Trim() == ""||picKH.Image==null)
                return false;
            else
                return true;
        }

        private void picKH_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog(); // Mở trong máy tính để lấy hình
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog()) == DialogResult.OK)
            {
                picKH.Image = Image.FromFile(opf.FileName);

            }
        }

        private void dgvThongTinKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dgvThongTinKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtHoKH.Text = dgvThongTinKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtTenKH.Text = dgvThongTinKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dgvThongTinKhachHang.CurrentRow.Cells[4].Value.ToString();
            txtDC.Text = dgvThongTinKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtSoHD.Text= dgvThongTinKhachHang.CurrentRow.Cells[5].Value.ToString();
            dgvThongTinKhachHang.CurrentRow.Cells[6].Value = dateTimePicker1.Value.ToString("hh:mm:ss  dd-MM-yyyy");
            dgvThongTinKhachHang.CurrentRow.Cells[7].Value = dateTimePicker2.Value.ToString("hh:mm:ss  dd-MM-yyyy");
            //dateTimePicker2.Value = (DateTime)dgvThongTinKhachHang.CurrentRow.Cells[6].Value;
            byte[] pic;
            pic = (byte[])dgvThongTinKhachHang.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            picKH.Image = Image.FromStream(picture);
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("select * FROM THONGTINKHACHHANG");
            dgvThongTinKhachHang.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dgvThongTinKhachHang.RowTemplate.Height = 80;
            dgvThongTinKhachHang.DataSource = kh.getKhachHang(command);
            picCol = (DataGridViewImageColumn)dgvThongTinKhachHang.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            
            dgvThongTinKhachHang.AllowUserToAddRows = false;
        }

        private void ThongTinKhachHangUC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh:mm:ss  dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm:ss  dd-MM-yyyy";
        }
    }
}

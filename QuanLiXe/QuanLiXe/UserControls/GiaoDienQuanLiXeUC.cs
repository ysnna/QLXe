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
        BaiXeForm baixe = new BaiXeForm();
        //Check xem xe gửi Loại Gì
        private void btOto_Click(object sender, EventArgs e)
        {
            Oto.Checked = true;
            XeMay.Checked = false;
            XeDap.Checked = false;
            //SqlCommand cmd = new SqlCommand("select * from BAIXE");

            //baixe.dgvBaiXe.DataSource = kh.getCus(cmd);
            //for(int i = 0; i < 20;i++)
            //    for (int j = 0; i < 3; j ++ )
            //    {
            //        if (Convert.ToInt32(baixe.dgvBaiXe.Rows[i].Cells[j].Value) == 0)
            //            btKhuVuc.Text = ".....";
            //    }
            MY_DB db = new MY_DB();
            KhachHang student = new KhachHang();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from BAIXE", db.getConnection);
            //cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsername.Text;
            //cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;
            da.SelectCommand = cmd;
            da.Fill(dt);
            
            int i = 0;
            while (i < dt.Rows.Count)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (dt.Rows[i][j].ToString() == "0")
                    {
                        switch (j)
                        {
                            case 1:
                                btKhuVuc.Text = "A." + (i + 1);
                                i = 30;
                                j = 4;
                                break;
                            case 2:
                                btKhuVuc.Text = "B." + (i + 1);
                                j = 4;
                                i = 30;
                                break;
                            case 3:
                                btKhuVuc.Text = "C." + (i + 1);
                                j = 4;
                                i = 30;
                                break;

                        }

                    }
                }
                i++;
            }

            //if (txtUsername.Text == dt.Rows[i]["username"].ToString() && txtPassword.Text == dt.Rows[i]["password"].ToString())
            //this.DialogResult = DialogResult.OK;

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
            string vitri = btKhuVuc.Text.ToString().Replace(".","");
            string loaixe;
            if (Oto.Checked == true)
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
            
            if (kh.insertCus(vitri, loaixe, bienso, nguoigui, ngaygui, giogui, yeucau))
                MessageBox.Show("Xe Đã Nhận Vào Bãi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string s = btKhuVuc.Text.ToString();
            string[] sp = s.Split('.');
            if (sp[0]=="A")
            {
                kh.updateBaiXe("1", sp[1]);
            }
            else if (sp[0] == "B")
            {
                kh.updateBaiXe2("1", sp[1]);
            }
            else
            {
                kh.updateBaiXe3("1", sp[1]);
            }
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

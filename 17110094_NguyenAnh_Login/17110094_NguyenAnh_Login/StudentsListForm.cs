using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace _17110094_NguyenAnh_Login
{
    public partial class studentsListForm : Form
    {
        public studentsListForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        MY_DB mydb = new MY_DB();
        private void studentsListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_DESKTOP_RRRHOP4DataSet1.SinhVien' table. You can move, or remove it, as needed.
            this.sinhVienTableAdapter.Fill(this._DESKTOP_RRRHOP4DataSet1.SinhVien);
            SqlCommand cmd = new SqlCommand("select * from Std");
            DataGridView1.ReadOnly = true;
            //xử lí hình ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 90; //chỉnh pic đẹp
            DataGridView1.DataSource = student.getStudents(cmd);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridView1.AllowUserToAddRows = false;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            updateDeletStdF updateDeleteStdF = new updateDeletStdF();
            //thứ tự của các cột trong table
            updateDeleteStdF.TextBoxID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStdF.TextBoxFname.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStdF.TextBoxLname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateDeleteStdF.DateTimePicker1.Value = (DateTime)DataGridView1.CurrentRow.Cells[3].Value;
            if (DataGridView1.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
                updateDeleteStdF.RadioButtonFemale.Checked = true;
            updateDeleteStdF.TextBoxPhone.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateDeleteStdF.TextBoxAddress.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            //úp ảnh lên, hơi lâu
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteStdF.PictureBoxStudentImage.Image = Image.FromStream(picture);
            updateDeleteStdF.Show();
            //this.Close();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Std");
            DataGridView1.ReadOnly = true; //nạp lại dữ liệu trên dgv
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 90;
            DataGridView1.DataSource = student.getStudents(cmd);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridView1.AllowUserToAddRows = false;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LTWindows\17110094_NguyenAnh_Login\17110094_NguyenAnh_Login\DESKTOP-RRRHOP4.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter daSV = null;
        DataTable dtSV = null;
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            try
            {
                daSV = new SqlDataAdapter("select * from Std where fname like N'%" + txtSearch.Text + "%' ", conn);
                dtSV = new DataTable();
                daSV.Fill(dtSV);
                DataGridView1.DataSource = dtSV;
            }
            catch (SqlException)
            {
                MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _17110094_NguyenAnh_Login
{
    public partial class AdvancedSearch : Form
    {
        public AdvancedSearch()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
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
    }
}
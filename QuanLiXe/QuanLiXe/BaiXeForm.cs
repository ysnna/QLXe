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

namespace QuanLiXe
{
    public partial class BaiXeForm : Form
    {
        public BaiXeForm()
        {
            InitializeComponent();
        }

        private void BaiXeForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetBaiXe.BAIXE' table. You can move, or remove it, as needed.
            this.bAIXETableAdapter.Fill(this.dataSetBaiXe.BAIXE);
            MY_DB db = new MY_DB();
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from BAIXE", db.getConnection);
            //da.SelectCommand = cmd;
            //da.Fill(dt);
            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (Convert.ToInt32(dt.Rows[i][j]) == 0)
            //            dgvBaiXe.Rows[i].Cells[j].Value = false;
            //        else dgvBaiXe.Rows[i].Cells[j].Value = true;
            //    }
            //}
        }

        private void btBackThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
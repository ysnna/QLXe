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
using System.IO;
using System.Data;

namespace QuanLiXe.UserControls
{
    public partial class QuanLiTatCaXe : UserControl
    {
        MY_DB mydb = new MY_DB();
        KhachHang kh = new KhachHang();
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
            SqlCommand cmd = new SqlCommand("select * from QUANLIXERAVAO");
            dgvQuanLiAllXe.ReadOnly = true;
            //xử lí hình ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            dgvQuanLiAllXe.RowTemplate.Height = 90; //chỉnh pic đẹp
            dgvQuanLiAllXe.DataSource = kh.getCus(cmd);
            picCol = (DataGridViewImageColumn)dgvQuanLiAllXe.Columns[2];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            picCol1 = (DataGridViewImageColumn)dgvQuanLiAllXe.Columns[3];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvQuanLiAllXe.AllowUserToAddRows = false;
        }
    }
}

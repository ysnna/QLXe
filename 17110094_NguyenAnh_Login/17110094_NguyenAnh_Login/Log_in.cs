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
using System.Data;
using System.Linq;

namespace _17110094_NguyenAnh_Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_LOGIN_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            STUDENT student = new STUDENT();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Login", db.getConnection);
            //cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsername.Text;
            //cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;
            da.SelectCommand = cmd;
            da.Fill(dt);
            int count = dt.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (txtUsername.Text == dt.Rows[i]["username"].ToString() && txtPassword.Text == dt.Rows[i]["password"].ToString())
                        this.DialogResult = DialogResult.OK;
                }
                if (this.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Invalid Username or Password", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (chkAdmin.Checked == true)
            {
                MY_DB db = new MY_DB();
                SqlCommand cmm = new SqlCommand("select * from Login", db.getConnection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmm;
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                SqlCommand cmd = new SqlCommand("insert into Login (id, username, password)" +
                    " values (@id, @user, @pass)", db.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = countRow;
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;

                db.openConnection();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                }
                else
                {
                    db.closeConnection();
                }
                da.InsertCommand = cmd;
                da.Update(dt);
                MessageBox.Show("Sign up successful", "Adding...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
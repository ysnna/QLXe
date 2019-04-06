using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace _17110094_NguyenAnh_Login
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        MY_DB mydb = new MY_DB();
        private void Print_Load(object sender, EventArgs e)
        {
            DateTimePic3.CustomFormat = "yyyy-dd-MM";
            DateTimePic3.Format = DateTimePickerFormat.Custom;
            DateTimePick4.CustomFormat = "yyyy-dd-MM";
            DateTimePick4.Format = DateTimePickerFormat.Custom;
            // TODO: This line of code loads data into the '_DESKTOP_RRRHOP4DataSet1.SinhVien' table. You can move, or remove it, as needed.

            SqlCommand cmd = new SqlCommand("select * from Std");
            DataGridView2.ReadOnly = true;
            //xử lí hình ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
            DataGridView2.Width = 4500;
            DataGridView2.DataSource = student.getStudents(cmd);
            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridView2.AllowUserToAddRows = false;
        }

      

       

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            
            switch(NoRad.Checked==true)
            {
                case true:
                    {
                        if (radioButton1.Checked == true)
                        {
                            SqlCommand cmd = new SqlCommand("select * from Std");
                            DataGridView2.ReadOnly = true;
                            //xử lí hình ảnh, code có tham khảo msdn
                            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
                            DataGridView2.Width = 4500;
                            DataGridView2.DataSource = student.getStudents(cmd);
                            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            DataGridView2.AllowUserToAddRows = false;
                        }
                        else if (radioButton2.Checked == true)
                        {
                            SqlCommand command = new SqlCommand("select * from Std where gender = @gdr", mydb.getConnection);
                            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
                            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = "Female";
                            DataGridView2.ReadOnly = true;
                            //xử lí hình ảnh, code có tham khảo msdn
                            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
                            DataGridView2.Width = 4500;
                            DataGridView2.DataSource = student.getStudents(command);
                            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            DataGridView2.AllowUserToAddRows = false;
                            DataGridView2.Rows.Count.ToString();
                        }
                        else
                        {
                            SqlCommand command = new SqlCommand("select * from Std where gender = @gdr", mydb.getConnection);
                            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
                            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = "Male";
                            DataGridView2.ReadOnly = true;
                            //xử lí hình ảnh, code có tham khảo msdn
                            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
                            DataGridView2.Width = 4500;
                            DataGridView2.DataSource = student.getStudents(command);
                            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            DataGridView2.AllowUserToAddRows = false;
                        }
                    }
                    break;

                case false:
                    {
                        if (radioButton1.Checked == true)
                        {
                            SqlCommand cmd = new SqlCommand("select * from Std where bdate>@bda and bdate <@bda1 ", mydb.getConnection);
                            cmd.Parameters.Add("@bda", SqlDbType.DateTime).Value = DateTimePic3.Value;
                            cmd.Parameters.Add("@bda1", SqlDbType.DateTime).Value = DateTimePick4.Value;
                            DataGridView2.ReadOnly = true;
                            //xử lí hình ảnh, code có tham khảo msdn
                            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
                            DataGridView2.Width = 4500;
                            DataGridView2.DataSource = student.getStudents(cmd);
                            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            DataGridView2.AllowUserToAddRows = false;
                        }
                        else if (radioButton2.Checked == true)
                        {
                            SqlCommand command = new SqlCommand("select * from Std where gender = @gdr,bdate<@bda and bdate >@bda1", mydb.getConnection);
                            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
                            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = "Female";
                            command.Parameters.Add("@bda", SqlDbType.DateTime).Value = DateTimePic3;
                            command.Parameters.Add("@bda1", SqlDbType.DateTime).Value = DateTimePick4;
                            DataGridView2.ReadOnly = true;
                            //xử lí hình ảnh, code có tham khảo msdn
                            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
                            DataGridView2.Width = 4500;
                            DataGridView2.DataSource = student.getStudents(command);
                            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            DataGridView2.AllowUserToAddRows = false;
                            DataGridView2.Rows.Count.ToString();
                        }
                        else
                        {
                            SqlCommand command = new SqlCommand("select * from Std where gender = @gdr,bdate<@bda and bdate >@bda1", mydb.getConnection);
                            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
                            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = "Male";
                            command.Parameters.Add("@bda", SqlDbType.DateTime).Value = DateTimePic3;
                            command.Parameters.Add("@bda1", SqlDbType.DateTime).Value = DateTimePick4;
                            DataGridView2.ReadOnly = true;
                            //xử lí hình ảnh, code có tham khảo msdn
                            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                            DataGridView2.RowTemplate.Height = 90; //chỉnh pic đẹp
                            DataGridView2.Width = 4500;
                            DataGridView2.DataSource = student.getStudents(command);
                            picCol = (DataGridViewImageColumn)DataGridView2.Columns[7];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                            DataGridView2.AllowUserToAddRows = false;
                            DataGridView2.Rows.Count.ToString();
                        }
                    }
                    break;
            }

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\File.txt";
                TextWriter wrt = new StreamWriter(path);
                wrt.WriteLine("ID  \t\t   Fname     \t\t    Lname    \t\t     Bdate     \t\t    Gender     \t\t     Phone   \t\t        Address");
                for (int i = 0; i < DataGridView2.Rows.Count;i ++)
                {
                    for (int j = 0; j < DataGridView2.Rows.Count; j++)
                    {
                        wrt.Write("\t" + DataGridView2.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                    wrt.WriteLine("");
                    wrt.WriteLine("==========================================================================");

                }
                wrt.Close();
                MessageBox.Show("Save File was Completed");
            }
            catch (FileLoadException fe) { fe.Message.ToString(); }
        }
    }
}

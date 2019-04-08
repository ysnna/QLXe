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
using System.Drawing.Printing;

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
            // TODO: This line of code loads data into the '_DESKTOP_RRRHOP4DataSet3.Std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this._DESKTOP_RRRHOP4DataSet3.Std);
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

            switch (NoRad.Checked == true)
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
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text File|*.txt";
                var result = dialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                StringBuilder builder = new StringBuilder();
                int rowcount = DataGridView2.Rows.Count;
                int columncount = DataGridView2.Columns.Count;
                builder.AppendLine("Student ID   \tFirst Name  \tLast Name  \tDate of Birth        \tGender  \tPhone    \tAddress   ");
                builder.AppendLine("----------------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < rowcount; i++)
                {
                    List<string> cols = new List<string>();
                    for (int j = 0; j < columncount - 1; j++)
                    {
                        cols.Add(DataGridView2.Rows[i].Cells[j].Value.ToString());
                    }
                    builder.AppendLine(string.Join("\t", cols.ToArray()));
                }
                System.IO.File.WriteAllText(dialog.FileName, builder.ToString());
                MessageBox.Show(@"Text file was created.");
            }
            catch (FileLoadException fe) { fe.Message.ToString(); }
        }
    }
}
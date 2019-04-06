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
using System.Drawing.Imaging;

namespace _17110094_NguyenAnh_Login
{
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();
        MY_DB mydb = new MY_DB();
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LTWindows\17110094_NguyenAnh_Login\17110094_NguyenAnh_Login\DESKTOP-RRRHOP4.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlDataAdapter daSV = null;
        //DataTable dtSV = null;
        bool verif()
        {
            if ((TextBoxFname.Text.Trim() == "")
                || (TextBoxLname.Text.Trim() == "")
                || (TextBoxAddress.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (PictureBoxStudentImage.Image == null))
                return false;
            return true;
        }
        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id = Convert.ToInt32(TextBoxID.Text);
            string fname = TextBoxFname.Text;
            string lname = TextBoxLname.Text;
            DateTime bday = DateTimePicker1.Value;
            string phone = TextBoxPhone.Text;
            string addr = TextBoxAddress.Text;
            string gender = "Male";
            if (RadioButtonFemale.Checked) gender = "Female";
            MemoryStream pic = new MemoryStream();
            int bornyear = DateTimePicker1.Value.Year;
            int thisyear = DateTime.Now.Year;
            //sinh viên từ 10 - 100 có thể thay đổi
            if (((thisyear - bornyear) < 10) || ((thisyear - bornyear) > 100))
            {
                MessageBox.Show("The student age must be between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                if (student.insertStudent(id, fname, lname, bday, gender, phone, addr, pic))
                    MessageBox.Show("New student added", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Error", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Empty fields", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ButtonEditStudent_Click(object sender, EventArgs e)
        {
            int id;
            string fname = TextBoxFname.Text;
            string lname = TextBoxLname.Text;
            DateTime bdate = DateTimePicker1.Value;
            string phone = TextBoxPhone.Text;
            string adrs = TextBoxAddress.Text;
            string gender = "Male";
            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }
            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The student age must be between 10 and 100 year", "Birth date error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(TextBoxID.Text);
                    PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                    if (student.updateStudent(id, fname, lname, bdate, gender, phone, adrs, pic))
                    {
                        MessageBox.Show("Student information updated", "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty fields", "Edit student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = Convert.ToInt32(TextBoxID.Text);
                if (MessageBox.Show("Are you sure you want to delete this student?", "Delete student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    if (student.deleteStudent(studentID))
                    {
                        MessageBox.Show("Student deleted", " Delete student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBoxID.Text = "";
                        TextBoxFname.Text = "";
                        TextBoxLname.Text = "";
                        TextBoxAddress.Text = "";
                        TextBoxPhone.Text = "";
                        DateTimePicker1.Value = DateTime.Now;
                        PictureBoxStudentImage.Image = null;
                        RadioButtonFemale.Checked = false;
                        RadioButtonMale.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Student not deleted", "Delete student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxID.Text = "";
            TextBoxFname.Text = "";
            TextBoxLname.Text = "";
            TextBoxAddress.Text = "";
            TextBoxPhone.Text = "";
            DateTimePicker1.Value = DateTime.Now;
            PictureBoxStudentImage.Image = null;
            RadioButtonFemale.Checked = false;
            RadioButtonMale.Checked = false;
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "select image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
                PictureBoxStudentImage.Image = Image.FromFile(open.FileName);
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

        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = ("student_image_" + TextBoxID.Text);
            if (PictureBoxStudentImage.Image == null)
            {
                MessageBox.Show("No image in the Picture box");
            }
            else if (save.ShowDialog() == DialogResult.OK)
            {
                PictureBoxStudentImage.Image.Save(save.FileName + ("." + ImageFormat.Jpeg.ToString()));
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from std where Concat(fname, lname, address) like'%" + TextBoxSearch.Text + "%'");
            DataGridView1.ReadOnly = true;
            //xử lí hình ảnh, code có tham khảo msdn
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            DataGridView1.RowTemplate.Height = 90; //chỉnh pic đẹp
            DataGridView1.DataSource = student.getStudents(cmd);
            picCol = (DataGridViewImageColumn)DataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridView1.AllowUserToAddRows = false;
            TextBoxCountStudent.Text = DataGridView1.Rows.Count.ToString();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_DESKTOP_RRRHOP4DataSet2.Std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this._DESKTOP_RRRHOP4DataSet2.Std);
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

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBoxID.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
            TextBoxFname.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            TextBoxLname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            DateTimePicker1.Value = (DateTime)DataGridView1.CurrentRow.Cells[3].Value;
            if (DataGridView1.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
                RadioButtonFemale.Checked = true;
            else RadioButtonMale.Checked = true;
            TextBoxPhone.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            TextBoxAddress.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            byte[] pic;
            pic = (byte[])DataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            PictureBoxStudentImage.Image = Image.FromStream(picture);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text File|*.txt";
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            StringBuilder builder = new StringBuilder();
            int rowcount = DataGridView1.Rows.Count;
            int columncount = DataGridView1.Columns.Count;
            builder.AppendLine("Student ID   \tFirst Name  \tLast Name  \tDate of Birth        \tGender  \tPhone    \tAddress   ");
            builder.AppendLine("----------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < rowcount; i++)
            {
                List<string> cols = new List<string>();
                for (int j = 0; j < columncount - 1; j++)
                {
                    cols.Add(DataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                builder.AppendLine(string.Join("\t", cols.ToArray()));
            }
            System.IO.File.WriteAllText(dialog.FileName, builder.ToString());
            MessageBox.Show(@"Text file was created.");
        }
    }
}
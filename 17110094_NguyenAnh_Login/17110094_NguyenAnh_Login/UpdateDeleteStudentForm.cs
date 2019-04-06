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
using System.IO;

namespace _17110094_NguyenAnh_Login
{
    public partial class updateDeletStdF : Form
    {
        public updateDeletStdF()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            #region Tìm kiếm theo ID của Thầy 
            /*
            if (IsNumber(txtSearch.Text) == true)
            {
                int id = int.Parse(txtSearch.Text);
                SqlCommand cmd = new SqlCommand("select id, fname, lname, bdate, gender, phone, address, picture from Std where id = " + id);
                DataTable table = student.getStudents(cmd);
                if (table.Rows.Count >= 0)
                {
                    TextBoxID.Text = table.Rows[0]["id"].ToString();
                    TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                    TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                    DateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];
                    if (table.Rows[0]["gender"].ToString() == "Female")
                    {
                        RadioButtonFemale.Checked = true;
                    }
                    else RadioButtonMale.Checked = true;
                    TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                    TextBoxAddress.Text = table.Rows[0]["address"].ToString();
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    PictureBoxStudentImage.Image = Image.FromStream(picture);
                    MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                studentsListForm up = new studentsListForm();
                up.ShowDialog();

            }
            */
            #endregion
            MY_DB mydb = new MY_DB();
            if (IsNumber(TextBoxSearch.Text))   //tìm kiếm theo ID
            {
                int id = int.Parse(TextBoxSearch.Text);
                SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture from Std where id = " + id + "or phone = " + id, mydb.getConnection);
                //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    TextBoxID.Text = table.Rows[0]["id"].ToString();
                    TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                    TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                    DateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];
                    if (table.Rows[0]["gender"].ToString() == "Female")
                    {
                        RadioButtonFemale.Checked = true;
                    }
                    else
                    {
                        RadioButtonMale.Checked = true;
                    }
                    TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                    TextBoxAddress.Text = table.Rows[0]["address"].ToString();
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    PictureBoxStudentImage.Image = Image.FromStream(picture);
                }
                else MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else  //Tìm theo tên
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Std WHERE fname = @name", mydb.getConnection);
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    AdvancedSearch find = new AdvancedSearch();
                    find.DataGridView1.DataSource = student.getStudents(command);
                    find.DataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    find.DataGridView1.RowTemplate.Height = 90;
                    picCol = (DataGridViewImageColumn)find.DataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    find.DataGridView1.AllowUserToAddRows = false;
                    find.Show();
                }
                else MessageBox.Show("Not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "select image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
                PictureBoxStudentImage.Image = Image.FromFile(open.FileName);
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
    }
}
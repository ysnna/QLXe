using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _17110094_NguyenAnh_Login
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //kiểm tra dữ liệu input
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
            int id = Convert.ToInt32(txtStudentID.Text);
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

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "select image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (open.ShowDialog() == DialogResult.OK)
                PictureBoxStudentImage.Image = Image.FromFile(open.FileName);
        }
    }
}
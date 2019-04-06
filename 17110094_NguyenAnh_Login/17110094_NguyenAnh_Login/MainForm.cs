using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17110094_NguyenAnh_Login
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuAddNewStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm add = new AddStudentForm();
            add.Show(this);
        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentsListForm std = new studentsListForm();
            std.Show(this);
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm f = new ManageStudentForm();
            f.ShowDialog(this);
        }
    }
}
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
    public partial class StaticForm : Form
    {
        Color panTotalColor ;
        Color panMaleColor ;
        Color panFemaleColor ;
        public StaticForm()
        {

            InitializeComponent();
        }

     
        private void StaticForm_Load(object sender, EventArgs e)
        {
            
            panTotalColor = PanelTotal.BackColor;
            panMaleColor = PanelMale.BackColor;
            panFemaleColor = PanelFemale.BackColor;

            STUDENT student = new STUDENT();
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());

            double maleStudentsPercentage = (totalMale * (100 / total));
            double femaleStudentsPercentage = (totalFemale * (100 / total));
            LabelTotal.Text = ("Total Students: " + total.ToString());
            LabelMale.Text = ("Male: " + maleStudentsPercentage.ToString("0.00")+"%");
            LabelFemale.Text = ("Female: " + femaleStudentsPercentage.ToString("0.00") + "%");
        }
    }
}

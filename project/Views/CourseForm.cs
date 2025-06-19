using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project.Controllers;
using project.Models;

namespace project.Views
{
    public partial class CourseForm : Form
    {   
        private CourseController courseController = new CourseController();
        private int selectedCourseId = -1;

        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            Course_DGV.DataSource = null;
            Course_DGV.DataSource = courseController.GetAllCourses();
            Course_DGV.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Course course = new Course
            {
                CourseName = name_txt.Text.Trim(),
            };
            courseController.AddCourses(course);
            LoadCourses();
            name_txt.Clear();
        }

        private void name_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Course_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Data;
using project.Models;
using static System.Collections.Specialized.BitVector32;

namespace project.Controllers
{
    internal class CourseController
    {
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();

            using (var conn = Database.GetConnection())
            {
                string getQuery = "SELECT * FROM Courses";
                var cmd = new SQLiteCommand(getQuery, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseId = reader.GetInt32(0);
                    course.CourseName = reader.GetString(1);
                    courses.Add(course);

                }
            }
            return courses;
        }

        public void AddCourses(Course course)
        {
            using (var conn = Database.GetConnection())
            {
                string addQuery = "INSERT INTO Courses (CourseName) VALUES (@Name)";
                var cmd = new SQLiteCommand(addQuery, conn);
                cmd.Parameters.AddWithValue("@Name", course.CourseName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

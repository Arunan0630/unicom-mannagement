using System;
using System.Data.SQLite;

namespace project.Data
{
    internal class Migration
    {
        public static void CreateTable()
        {
            string TablesQ = @"CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Courses (
                    CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CourseName TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectName TEXT NOT NULL,
                    CourseID INTEGER NOT NULL,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                );
                CREATE TABLE IF NOT EXISTS Students (
                    StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    CourseID INTEGER NOT NULL,
                    FOREIGN KEY(CourseID) REFERENCES Courses(CourseID)
                );
                CREATE TABLE IF NOT EXISTS Exams (
                    ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ExamName TEXT NOT NULL,
                    SubjectID INTEGER NOT NULL,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
                );
                CREATE TABLE IF NOT EXISTS Marks (
                    MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER NOT NULL,
                    ExamID INTEGER NOT NULL,
                    Score INTEGER NOT NULL,
                    FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
                );
                CREATE TABLE IF NOT EXISTS Rooms (
                    RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomName TEXT NOT NULL,
                    RoomType TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Timetables (
                    TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                    SubjectID INTEGER NOT NULL,
                    TimeSlot TEXT NOT NULL,
                    RoomID INTEGER NOT NULL,
                    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
                    FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID)
                );";

            using (var conn = Database.GetConnection())
            {
                SQLiteCommand cmd = new SQLiteCommand(TablesQ, conn);
                cmd.ExecuteNonQuery();

                string checkAdminQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'Admin'";
                cmd = new SQLiteCommand(checkAdminQuery, conn);
                long adminCount = (long)cmd.ExecuteScalar();

                if (adminCount == 0)
                {
                    string insertAdminQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                    cmd = new SQLiteCommand(insertAdminQuery, conn);
                    cmd.Parameters.AddWithValue("@username", "admin");
                    cmd.Parameters.AddWithValue("@password", "admin123");
                    cmd.Parameters.AddWithValue("@role", "Admin");
                    cmd.ExecuteNonQuery(); 
                }
            }
        }
    }
}

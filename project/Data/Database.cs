using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data
{
    internal class Database
    {
        private static string Connectionstring = "Data Source=UnicomDB.db;Version=3;";
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(Connectionstring);
            connection.Open();
            return connection;
        }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UTS2
{
    class ConnectionString
    {
        public SqlConnection GetCon() 
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\KULIAH\Semester 2\OOP\UTS2\ClinicUTSDb.mdf;Integrated Security=True;Connect Timeout=30";
            return Con;
        }
    }
}

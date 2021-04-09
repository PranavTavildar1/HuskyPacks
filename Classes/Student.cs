using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;


namespace HuskyPacks.Classes
{
    public class Student
    {
        public string Name { get; }
        public string Email { get; }

        public string picture { get; }

        private string Password { get; set; }



        public Student(int studentID)
        {
            String strCommand;
            DataSet ds;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "SELECT * from students where id=" + studentID;
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                Name = row["name"].ToString();
                Email = row["email"].ToString();
                Password = row["password"].ToString();
                picture = "person_placeholder.png";

            }

        }

        public bool matchPassword(string pPassword)
        {
            if (pPassword == Password)
                return true;

            return false;
        }

    }
}
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
    public class StudentList
    {
        private Dictionary<int, string> _studentlist = new Dictionary<int, string>();
        public Dictionary<int, string> studentlist { get { return _studentlist; } }

        public StudentList()
        {
            String strCommand;
            DataSet ds;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "SELECT id, name from Students order by name";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _studentlist.Add(Convert.ToInt32(row["id"]), row["name"].ToString());
            }
        }
    }
}
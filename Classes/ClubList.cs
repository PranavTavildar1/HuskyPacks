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
    public class ClubList
    {
        private Dictionary<int, string> _clublist = new Dictionary<int, string>();
        public Dictionary<int, string> getClublist { get { return _clublist; } }

        public ClubList()
        {
            String strCommand;
            DataSet ds;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "SELECT id, name from clubs order by name";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _clublist.Add(Convert.ToInt32(row["id"]), row["name"].ToString());
            }

        }
    }
}

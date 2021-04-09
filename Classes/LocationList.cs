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
    public class LocationList
    {
        private Dictionary<int, string> _locationlist = new Dictionary<int, string>();
        public Dictionary<int, string> getlocationlist { get { return _locationlist; } }

        public LocationList()
        {
            String strCommand;
            DataSet ds;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "select *from locations order by building";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _locationlist.Add(Convert.ToInt32(row["id"]), row["building"].ToString());
            }

        }
    }
}
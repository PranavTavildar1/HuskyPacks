using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace HuskyPacks
{

    public class Designations
    {

        private Dictionary<int, string> _designations = new Dictionary<int, string>();
        public Dictionary<int, string> memberDesignations { get { return _designations; } }

        public Designations()
        {
            String strCommand;
            DataSet ds;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "SELECT id, position from member_designation order by position";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _designations.Add(Convert.ToInt32(row["id"]), row["position"].ToString());
            }

        }

        public static implicit operator Dictionary<object, object>(Designations v)
        {
            throw new NotImplementedException();
        }
    }
}
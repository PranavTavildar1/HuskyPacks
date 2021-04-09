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
    public class Member : Student
    {
        private static int id;
        public String designation { get; }
        public bool isExecutive { get; }

        public Member(int clubID, int studentID) : base(studentID)
        {
            String strCommand;
            DataSet ds;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "select b.position, b.isExec from club_membership a " +
                         "   join member_designation b on b.id = a.member_designation_id " +
                         "   where a.club_id = " + clubID + " and member_id=" + studentID + " order by b.id";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                designation = row["position"].ToString();
                isExecutive = (row["isExec"].ToString() == "Y");
            }

        }
    }
}
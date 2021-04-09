using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using HuskyPacks.Classes;

namespace HuskyPacks
{
    public class Club
    {
        private static int id;
        public string clubName { get; set; }
        public string clubDescription { get; set; }

        public string clubCategory { get; set; }

        public string clubPicture { get; set; }

        public string clubFoundingDate { get; set; }

        private List<Member> _clubMembers = new List<Member>();

        private List<Event> _Events = new List<Event>();


        public Club(int clubID)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);

            id = clubID;
            strCommand = "select name, description, picture, FORMAT(start_date, 'MM/dd/yyyy') as founding_date, category_name from Clubs a join club_categories b on a.category_id = b.id" + " where a.id = " + clubID;
            DataSet dsClubs = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);

            if (dsClubs.Tables[0].Rows.Count > 0)
            {

                DataRow dr = dsClubs.Tables[0].Rows[0];

                clubCategory = dr["category_name"].ToString();
                clubDescription = dr["description"].ToString();
                clubName = dr["name"].ToString();
                clubFoundingDate = dr["founding_date"].ToString();

                clubPicture = "image-placeholder.jpg";

                if (dr["picture"].ToString() != "") clubPicture = dr["picture"].ToString();
            }

        }

        public Club(String name, String desc, string picture)
        {

        }

        public List<Member> GetMembers()
        {
            if (_clubMembers.Count == 0)
                loadMembers();

            return _clubMembers;
        }

        public int addClubMember(int memberID, int designationID)
        {
            String strCommand;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "insert into club_membership(club_id, member_designation_id, member_id) values (" +
                            id + ", " + designationID + "," + memberID + ")";

            SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strCommand);

            loadMembers();

            return 0;
        }

        private void loadMembers()
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);

            strCommand = "select * from club_membership where club_id = " + id;
            DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                //members.Append(new Member(id, Int32.Parse(row["member_id"].ToString())));
                _clubMembers.Add(new Member(id, Int32.Parse(row["member_id"].ToString())));

            }
        }

        public int addEvent(string eventName, string eventDescription, string eventDateTime, string rsvp, string budget, int location_id, string roomNo, string imageFileName)
        {
            String strCommand;

            if (roomNo == "") roomNo = " ";
            if (budget == "0") budget = "0";



            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "insert into events (name,description, start_date, RSVPreq, budget, location_id,room_number, club_id, image ) values('" +
                                    eventName.Replace("'", "''") + "', '" +
                                    eventDescription.Replace("'", "''") + "', '" +
                                    eventDateTime + "', '" +
                                    rsvp + "', " +
                                    budget + ", " +
                                    location_id + ", '" +
                                    roomNo + "', " +
                                    id + ", '" +
                                    imageFileName + "')";

            SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strCommand);

            return 0;
        }

        public List<Event> GetEvents()
        {
            if (_Events.Count == 0)
                loadEvents();

            return _Events;
        }



        private void loadEvents()
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);

            strCommand = "select * from events where club_id = " + id  + " order by start_date desc";
            DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _Events.Add(new Event(Int32.Parse(row["id"].ToString())));
            }
        }

        public bool isMember(int memberid)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "select *from club_membership where club_id = " + id +"and member_id = "+ memberid;
            DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            DataRow dr;
            if (ds.Tables[0].Rows.Count != 0)
            {
                    return true;
            }
            return false;
        }

        public bool isExecutiveMember(int memberid)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "select b.isExec from club_membership a join member_designation b on a.member_designation_id = b.id where a.club_id = " + id + "and a.member_id = " + memberid;
            DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            DataRow dr;
            if (ds.Tables[0].Rows.Count != 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (dr["isExec"].ToString() == "Y")
                return true;
            }
            return false;
        }
    }
}


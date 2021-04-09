using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using HuskyPacks.Classes;
using System.Dynamic;

namespace HuskyPacks.Classes
{
    public class Event
    {
        private static int id;
        public string eventName { get; }
        public string eventDescription { get; }

        public DateTime eventDateTime { get; }
        public bool rsvpRequired { get; }

        public string buildingName { get; }

        public string buildingAddress1 { get; }
        public string buildingAddress2 { get; }

        public string roomNumber { get; }

        public string clubName { get; }

        public string clubDescription { get; }

        public string eventPicture { get; }

        public struct Attendees 
        {
            public string name;
            public string RSVP;
            public Attendees(string nm, string rs)
            {
                name = nm;
                RSVP = rs;
            }
        }

        public List<Attendees> _Attendees = new List<Attendees>();





        public Event(int eventID)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);

            id = eventID;
            strCommand = "select a.name, a.description, a.start_date, a.RSVPreq, a.image, a.room_number, b.building, b.address1, b.address2, c.name as clubName, c.description as clubDescription   from events a " +
                            " join locations b on a.location_id = b.id " +
                            " join clubs c on a.club_id = c.id " +
                            " where a.id=" + eventID;

            DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);

            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow dr = ds.Tables[0].Rows[0];

                eventName = dr["name"].ToString();
                eventDescription = dr["description"].ToString();
                eventDateTime = DateTime.Parse(dr["start_date"].ToString());
                rsvpRequired = false;
                if (dr["RSVPreq"].ToString() == "Y") rsvpRequired = true;
                buildingName = dr["building"].ToString();
                buildingAddress1 = dr["address1"].ToString();
                buildingAddress2 = dr["address2"].ToString();
                clubName = dr["clubname"].ToString();
                clubDescription = dr["clubDescription"].ToString();
                eventPicture = dr["image"].ToString();
                roomNumber = dr["room_number"].ToString();

            }

        }

        public void AddRSVP(int memberId)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "insert into attendee (RSVPed, attended, attendee_id, event_id) values ('Y','N'," + memberId+" ," + id + ")";
            SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strCommand);
        }

        public void CancelRSVP(int memberId)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "delete from attendee where attendee_id = "+memberId+" and event_id = "+id;
            SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strCommand);
        }

        public List<Attendees> GetAttendees()
        {

            _Attendees.Clear();

            if (_Attendees.Count == 0)
            {
                String strCommand;
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
                strCommand = "select RSVPed, b.name from attendee a join students b on a.attendee_id = b.id where a.event_id =" + id;
                DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    _Attendees.Add(new Attendees(row["name"].ToString(), row["RSVPed"].ToString()));
                }
            }

            return _Attendees;
        }

        public bool HasRSVPed(int memberID)
        {
            String strCommand;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            strCommand = "select *from attendee where attendee_id = "+memberID+" and event_id = " + id;
            DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            DataRow dr;
            if (ds.Tables[0].Rows.Count != 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (dr["RSVPed"].ToString() == "Y")
                {
                    return true;
                }
            }
            return false;
        }

    }
}

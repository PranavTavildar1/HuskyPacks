using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using HuskyPacks.Classes;
using System.Web.Security;

namespace HuskyPacks
{
    public partial class EventDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["AUTHUSER"] == null) Response.Redirect("Signin.aspx");
                hdnEventId.Value = Request.QueryString["id"];
                int eventID = Int32.Parse(Request.QueryString["id"]);
                Event oEvent = new Event(eventID);
                if (!IsPostBack)
                {
                    lblEventDescription.InnerHtml = oEvent.eventDescription;
                    lblEventName.InnerHtml = "<h1>" + oEvent.eventName + "</h1>";
                    lblEventDate.InnerHtml = oEvent.eventDateTime.ToString();
                    lblEventBuilding.InnerHtml = oEvent.buildingName + oEvent.roomNumber;
                    lblAddress1.InnerHtml = oEvent.buildingAddress1;
                    lblAddress2.InnerHtml = oEvent.buildingAddress2;
                    imgEvent.ImageUrl = "Images/" + oEvent.eventPicture;
                    showAttendees(oEvent.GetAttendees());

                }
                if (oEvent.HasRSVPed(Int32.Parse(Session["AUTHUSER"].ToString())))
                {
                    btnRSVP.Visible = false;
                    btnCancelRSVP.Visible = true;
                }
                else
                {
                    btnRSVP.Visible = true;
                    btnCancelRSVP.Visible = false;
                }
            }
            catch(NullReferenceException notLogged)
            {
                Response.Redirect("Signin.aspx");
            }
            
        }

        protected void btnRSVP_Click(object sender, EventArgs e)
        {
            Event oEvent = new Event(Int32.Parse(hdnEventId.Value));
            oEvent.AddRSVP(Int32.Parse(Session["AUTHUSER"].ToString()));
            showAttendees(oEvent.GetAttendees());
        }

        protected void btnCancelRSVP_Click(object sender, EventArgs e)
        {
            Event oEvent = new Event(Int32.Parse(hdnEventId.Value));
            oEvent.CancelRSVP(Int32.Parse(Session["AUTHUSER"].ToString()));
            showAttendees(oEvent.GetAttendees());
        }

        protected void showAttendees(List<Event.Attendees> AttendeeList)
        {
            String strHTML = "";

            strHTML = "<table class=\"table table-bordered\">" +
                          "<thead>" +
                          "    <tr>" +
                          "<th scope = \"col\" >Attendee Name</th>" +
                          "<th scope=\"col\">RSVP</th>" +
                          "</tr></thead><tbody>";

            foreach (Event.Attendees e in AttendeeList)
            {
                strHTML += "<tr>";
                strHTML += "<th scope=\"row\">" + e.name + "</th>";
                strHTML += "<td>" + e.RSVP + "</td>";
                strHTML += "</tr>";
            }

            strHTML += "</tbody></table >";

            panelAttendeeList.InnerHtml = strHTML;
        }
    }
}
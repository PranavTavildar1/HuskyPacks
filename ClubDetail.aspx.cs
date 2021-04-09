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
    public partial class ClubDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AUTHUSER"] == null) Response.Redirect("Signin.aspx");
                // Demonstration of application of DICTIONARY learnt in class
                // Used to get Student list and Designation lookup values
                StudentList oStudents = new StudentList();
                foreach (KeyValuePair<int, string> item in oStudents.studentlist)
                {
                    ddlStudents.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }

                Designations oDesignations = new Designations();
                foreach (KeyValuePair<int, string> item in oDesignations.memberDesignations)
                {
                    ddlRoles.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }

                hdnClubID.Text = Request.QueryString["id"];
                int clubID = Int32.Parse(Request.QueryString["id"]);

                // Gather club details and display on screen using the Club object.
                // Club objects demonstrates following
                // 1. Private/public properties
                // 2. Inheretance (Member object inherits from Student object)
                // 3. Usage of Data structure <List>
                Club oClub = new Club(clubID);
                lblCategory.InnerHtml = oClub.clubCategory;
                lblClubDescription.InnerHtml = oClub.clubDescription;
                lblClubName.InnerHtml = "<h1>" + oClub.clubName + "</h1>";
                lblFoundedOn.InnerHtml = oClub.clubFoundingDate;
                imgClub.ImageUrl = "Images/" + oClub.clubPicture;

                showExecutiveMembers(oClub.GetMembers());
                lblMemberCount.InnerHtml = oClub.GetMembers().Count().ToString() + " members";
                ShowClubEvents(oClub.GetEvents());
                LocationList oLocations = new LocationList();
                foreach (KeyValuePair<int, string> item in oLocations.getlocationlist)
                {
                    ddlBuilding.Items.Add(new ListItem(item.Value, item.Key.ToString()));
                }

                if( Session["AUTHUSER"].ToString() != "1")
                {
                    if (oClub.isMember(Int32.Parse(Session["AUTHUSER"].ToString())))
                    {
                        btnJoin.Visible = false;
                    }

                    if (!(oClub.isExecutiveMember(Int32.Parse(Session["AUTHUSER"].ToString()))))
                    {
                        btnAddNewEvent.Visible = false;
                        btnNewMember.Visible = false;
                    }


                }


            }
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {

            Club oClub = new Club(Int32.Parse(hdnClubID.Text));

            oClub.addClubMember(Int32.Parse(ddlStudents.SelectedValue), Int32.Parse(ddlRoles.SelectedValue));

            showExecutiveMembers(oClub.GetMembers());

            lblMemberCount.InnerHtml = oClub.GetMembers().Count().ToString() + " members";


        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            Club oClub = new Club(Int32.Parse(hdnClubID.Text));

            oClub.addClubMember(Int32.Parse(Session["AUTHUSER"].ToString()), 6);

            showExecutiveMembers(oClub.GetMembers());

            lblMemberCount.InnerHtml = oClub.GetMembers().Count().ToString() + " members";
        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            Club oClub = new Club(Int32.Parse(hdnClubID.Text));
            if(imgFile.FileName != "") imgFile.SaveAs(Server.MapPath("~/Images/" + imgFile.FileName));
            oClub.addEvent(txtName.Text, txtDescription.Text, txtDateTime.Text, ddlRSVP.SelectedValue, txtBudget.Text, Int32.Parse(ddlBuilding.SelectedValue), txtRoomNo.Text, imgFile.FileName);
            ShowClubEvents(oClub.GetEvents());

        }

        protected void showExecutiveMembers(List<Member> memberList)
        {
            String strHTML = "";

            strHTML = "<div class=\"row\">";

            foreach (Member clubMember in memberList)
            {
                if (clubMember.isExecutive)
                {
                    strHTML += "<div class=\"col-md-2\">";
                    strHTML += "<div class=\"thumbnail\">";
                    strHTML += "<img src=\"Images/" + clubMember.picture + "\" class=\"img-circle \" style=\"width:100%\">"; // </a>";
                    strHTML += "<div class=\"caption\"><p>" + clubMember.Name + "</p></div>";
                    strHTML += "<div class=\"caption\"><p>" + clubMember.designation + "</p></div>";
                    strHTML += "</div>";
                    strHTML += "</div>";
                }

            }
            strHTML += "</div>";

            panelExecs.InnerHtml = strHTML;
        }



        protected void ShowClubEvents(List<Event> eventList)
        {
            String strHTML = "";
            //strHTML = "<div class=\"container\">";

            strHTML = "<table class=\"table table-bordered\">" +
                          "<thead>" +
                          "    <tr>" +
                          "<th scope = \"col\" >Event Name</th>" +
                          "<th scope=\"col\">Event Date</th>" +
                          "<th scope = \"col\" >Venue</ th >" +
                          "</tr></thead><tbody>";

            foreach (Event e in eventList)
            {
                strHTML += "<tr>";
                strHTML += "<th scope=\"row\">" + e.eventName + "</th>";
                strHTML += "<td>" + e.eventDateTime + "</td>";
                strHTML += "<td>" + e.buildingName + "</td>";
                strHTML += "</tr>";
            }

            strHTML += "</tbody></table >";

            panelEventList.InnerHtml = strHTML;

        }
    }
}

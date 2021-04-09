using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using HuskyPacks.Classes;
using System.Dynamic;
using System.Drawing.Printing;

namespace HuskyPacks
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            String strCommand = "select top 3 * from Clubs a join club_categories b on a.category_id = b.id";
            DataSet catds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            string strHTML = "<div class=\"row\">";
            foreach (DataRow row in catds.Tables[0].Rows)
            {
                strHTML += "<div class=\"col-md-4\">";
                strHTML += "<h4>" + row["name"].ToString() + "</h4>";
                strHTML += "<p>" + row["description"].ToString() + "</p>";
                strHTML += "<p>" + "<a class=\"btn btn-default\" href=\"ClubDetail.aspx?id="+row["id"].ToString()+"\">Learn more &raquo;</a>"+"</p>";
                strHTML += "</div>";
            }
            strHTML += "</div>";
            panelFeaturedClubs.InnerHtml = strHTML;

            SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            String strCommand2 = "select top 3* from events";
            DataSet cards = SqlHelper.ExecuteDataset(connection2, CommandType.Text, strCommand2);
            string strHTML2 = "<div class=\"row\">";
            foreach (DataRow row in cards.Tables[0].Rows)
            {
                strHTML2 += "<div class=\"col-md-4\">";
                strHTML2 += "<h4>" + row["name"].ToString() + "</h4>";
                strHTML2 += "<p>" + row["description"].ToString() + "</p>";
                strHTML2 += "<p>" + "<a class=\"btn btn-default\" href=\"EventDetail.aspx?id=" + row["id"].ToString() + "\">Learn more &raquo;</a>" + "</p>";
                strHTML2 += "</div>";
            }
            strHTML2 += "</div>";
            panelFeaturedEvents.InnerHtml = strHTML2;
        }
    }
}
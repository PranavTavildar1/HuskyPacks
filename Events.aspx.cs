using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace HuskyPacks
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String strEventCard;
            String strEventImage;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            String strCommand = "select a.id,  a.name as EventName, a.start_date, a.image, b.name as ClubName,c.*  from events a join clubs b on a.club_id=b.id join locations c on a.location_id=c.id";

            strEventCard = "<div class=\"row\">";
            DataSet catds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in catds.Tables[0].Rows)
            {
                strEventImage = "image-placeholder.jpg";

                if (row["image"].ToString() != "") strEventImage = row["image"].ToString();
                strEventCard += "<div class=\"col-md-2\">";
                strEventCard += "<div class=\"thumbnail\">";
                strEventCard += "<a href = \"EventDetail.aspx?id=" + row["id"].ToString() + "\">";     // add link to club details page
                strEventCard += "<img src=\"Images/"+strEventImage+"\" style=\"width:100%\"></a>";
                strEventCard += "<div class=\"caption\"><p><h3>" + row["EventName"].ToString() + "</h3></p></div>";
                strEventCard += "<div class=\"caption\"><p>" + row["ClubName"].ToString() + "</p></div>";
                strEventCard += "<div class=\"caption\"><p>" + row["start_date"].ToString() + "</p></div>";
                strEventCard += "<div class=\"caption\"><p>" + row["building"].ToString() +" "+ row["roomNo"]+ "</p></div>";
                strEventCard += "</div>";
                strEventCard += "</div>";
            }
            strEventCard += "</div>";
            divEventList.InnerHtml = strEventCard;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("addEvent.aspx");
        }
    }
}
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
using System.Security.Policy;
using System.Web.UI.WebControls.Expressions;

namespace HuskyPacks
{
    public partial class Clubs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String strClubCards;
            String strClubImage;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);


            String strCommand = "select * from Clubs a join club_categories b on a.category_id = b.id";
            if (txtSearchClubs.Text != "") strCommand = strCommand + " where a.Name like '%" + txtSearchClubs.Text + "%'";
           

            strClubCards = "<div class=\"row\">";
            DataSet catds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);


            foreach (DataRow row in catds.Tables[0].Rows)
            {

                strClubImage = "image-placeholder.jpg";

                if (row["picture"].ToString() != "" ) strClubImage = row["picture"].ToString();
                strClubCards += "<A HREF=\"ClubDetail.aspx?id=" + row["id"].ToString() +  "\">";
                strClubCards += "<div class=\"col-md-2\">";
                strClubCards += "<div class=\"thumbnail\">";
                strClubCards += "<img src=\"Images/" + strClubImage+ "\" style=\"width:100%\">"; // </a>";
                strClubCards += "<div class=\"caption\"><p><h3>" + row["Name"].ToString() + "</h3></p></div>";
                strClubCards += "<div class=\"caption\"><p>" + row["Description"].ToString().Substring(0, IIf(row["Description"].ToString().Length < 60,row["Description"].ToString().Length, 60)) + "...</p></div>";
                strClubCards += "</div>";
                strClubCards += "</div>";
                strClubCards += "</A>";
            }
            strClubCards += "</div>";

            panelClubList.InnerHtml = strClubCards;
            //phClubList.Controls.Add(new Literal() { Text = "\"" + strClubCards + "\"" });

        }
        private int IIf(bool Expression, int TruePart, int FalsePart)
        {
            int ReturnValue = Expression == true ? TruePart : FalsePart;

            return ReturnValue;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("addClub.aspx");
        }
    }
}
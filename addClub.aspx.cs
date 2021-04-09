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
    public partial class addClub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            String strCommand = "select *from club_categories order by category_name";
            DataSet catds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            foreach (DataRow row in catds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(row["category_name"].ToString(), row["id"].ToString()));
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);

            if (imgFile.FileName != "")
                imgFile.SaveAs(Server.MapPath("~/Images/" + imgFile.FileName));

            String strCommand = "insert into clubs (name,description, start_date, status, budget, category_id, picture) values('" +
                                    txtClubName.Text.ToString()+"', '"+
                                    txtDescription.Text.ToString() + "', '" +
                                    txtFoundingDate.Text.ToString() + "', '" +
                                    ddlStatus.SelectedValue.ToString() + "', " +
                                    txtBudget.Text.ToString() + ", " +
                                    ddlCategory.SelectedValue.ToString()+", '" +
                                    imgFile.FileName + "')";
            SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strCommand);
            panelSuccessAlert.Visible = true;
        }
    }
}
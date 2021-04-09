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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            String strCommand = "";
            DataSet ds;
            DataRow dr;

            strCommand = "select * from students where email = '" + txtUsername.Text +"'";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
             
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                if (dr["password"].ToString() == txtPassword.Text)
                {
                    Response.Redirect("Default.aspx");
                }
               
            }
            lblLoginError.Text = "Invalid UserId or password !";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
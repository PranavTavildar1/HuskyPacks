using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace HuskyPacks
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["hpDB"].ConnectionString);
            String strCommand;
            DataSet ds;

            panelError.Visible = false;
           panelSuccessAlert.Visible = false;


            if (txtName.Text == "")
            {
                divErrorMessage.InnerText = "Student name cannot be empty. Please Try again.";
                panelError.Visible = true;
                return;
            }


            // Validate that password and confirm password match
            if (txtPassword.Text != txtConfirm.Text)
            {
                divErrorMessage.InnerText = "Password and Confirm Password do not match. Please Try again.";
                panelError.Visible = true;
                return;
            }

            // Validate that another user with same email does not exist.
            strCommand = "select * from Students where email='" + txtEmail.Text + "'";
            ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, strCommand);
            if (ds.Tables[0].Rows.Count > 0 )
            {
                divErrorMessage.InnerText = "A Student with this email id already exist !";
                panelError.Visible = true;
                return;
            }

            strCommand = "insert into Students (name, email, password) values ('" +
                                txtName.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "')";
            SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strCommand);

            panelError.Visible = false;
            panelSuccessAlert.Visible = true;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
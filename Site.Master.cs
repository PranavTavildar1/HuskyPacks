using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuskyPacks
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USERNAME"] != null)
            {
                lblUserName.Text = Session["USERNAME"].ToString();
                lnkLogin.Visible = false;
                panelUserName.Visible = true;
            }
            else
            {
                lnkLogin.Text = "Log in";
                panelUserName.Visible = false;
            }

        }
    }
}
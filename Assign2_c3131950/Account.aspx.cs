using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign2_c3131950
{
    public partial class AccountManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Redirect to login page if not logged in
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            string url = "Home.aspx";
            ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('You are logged out.');window.location.href = '" + url + "';", true);
        }

        protected void DeleteAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void pointsUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("PointsUpload.aspx");

        }
    }
}
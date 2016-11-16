using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign2_c3131950
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            changePassword();

            
        }
        protected void changePassword() {
            int result = 0;
            string connectStr = ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectStr))
                {
                    using (SqlCommand command = new SqlCommand("CHANGEPASSWORD"))
                    {
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter()) {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@Email",HttpContext.Current.Session["email"].ToString() );
                            command.Parameters.AddWithValue("@OldPassword",oldpassword.Text.Trim());
                            command.Parameters.AddWithValue("@NewPassword",newpassword.Text.Trim());
                            command.Connection = con;
                            con.Open();
                            result = Convert.ToInt32(command.ExecuteScalar());
                            con.Close();
                        }
                    }
                }
                string message = "";
                switch (result)
                {
                    case -1: message = "Wrong Password"; break;

                    default: message = "ChangeSuccessful";
                        Response.Write("<script language='javascript'>window.alert('Password Change Successful');window.location='Account.aspx';</script>");
                        break;

                }
                
            }
            catch {

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign2_c3131950
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["email"] != null) {
                Response.Redirect("Account.aspx");
            }
            if (!Page.IsPostBack)
            {
                ViewState["GoBackTo"] = Request.UrlReferrer;
                
            }

        }

        protected void ValidateUser()
        {
            string userName = usernameText.Text.Trim();
            string password = passwordText.Text.Trim();
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Validate_Login"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmailAddress", userName);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                    
                  
                    switch (userId)
                    {
                        case -1:
                            Response.Write("<script language='javascript'>window.alert('Login Failed: Check Email or password')</script>");

                            break;
                        default:
                            Session["email"] = userName;
                            Session["userID"] = userId;
                            if (!ViewState["GoBackTo"].ToString().Contains("Splash.aspx")) {
                                Response.Redirect(ViewState["GoBackTo"].ToString()); //redirects to previous page
                            }else
                            {
                                Response.Write("<script language='javascript'>window.alert('Login Successful');window.location='Account.aspx';</script>");
                            }
                            break;
                    }
                }
            }

            catch (SqlException err)
            {   
                
            }
            catch (Exception err)
            {
             
            }
           
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }
    }
}
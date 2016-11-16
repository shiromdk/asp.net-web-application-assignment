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
    public partial class Delete : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void button_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("DisableAccount",con))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Email", Session["email"].ToString());
                        command.Parameters.AddWithValue("@Password", password.Text);
                        command.ExecuteNonQuery();
                    }
                }
                

                con.Close();
                Session.Abandon();
            }
                Response.Redirect("Home.aspx");
        }
    }
}
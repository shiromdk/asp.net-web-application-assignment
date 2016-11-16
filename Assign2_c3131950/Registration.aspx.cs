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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterAccountClick(object sender, EventArgs e)
        {
            int userID = 0;
            string connectStr = ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectStr))
                {
                    using (SqlCommand command = new SqlCommand("Insert_Account"))
                    {

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@FirstName", firstNameText.Text.Trim());
                            command.Parameters.AddWithValue("@LastName", surnameText.Text.Trim());
                            command.Parameters.AddWithValue("@Email", emailTextBox.Text.Trim());
                            command.Parameters.AddWithValue("@Password", passwordTextBox.Text);
                            command.Parameters.AddWithValue("@MobileNumber", mobileNumberText.Text.Trim());
                            command.Connection = con;
                            con.Open();
                            userID = Convert.ToInt32(command.ExecuteScalar());
                            con.Close();
                        }
                    }


                    switch (userID)
                    {
                        case -1: Response.Write("<script language='javascript'>window.alert('Email Address Already Exists')</script>"); ; break;

                        default: Response.Write("<script language='javascript'>window.alert('Account successfully created');window.location='Account.aspx';</script>"); break;

                    }
                    
                }
            }
            catch {
            }

           
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}

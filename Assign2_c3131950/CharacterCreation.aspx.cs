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
    public partial class CharacterCreation : System.Web.UI.Page
    {
        protected void CancelChar(object sender, EventArgs e)
        {
            Response.Redirect("Character.aspx");
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            createTitan();
        }
        protected void createTitan() {
            string connectStr = ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString;
            int elementID = elementList.SelectedIndex + 1;
            int experienceID = 1;
            int userID = Int32.Parse(HttpContext.Current.Session["userID"].ToString());
            int titanID = 0;
           
             
                using (SqlConnection con = new SqlConnection(connectStr))
                {
                    using (SqlCommand command = new SqlCommand("Insert_Titan"))
                    {

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@TitanName", Character.Text.Trim());
                            command.Parameters.AddWithValue("@TitanElement", elementID);
                            command.Parameters.AddWithValue("@ExperienceID", experienceID);
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@Experience", "1");
                            command.Connection = con;
                            con.Open();
                            titanID = Convert.ToInt32(command.ExecuteScalar());
                            con.Close();
                        }
                    }
             

                string message = "";
                switch (titanID)
                {
                    case -1: message = "Titan with this name already.\\nPlease choose a different email adress."; break;
                    case -2:message = "Titan already exists with this element"; break;

                    default: message = "Character Created! " + titanID.ToString(); break;

                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
         
                
            }

        }

    }


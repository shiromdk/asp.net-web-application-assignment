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
    public partial class CharacterSelect : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["email"]==null) {
                Response.Redirect("Login.aspx");
            }
            //makes sure the drop down list is only bound once
            if (!Page.IsPostBack) {
                ViewState["GoBackTo"] = Request.UrlReferrer;
                LoadDropDownList();
            }
            
        }

        protected void Select(object sender, EventArgs e)
        {
            //if statement makes sure that a titan is selected.
            if (characterList.SelectedIndex == 0) {
                string message = "Please Select a Character from the the dropdown list";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

            }
            else
            {

                Session["SelectedCharacter"] = characterList.SelectedItem.Text.Trim();
                Session["SelectedTitanID"] = characterList.SelectedItem.Value.Trim();
                //this sql query gets selected titan Element
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand("SELECT ElementID From Titan WHERE TitanID=@TitanID", con))
                        {
                            command.Parameters.AddWithValue("@TitanID", Session["SelectedTitanID"].ToString());
                            Session["SelectedTitanElement"] = Int32.Parse(command.ExecuteScalar().ToString());
                        }
                        con.Close();
                    }
                }
                catch
                {

                }

                Response.Redirect(ViewState["GoBackTo"].ToString()); // goes back to previous page
            }
           
        }

        private void LoadDropDownList() {

            DataTable characters = new DataTable();
            
            string email = HttpContext.Current.Session["email"].ToString();
            string sqlQuery = "SELECT TitanID,TitanName from Titan INNER JOIN UserAccount ON Titan.UserID=UserAccount.UserID WHERE UserAccount.EmailAddress = @email AND ExperienceID<>17";
            try
            {
                //tries connecting to database
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    //grabs names of titans from database assosciated with account
                    using (SqlCommand command = new SqlCommand(sqlQuery, con)) {
                        command.Parameters.AddWithValue("@email", email);
                        command.ExecuteNonQuery();
                        using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                            adapter.SelectCommand = command;
                            //Fills the list with the names of all the characters
                            adapter.Fill(characters);
                            characterList.DataSource = characters;
                            characterList.DataTextField = "TitanName";
                            characterList.DataValueField = "TitanID";
                            characterList.DataBind();
                        }
                            
                    }
                  


                }
            }
            catch (SqlException err)
            {
               
            }
           
            characterList.Items.Insert(0, new ListItem("<Select Character>", "0"));
            if (characterList.Items.Count == 1) {
                Response.Redirect("CharacterCreation.aspx");
            }
        }
    }
}
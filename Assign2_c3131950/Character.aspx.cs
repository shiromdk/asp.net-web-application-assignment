using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign2_c3131950
{
    public partial class Character : System.Web.UI.Page
    {
     
        protected void SelectCharacter_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("CharacterSelect.aspx");
        }

        protected void CreateCharacter_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharacterCreation.aspx");
        }

        protected void ManagePoints_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageExercisePoints.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Redirects to login if not logged in
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //checks if a character has been selected and displays the result
            if (HttpContext.Current.Session["SelectedCharacter"] == null)
            {
                characterNameLabel.Text = "No Character Currently Selected";
            }
            else {
                characterNameLabel.Text = HttpContext.Current.Session["SelectedCharacter"].ToString();
                manageCharacterImage();
                loadCharacterStats();
            }
            
        }
        protected void loadCharacterStats() {
            string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
            string sqlQueryGetLevel = "SELECT Level FROM Experience INNER JOIN Titan ON Experience.ExperienceID=Titan.ExperienceID WHERE TitanID=@Titan";
            string sqlQueryGetExperience = "SELECT Experience FROM Titan WHERE TitanID=@Titan";

            try
            {
                using (SqlConnection con = new SqlConnection(constr)) {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQueryGetLevel,con)) {
                        command.Parameters.AddWithValue("@Titan",Session["SelectedTitanID"].ToString());
                        LevelText.Text = command.ExecuteScalar().ToString();

                    }

                    using (SqlCommand command = new SqlCommand(sqlQueryGetExperience, con)) {
                        command.Parameters.AddWithValue("@Titan", Session["SelectedTitanID"].ToString());
                        double experienceDouble = Double.Parse(command.ExecuteScalar().ToString());
                        XPText.Text = Math.Round(experienceDouble, 1).ToString();
                    }
                    con.Close();
                }
            }
            catch {

            }
        }

        protected void manageCharacterImage() {
            int result = Int32.Parse(Session["SelectedTitanElement"].ToString()); //stores the element of the character
       
           
               
                characterImage.Visible = true;
                switch (result) {
                    case 1:characterImage.ImageUrl = "Images/earth.jpg"; break;
                    case 2: characterImage.ImageUrl = "Images/air.jpg"; break;
                    case 3: characterImage.ImageUrl = "Images/water.jpg"; break;
                    case 4: characterImage.ImageUrl = "Images/fire.jpg"; break;
                    default: characterImage.Visible = false; break;

                }
                Session["CharacterImageUrl"] = characterImage.ImageUrl;
            
        }
    }
}
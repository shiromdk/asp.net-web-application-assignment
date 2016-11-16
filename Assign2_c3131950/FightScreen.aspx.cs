using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//this page will pull details from the database and generate the appropriate images and text
//for the fight scene
namespace Assign2_c3131950
{
    public partial class FightScreen : System.Web.UI.Page
    {
        int challengerID = 0;
        int challengerElement = 0;
        string challengerName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            generateBattleScreen();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            generateResult(Int32.Parse(Session["BattleID"].ToString())); 
            Response.Redirect("FightOutcome.aspx");
        }
        protected void generateBattleScreen() {
            string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
            string sqlQueryTitanID = "SELECT Challenger FROM Battle WHERE BattleID=@BattleID";
            string sqlQueryTitanName = "SELECT TitanName FROM Titan WHERE TitanID=@Challenger";
            string sqlQueryChallengerElement = "SELECT ElementID From Titan Where TitanID=@Challenger";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQueryTitanID, con))
                    {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        challengerID = Int32.Parse(command.ExecuteScalar().ToString());
                    }


                    using (SqlCommand command = new SqlCommand(sqlQueryTitanName, con))
                    {
                        command.Parameters.AddWithValue("@Challenger", challengerID);
                        challengerName = command.ExecuteScalar().ToString();

                    }


                    using (SqlCommand command = new SqlCommand(sqlQueryChallengerElement, con))
                    {
                        command.Parameters.AddWithValue("@Challenger", challengerID);
                        challengerElement = Int32.Parse(command.ExecuteScalar().ToString());

                    }
                        con.Close();
                }
            }
            catch
            {

            }
            ImageGenerator(challengerElement,challengerName);

            
        }

        //generates the images for the fight screen
        protected void ImageGenerator(int challengerElement,string challengerName) {
            if (Session["CharacterImageUrl"] == null)
            {
                switch (Session["SelectedTitanElement"].ToString())
                {
                    case "1": Session["CharacterImageUrl"] = "Images/earth.jpg"; break;
                    case "2": Session["CharacterImageUrl"] = "Images/air.jpg"; break;
                    case "3": Session["CharacterImageUrl"] = "Images/water.jpg"; break;
                    case "4": Session["CharacterImageUrl"] = "Images/fire.jpg"; break;
                    default:  break;
                }
            }
            
            Challenged.ImageUrl = Session["CharacterImageUrl"].ToString();
            
            
            ChallengedLabel.Text = Session["SelectedCharacter"].ToString().Trim();
            switch (challengerElement) {
         
                    case 1:Challenger.ImageUrl = "Images/earth.jpg"; break;
                    case 2: Challenger.ImageUrl = "Images/air.jpg"; break;
                    case 3: Challenger.ImageUrl = "Images/water.jpg"; break;
                    case 4: Challenger.ImageUrl = "Images/fire.jpg"; break;
            }
            ChallengerLabel.Text = challengerName;

        }

        //this function works out the appropriate bonus a titan should get against another titan
        //will be called twice for each titan
        private double elementBonus(int element1, int element2)
        {
            double result = 0.0;
            if (element1 == 1 && element2 == 3) result = 0.15;
            if (element1 == 2 && element2 == 1) result = 0.15;
            if (element1 == 3 && element2 == 4) result = 0.15;
            if (element1 == 4 && element2 == 2) result = 0.15;
            return result;
        }
        //this is for the random bonus function. returns false when 0 or true when 1
        private bool randomBonus()
        {
            bool result = false;
            Random r = new Random();
            int randomNumber = r.Next(2);
            if (randomNumber == 1)
                result = true;
            return result;
        }

        //this method will be called to generate the result of a battle. it will only be called from the challenged side.
        public void generateResult(int BattleID)
        {
            int challengerID=0;
            int challengerElement=0;
            double challengerXP=0;
            double challengedXP=0;
            string constr = ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("SELECT Challenger FROM Battle WHERE BattleID=@BattleID", con))
                    {
                        command.Parameters.AddWithValue("@BattleID", BattleID);
                        challengerID = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    using (SqlCommand command = new SqlCommand("SELECT ElementID FROM Titan WHERE TitanID=@Challenger", con))
                    {
                        command.Parameters.AddWithValue("@Challenger", challengerID);
                        challengerElement = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    using (SqlCommand command = new SqlCommand("SELECT Experience FROM Titan WHERE TitanID=@Challenger", con))
                    {
                        command.Parameters.AddWithValue("@Challenger", challengerID);
                        challengerXP = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    using (SqlCommand command = new SqlCommand("SELECT Experience FROM Titan WHERE TitanID=@Challenged", con))
                    {
                        command.Parameters.AddWithValue("@Challenged", HttpContext.Current.Session["SelectedTitanID"].ToString());
                        challengedXP = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    con.Close();
                }
            }
            catch
            {

            }


            //setting up the values which will be used to determine the fight
            double challengerFightXP=challengerXP;
            double challengedFightXP=challengedXP;

            //adding element bonuses to each XP value
            challengedFightXP += challengedXP*elementBonus(Int32.Parse(Session["SelectedTitanElement"].ToString()), challengerElement);
            challengerFightXP += challengerXP*elementBonus(challengerElement,Int32.Parse(Session["SelectedTitanElement"].ToString()));

            //challenger 25% xp bonus
            challengerFightXP += challengerXP * 0.25;
            //generating random bonus
            bool randomBonusAllocation = randomBonus();

            //if false then challenger receivers bonus otherwise challenged recieves bonus
            if (randomBonusAllocation)
            {
                challengerFightXP += challengerXP * 0.25;
            }
            else {
                challengedFightXP += challengedXP * 0.25;
            }


            //rounding xp numbers to nearest integer
            challengedFightXP = Math.Round(challengedFightXP, MidpointRounding.AwayFromZero);
            challengerFightXP = Math.Round(challengerFightXP, MidpointRounding.AwayFromZero);
            int winnerID = 0;
            //Check Winner
            if (challengedFightXP > challengerFightXP)
            {
                winnerID = Int32.Parse(Session["SelectedTitanID"].ToString());
            }
            else {
                winnerID = challengerID;
            }

            //updating the battle results
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE Battle SET BattleCompleted='True',Winner=@WinnerID WHERE BattleID=@BattleID", con))
                    {
                        command.Parameters.AddWithValue("@WinnerID", winnerID);
                        command.Parameters.AddWithValue("@BattleID", BattleID);
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch {

            }
        }






    }

}
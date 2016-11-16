using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// This is the npc fight page which the user gets redirected to if the issue challenge page sees that the
/// user has challenged an NPC
/// </summary>
namespace Assign2_c3131950
{
    public partial class NpcFightPage : System.Web.UI.Page
    {
        int npcID = 0;
        int npcElement = 0;
        string npcName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            generateBattleScreen();

        }
        protected void ImageGenerator(int npcElement, string npcName)
        {
            if (Session["CharacterImageUrl"] == null)
            {
                switch (Session["SelectedTitanElement"].ToString())
                {
                    case "1": Session["CharacterImageUrl"] = "Images/earth.jpg"; break;
                    case "2": Session["CharacterImageUrl"] = "Images/air.jpg"; break;
                    case "3": Session["CharacterImageUrl"] = "Images/water.jpg"; break;
                    case "4": Session["CharacterImageUrl"] = "Images/fire.jpg"; break;
                    default: break;
                }
            }

            User.ImageUrl = Session["CharacterImageUrl"].ToString();


            UserLabel.Text = Session["SelectedCharacter"].ToString().Trim();
            switch (npcElement)
            {

                case 1: NPC.ImageUrl = "Images/earthnpc.jpg"; break;
                case 2: NPC.ImageUrl = "Images/airnpc.jpg"; break;
                case 3: NPC.ImageUrl = "Images/waternpc.jpg"; break;
                case 4: NPC.ImageUrl = "Images/firenpc.png"; break;
            }
            NPCLabel.Text = npcName;

        }

        protected void generateBattleScreen()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
            string sqlQueryTitanID = "SELECT Challenged FROM Battle WHERE BattleID=@BattleID";
            string sqlQueryTitanName = "SELECT TitanName FROM Titan WHERE TitanID=@Challenged";
            string sqlQueryChallengerElement = "SELECT ElementID From Titan Where TitanID=@Challenged";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQueryTitanID, con))
                    {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        npcID = Int32.Parse(command.ExecuteScalar().ToString());
                    }


                    using (SqlCommand command = new SqlCommand(sqlQueryTitanName, con))
                    {
                        command.Parameters.AddWithValue("@Challenged", npcID);
                        npcName = command.ExecuteScalar().ToString();

                    }


                    using (SqlCommand command = new SqlCommand(sqlQueryChallengerElement, con))
                    {
                        command.Parameters.AddWithValue("@Challenged", npcID);
                        npcElement = Int32.Parse(command.ExecuteScalar().ToString());

                    }
                    con.Close();
                }
            }
            catch
            {

            }
            ImageGenerator(npcElement, npcName);


        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            generateResult(Int32.Parse(Session["BattleID"].ToString()));
            Response.Redirect("NpcFightOutcome.aspx");
        }


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


        public void generateResult(int BattleID)
        {

            double userXP = 0;
            double npcXP = 0;
            string constr = ConfigurationManager.ConnectionStrings["connectStr"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("SELECT Challenged FROM Battle WHERE BattleID=@BattleID", con))
                    {
                        command.Parameters.AddWithValue("@BattleID", BattleID);
                        npcID = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    using (SqlCommand command = new SqlCommand("SELECT ElementID FROM Titan WHERE TitanID=@Challenged", con))
                    {
                        command.Parameters.AddWithValue("@Challenged", npcID);
                        npcElement = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    using (SqlCommand command = new SqlCommand("SELECT Experience FROM Titan WHERE TitanID=@Challenged", con))
                    {
                        command.Parameters.AddWithValue("@Challenged", npcID);
                        npcXP = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    using (SqlCommand command = new SqlCommand("SELECT Experience FROM Titan WHERE TitanID=@Challenger", con))
                    {
                        command.Parameters.AddWithValue("@Challenger", HttpContext.Current.Session["SelectedTitanID"].ToString());
                        userXP = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    con.Close();
                }
            }
            catch
            {

            }


            //setting up the values which will be used to determine the fight
            double userFightXP = userXP;
            double npcFightXP = npcXP;

            //adding element bonuses to each XP value
            userFightXP += userXP * elementBonus(Int32.Parse(Session["SelectedTitanElement"].ToString()), npcElement);
            npcFightXP += npcXP * elementBonus(npcElement, Int32.Parse(Session["SelectedTitanElement"].ToString()));

            //challenger 25% xp bonus
            userFightXP += userXP * 0.25;
            //generating random bonus
            bool randomBonusAllocation = randomBonus();

            //if false then challenger receivers bonus otherwise challenged recieves bonus
            if (randomBonusAllocation)
            {
                userFightXP += userXP * 0.25;
            }
            else {
                npcFightXP += npcXP * 0.25;
            }


            //rounding xp numbers to nearest integer
            npcFightXP = Math.Round(npcFightXP, MidpointRounding.AwayFromZero);
            userFightXP = Math.Round(userFightXP, MidpointRounding.AwayFromZero);
            int winnerID = 0;
            //Check Winner
            if (npcFightXP > userFightXP)
            {
                winnerID = npcID;
                
            }
            else {
                winnerID = Int32.Parse(Session["SelectedTitanID"].ToString());
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
            catch
            {

            }
        }






    }
}

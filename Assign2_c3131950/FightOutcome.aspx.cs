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
    public partial class FightOutcome : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            showResult();
            updateXP();
            //removes BattleID
            Session.Remove("BattleID");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        //this function increases the xp appropriately and level
        protected void updateXP() {
            float winnerXP = 0;
            float currentXPUp = 0;
            string winnerName="";
            string sqlQuerygetWinnerName = "SELECT TitanName FROM Titan INNER JOIN Battle ON Titan.TitanID=Battle.Winner WHERE BattleID=@BattleID ";
            string sqlQueryUpdate = "UPDATE Titan SET Experience=Experience*1.25 WHERE TitanName=@TitanName";
            string sqlQuerySelectXP = "SELECT Experience FROM Titan WHERE TitanName=@TitanName ";
            string sqlQuerySelectCurrentXPUp = "SELECT ExperienceUP FROM Experience INNER JOIN Titan ON Experience.ExperienceID=Titan.ExperienceID WHERE TitanName=@TitanName";
            string sqlQueryLevelUp = "UPDATE Titan SET ExperienceID=ExperienceID+1 WHERE TitanID=@TitanName";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuerygetWinnerName, con))
                    {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        winnerName = command.ExecuteScalar().ToString();
                    }
                    using (SqlCommand command = new SqlCommand(sqlQueryUpdate, con))
                    {
                        command.Parameters.AddWithValue("@TitanName", winnerName);
                        command.ExecuteNonQuery();

                    }
                    using (SqlCommand command = new SqlCommand(sqlQuerySelectXP, con))
                    {
                        command.Parameters.AddWithValue("@TitanName", winnerName);
                        winnerXP = float.Parse(command.ExecuteScalar().ToString());
                    }

                    using (SqlCommand command = new SqlCommand(sqlQuerySelectCurrentXPUp, con))
                    {
                        command.Parameters.AddWithValue("@TitanName", winnerName);
                        currentXPUp = float.Parse(command.ExecuteScalar().ToString());
                    }
                    if (winnerXP > currentXPUp)
                    {
                        using (SqlCommand command = new SqlCommand(sqlQueryLevelUp, con))
                        {
                            command.Parameters.AddWithValue("@TitanName", winnerName);
                            command.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }


            }
            catch
            {
            }
           
            }

        //this function will grab the results from the database and show the user.
        //deals with showing the images and name
        //also cleans the battleid session
        protected void showResult() {
            int challengerElement = 0;
            int winner = 0;
            bool winnerBool = false; //stores the result of the battle
            Challenged.ImageUrl = Session["CharacterImageUrl"].ToString();
            ChallengedLabel.Text = Session["SelectedCharacter"].ToString();
            //grabbing details about the challenger
            try
            {
                string sqlQuery = "SELECT TitanName FROM Titan INNER JOIN Battle ON Titan.TitanID = Challenger WHERE BattleID=@BattleID";
                string sqlQueryElement = "SELECT ElementID From Titan WHERE TitanName=@ChallengerName";
                string sqlQueryWinner = "SELECT Winner From Battle WHERE BattleID=@BattleID";
                using (SqlConnection con = new SqlConnection(constr)) {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery,con)) {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        ChallengerLabel.Text = command.ExecuteScalar().ToString();
                    }
                    using (SqlCommand command = new SqlCommand(sqlQueryElement, con)) {
                        command.Parameters.AddWithValue("@ChallengerName", ChallengerLabel.Text);
                        challengerElement = Int32.Parse(command.ExecuteScalar().ToString());
                        switch (challengerElement) {
                            case 1: Challenger.ImageUrl = "Images/earth.jpg";  break;
                            case 2: Challenger.ImageUrl = "Images/air.jpg"; break;
                            case 3: Challenger.ImageUrl = "Images/water.jpg"; break;
                            case 4: Challenger.ImageUrl= "Images/fire.jpg"; break;

                        }
                    }
                    
                    using (SqlCommand command = new SqlCommand(sqlQueryWinner, con)) {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        winner = Int32.Parse(command.ExecuteScalar().ToString());

                        //if the challenged person is winner - winner bool is false else it is true
                        if (winner == Int32.Parse(Session["SelectedTitanID"].ToString()))
                        {
                            winnerBool = false;
                        }
                        else {
                            winnerBool = true;
                        }
                    }
                        con.Close();
                }
            }
            catch {

            }

            //Displays Winner or Loser
            if (winnerBool) {
                ChallengerResultLabel.Text = "WINNER";
                ChallengedResultLabel.Text = "LOSER";

            }
            else {
                
                ChallengedResultLabel.Text = "LOSER";
                ChallengerResultLabel.Text = "WINNER";
            }
            
            

          
        }
    }
}
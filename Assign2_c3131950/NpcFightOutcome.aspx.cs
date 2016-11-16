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
    public partial class NpcFightOutcome : System.Web.UI.Page
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
        protected void updateXP()
        {
            float winnerXP = 0;
            float currentXPUp = 0;
            string winnerName = "";
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
                    if (winnerName == Session["SelectedCharacter"].ToString())
                    {
                        using (SqlCommand command = new SqlCommand(sqlQueryUpdate, con))
                        {
                            command.Parameters.AddWithValue("@TitanName", winnerName);
                            command.ExecuteNonQuery();

                        }
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
        protected void showResult()
        {
            int npcElement = 0;
            int winner = 0;//gets the winner of the battle
            UserImage.ImageUrl = Session["CharacterImageUrl"].ToString();
            UserLabel.Text = Session["SelectedCharacter"].ToString();
            //grabbing details about the npc
            try
            {
                string sqlQuery = "SELECT TitanName FROM Titan INNER JOIN Battle ON Titan.TitanID = Challenged WHERE BattleID=@BattleID";
                string sqlQueryElement = "SELECT ElementID From Titan WHERE TitanName=@NpcName";
                string sqlQueryWinner = "SELECT Winner From Battle WHERE BattleID=@BattleID";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        NpcLabel.Text = command.ExecuteScalar().ToString();
                    }
                    using (SqlCommand command = new SqlCommand(sqlQueryElement, con))
                    {
                        command.Parameters.AddWithValue("@NpcName", NpcLabel.Text);
                        npcElement = Int32.Parse(command.ExecuteScalar().ToString());
                        switch (npcElement)
                        {
                            case 1: NpcImage.ImageUrl = "Images/earthnpc.jpg"; break;
                            case 2: NpcImage.ImageUrl = "Images/airnpc.jpg"; break;
                            case 3: NpcImage.ImageUrl = "Images/waternpc.jpg"; break;
                            case 4: NpcImage.ImageUrl = "Images/firenpc.png"; break;

                        }
                    }

                    using (SqlCommand command = new SqlCommand(sqlQueryWinner, con))
                    {
                        command.Parameters.AddWithValue("@BattleID", Session["BattleID"].ToString());
                        winner = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    con.Close();
                }
            }
            catch
            {

            }

            //Displays Winner or Loser
            if (winner == Int32.Parse(Session["SelectedTitanID"].ToString()))
            {
                UserResultLabel.Text = "WINNER";
                NpcResultLabel.Text = "LOSER";
            }
            else {
                UserResultLabel.Text = "LOSER";
                NpcResultLabel.Text = "WINNER";
            }
            
                

        






        }
    }
}
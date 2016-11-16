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
    
    public partial class IssueChallenge : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                generateChallenges();
            }
        }
        //will create a new battle entry
        protected void challenge_Click(object sender, EventArgs e)
        {
            int result = 0;
            int userCheck = 0;//will be used to check if user is the NPC user
            string message = "";
            try {
                using (SqlConnection con = new SqlConnection(constr)) { 
                    con.Open();
                    using (SqlCommand command = new SqlCommand("Insert_Challenge")) {
                        using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ChallengedID", characterList.SelectedValue.Trim());
                            command.Parameters.AddWithValue("@ChallengerID", Session["SelectedTitanID"].ToString());
                            command.Connection = con;
                            result = Convert.ToInt32(command.ExecuteScalar());
                        }
                            
                    }
                    using (SqlCommand command = new SqlCommand("SELECT UserID From Titan WHERE TitanID=@TitanID", con))
                    {
                        command.Parameters.AddWithValue("@TitanID", characterList.SelectedValue.Trim());
                        userCheck= Convert.ToInt32(command.ExecuteScalar());
                    }
                        con.Close();
                }
            }
            catch {
            }

            //Checks if challenge has already been made to a particular titan
            switch (result) {
                case -1: message = "You have already challanged that titan";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                    break;
                default:
                    if (userCheck == 10)
                    {
                        Session["BattleID"] = result;
                        Response.Redirect("NpcFightPage.aspx");
                    }
                    else {
                        Response.Redirect("BattleHome.aspx");

                    }

                    ; break;
            }
           
        }

        protected void generateChallenges() {
            DataTable characters = new DataTable();
            int currentXpLevel = 0;
            string sqlQueryGetLevel = "SELECT ExperienceID FROM Titan WHERE TitanID=@TitanID";
            string sqlQuery = "SELECT TitanID,TitanName FROM Titan WHERE (UserID!=@UserID) AND (ExperienceID BETWEEN @ExperienceID1 AND @ExperienceID2) AND(ExperienceID<>17)";
            
            try {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    //gets Titans current Level ID
                    using (SqlCommand command = new SqlCommand(sqlQueryGetLevel, con)) {
                        command.Parameters.AddWithValue("@TitanID",Session["SelectedTitanID"].ToString());
                        currentXpLevel = Int32.Parse(command.ExecuteScalar().ToString());
                    }
                    // generates a list of titans to challenge
                    // the titans generate are within the required level and step and 
                    // none of the titans are the on the same account
                    using (SqlCommand command = new SqlCommand(sqlQuery, con)) {
                        command.Parameters.AddWithValue("@UserID", Session["userID"].ToString());
                        command.Parameters.AddWithValue("@ExperienceID1", currentXpLevel-1);
                        command.Parameters.AddWithValue("@ExperienceID2", currentXpLevel+2);
                        command.ExecuteNonQuery();
                        using (SqlDataAdapter adapter = new SqlDataAdapter()) {
                            adapter.SelectCommand = command;
                            adapter.Fill(characters);
                            characterList.DataSource = characters;
                            characterList.DataTextField = "TitanName";
                            characterList.DataValueField = "TitanID";
                            characterList.DataBind();
                        }
                    }
                    con.Close();

                }

                }
            catch
            {


            }
        }

        protected void cancelChallenge(object sender, EventArgs e)
        {
            Response.Redirect("BattleHome.aspx");
        }
    }
}
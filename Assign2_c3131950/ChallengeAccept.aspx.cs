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
    public partial class ChallengeAccept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            loadChallengers();
        }

        protected void decline_Click(object sender, EventArgs e)
        {
            Response.Redirect("BattleHome.aspx");
        }

        protected void fight_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
            string sqlQuery = "UPDATE Battle SET ChallengeAccepted='True' WHERE BattleID=@BattleID";
            //updates the battle table
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    {
                        command.Parameters.AddWithValue("@BattleID", challengerDropDown.SelectedValue);
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch
            {

            }
            Session["BattleID"] = challengerDropDown.SelectedValue;
            Response.Redirect("FightScreen.aspx");
        }

        //This method loads the characters and the battle ID from the database based on what titan is selected
        protected void loadChallengers() {
            DataTable challengers = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
            string sqlQuery = "SELECT TitanName,BattleID FROM Titan INNER JOIN Battle ON Titan.TitanID=Battle.Challenger WHERE Battle.Challenged = @Titan AND ChallengeAccepted='False'";
            try
            {
                using (SqlConnection con = new SqlConnection(constr)) {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery,con)) {
                        command.Parameters.AddWithValue("@Titan",HttpContext.Current.Session["SelectedTitanID"].ToString().Trim());
                        command.ExecuteNonQuery();
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(challengers);
                            challengerDropDown.DataSource = challengers;
                            challengerDropDown.DataTextField = "TitanName";
                            challengerDropDown.DataValueField = "BattleID";
                           
                            challengerDropDown.DataBind();
                        }
                    }
                    con.Close();
                }
            }
            catch {

            }
            
               
            

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assign2_c3131950
{
    public partial class BattleHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["SelectedCharacter"] == null) {
                Response.Redirect("CharacterSelect.aspx");
            }
           

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChallengeAccept.aspx");
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            if (Session["SelectedTitanID"] == null)
            {
                Response.Redirect("CharacterSelect.aspx");
            }
            Response.Redirect("BattleResults.aspx");
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssueChallenge.aspx");
        }

        protected void GridviewChallenger_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
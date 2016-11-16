using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assign2_c3131950
{
    public partial class BattleResults : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            DataTable table = generateTable();
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("BattleHome.aspx");
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;
            gridview1.DataBind();
        }

        protected DataTable generateTable() {
            DataTable table = new DataTable();
            try
            {
               
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand command = new SqlCommand("SELECT BattleID,Winner,Challenged,Challenger FROM Battle WHERE (Challenged=@UserTitanID)OR(Challenger=@UserTitanID)", con))
                    {
                        con.Open();
                        command.Parameters.AddWithValue("@UserTitanID", Session["SelectedTitanID"].ToString());
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(table);
                            gridview1.DataSource = table;
                            gridview1.DataBind();
                        }


                    }
                    foreach (DataRow row in gridview1.Rows)
                    {

                    }
                    con.Close();
                  
                }
            }
            catch { }
            return table;



        }
       
    }
}
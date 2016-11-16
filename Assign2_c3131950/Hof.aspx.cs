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
    public partial class Hof : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = generateTable();
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;
            gridview1.DataBind();
        }

        protected DataTable generateTable()
        {
            DataTable table = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("SELECT TitanName FROM Titan WHERE ExperienceID=17", con))
                    {
                        
                        
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
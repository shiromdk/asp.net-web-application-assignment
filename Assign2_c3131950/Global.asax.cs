using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Assign2_c3131950
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            /*Adds the resources definition. Stops the UnobtrusiveValidionMode error*/
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition {
                    Path = "https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js",
                    DebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"     
                } );
        }
    }
}
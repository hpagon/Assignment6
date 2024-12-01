using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp.TryIts
{
    public partial class VisitorLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Path to the log file in the App_Data folder
            string logFilePath = Server.MapPath("~/App_Data/VisitorLog.txt");

            if (File.Exists(logFilePath))
            {
                // Read the log file and display its contents
                string logContents = File.ReadAllText(logFilePath);
                // Render the log contents inside a <pre> tag for proper formatting
                ltLogs.Text = $"<pre>{logContents}</pre>";
            }
            else
            {
                // Message displayed if no log file exists
                ltLogs.Text = "No logs available.";
            }
        }
    }
}
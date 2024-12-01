using System;
using System.IO;
using System.Web;
using System.Web.Security;

namespace Assignment6.ShopWebApp
{
    public class Global : HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;

                // Assign roles from the UserData field in the ticket
                string[] roles = ticket.UserData.Split(',');

                // Set the current user with roles
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, roles);
            }
        }

        // This method is triggered when the application starts
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                // Path to the log file stored in the App_Data directory
                string logPath = Server.MapPath("~/App_Data/VisitorLog.txt");

                // Entry to log the application startup time
                string logEntry = $"Application started at {DateTime.Now}\n";

                // Append the log entry to the VisitorLog.txt file
                File.AppendAllText(logPath, logEntry);
            }
            catch (Exception ex)
            {
                // Handle potential exceptions (e.g., file access issues)
                // Optional: Log the exception details to another file or monitoring system
            }
        }

        // This method is triggered at the beginning of every HTTP request
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                // Path to the log file stored in the App_Data directory
                string logPath = Server.MapPath("~/App_Data/VisitorLog.txt");

                // Entry to log the page being accessed and the timestamp
                string logEntry = $"Page accessed: {Request.Url.AbsolutePath} at {DateTime.Now}\n";

                // Append the log entry to the VisitorLog.txt file
                File.AppendAllText(logPath, logEntry);
            }
            catch (Exception ex)
            {
                // Handle potential exceptions (e.g., file access issues)
                // Optional: Log the exception details to another file or monitoring system
            }
        }
    }
}

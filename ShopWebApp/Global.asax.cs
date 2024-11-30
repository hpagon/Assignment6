using System;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment6.ShopWebApp.Protected.Member_Folder
{
    public partial class MemberPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure the user is authenticated before accessing the member page
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Member"))
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Clear the authentication cookie
            FormsAuthentication.SignOut();

            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page
            Response.Redirect("~/Login.aspx");
        }
    }
}
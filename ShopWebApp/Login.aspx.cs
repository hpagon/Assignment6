using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using myAuthenticate; // Namespace for the MyAuthenticate DLL

namespace Assignment6.ShopWebApp
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void MemberLoginFunc(object sender, EventArgs e)
        {
            string user = MemberNameField.Text.Trim();
            string password = MemberPwdField.Text.Trim();
            string filePath = Server.MapPath("~/App_Data/Member.xml");

            // Use MyAuthenticate DLL for member authentication. The hashing is dealt within the DLL by using the PasswordLibrary
            MyAuthenticate myAuth = new MyAuthenticate();

            if (myAuth.myAuthenticate(user, password, filePath))
            {
                // Create authentication ticket for member. I followed along with the lecture videos.
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, user, DateTime.Now, DateTime.Now.AddMinutes(30),
                    MemberPersistent.Checked, "Member", FormsAuthentication.FormsCookiePath
                );

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                // Redirect to member page
                Response.Redirect("~/Protected/Member_Folder/MemberPage.aspx");
            }
            else
            {
                MemberErrOutput.Text = "Invalid Member Credentials.";
            }
        }

        // This works basically the same as the above function.
        protected void StaffLoginFunc(object sender, EventArgs e)
        {
            string user = StaffNameField.Text.Trim();
            string password = StaffPwdField.Text.Trim();
            string filePath = Server.MapPath("~/App_Data/Staff.xml");

            // Use MyAuthenticate DLL for staff authentication
            MyAuthenticate myAuth = new MyAuthenticate();

            if (myAuth.myAuthenticate(user, password, filePath))
            {
                // Create authentication ticket for staff
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, user, DateTime.Now, DateTime.Now.AddMinutes(30),
                    StaffPersistent.Checked, "Staff", FormsAuthentication.FormsCookiePath
                );

                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                // Redirect to staff page
                Response.Redirect("~/Protected/Staff_Folder/StaffPage.aspx");
            }
            else
            {
                StaffErrOutput.Text = "Invalid Staff Credentials.";
            }
        }
    }
}

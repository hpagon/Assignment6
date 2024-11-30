using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Assignment6.ShopWebApp
{
    public partial class MemberRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                //CreateBtn.Enabled = false; // Disable the button initially
            //}

            // Commented out CAPTCHA logic for now
            //CreateBtn.Enabled = captcha.isSuccess(); // Enable if CAPTCHA passes
            //CreateBtn.Enabled = true; // Temporarily enable the button for testing. Please delete after the line above is implemented.
        }

        public void validateFormEntry(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameField.Text))
            {
                UsernameErr.Text = "*Username is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordField.Text))
            {
                // Commented out CAPTCHA error for now
                CaptchaErr.Text = "*Password is required.";
                UsernameErr.Text = "*Password is required."; // Adjusted for clarity during testing
                return;
            }

            string filepath = Server.MapPath("~/App_Data/Member.xml");
            string user = UserNameField.Text.Trim();
            string rawPassword = PasswordField.Text.Trim();
            string password = PasswordLibrary.PasswordHasher.HashPassword(rawPassword);

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);

            XmlElement rootElement = myDoc.DocumentElement;

            foreach (XmlNode node in rootElement.ChildNodes)
            {
                if (node["Username"]?.InnerText == user)
                {
                    UsernameErr.Text = $"*Account with username {user} already exists.";
                    return;
                }
            }

            // Commented out CAPTCHA logic for now
            
            if (!captcha.isSuccess())
            {
                CaptchaErr.Text = "*Captcha failed. Please try again.";
                return;
            }

            addNewMember(filepath, user, password);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,                           // Ticket version
                user,                        // Username
                DateTime.Now,                // Issue date
                DateTime.Now.AddMinutes(30), // Expiration date
                false,                       // Persistent
                "Member",                    // User role stored in UserData
                FormsAuthentication.FormsCookiePath // Cookie path
            );

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);

            Response.Redirect("~/Protected/Member_Folder/MemberPage.aspx"); // Redirect to the member page
        }

        public void addNewMember(string filepath, string user, string password)
        {
            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath);

            XmlElement rootElement = myDoc.DocumentElement;
            XmlElement newUser = myDoc.CreateElement("User", rootElement.NamespaceURI);
            rootElement.AppendChild(newUser);

            XmlElement usernameElement = myDoc.CreateElement("Username", rootElement.NamespaceURI);
            newUser.AppendChild(usernameElement);
            usernameElement.InnerText = user;

            XmlElement passwordElement = myDoc.CreateElement("Password", rootElement.NamespaceURI);
            newUser.AppendChild(passwordElement);
            passwordElement.InnerText = password;

            myDoc.Save(filepath);
        }
    }
}
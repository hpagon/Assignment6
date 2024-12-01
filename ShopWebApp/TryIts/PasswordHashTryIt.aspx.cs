using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp.TryIts
{
    public partial class PasswordHashTryIt : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Click event for the "Hash Password" button.
        /// Validates the input and hashes the password using the PasswordLibrary DLL.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        protected void btnHashPassword_Click(object sender, EventArgs e)
        {
            // Retrieve the password input from the TextBox
            string password = txtPassword.Text;

            // Check if the input is empty
            if (string.IsNullOrEmpty(password))
            {
                // Display a message if the input is invalid
                lblHashedPassword.Text = "Please enter a password.";
            }
            else
            {
                // Hash the password using the PasswordLibrary DLL
                string hashedPassword = PasswordLibrary.PasswordHasher.HashPassword(password);

                // Display the hashed password
                lblHashedPassword.Text = $"Hashed Password: {hashedPassword}";
            }
        }
    }
}
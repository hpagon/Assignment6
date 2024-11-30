using System;
using System.IO;
using System.Web.UI;
using myAuthenticate;

namespace ShopWebApp.TryIts
{
    public partial class AuthTryIt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ToDefaultBtn_Click(object sender, EventArgs e)
        {
            // Redirect to the default page
            Response.Redirect("~/Default.aspx");
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            // Clear previous output
            Output.Text = "";

            // Fetch user inputs and trims it to remove whitespace
            string username = UserField.Text.Trim();
            string password = PasswordField.Text.Trim();
            string filePath = Server.MapPath(FileField.Text.Trim());

            // Validate inputs
            if (string.IsNullOrWhiteSpace(username))
            {
                Output.Text = "Please enter username.";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                Output.Text = "Please enter password.";
                return;
            }

            if (string.IsNullOrWhiteSpace(FileField.Text.Trim()))
            {
                Output.Text = "Please enter file path.";
                return;
            }

            try
            {
                // Instantiate my DLL
                MyAuthenticate myAuth = new MyAuthenticate();

                // Perform authentication. My DLL function uses the PasswordLibrary to deal with the hashing. The xml stores the hashed password instead of the clear text.
                bool isAuthenticated = myAuth.myAuthenticate(username, password, filePath);

                // Display result
                if (isAuthenticated)
                {
                    Output.Text = "Success: User authenticated!";
                }
                else
                {
                    Output.Text = "Invalid Username or Password.";
                }
            }
            catch (FileNotFoundException ex)
            {
                // Handle file not found
                Output.Text = $"Error: {ex.Message}";
            }
            catch (ApplicationException ex)
            {
                // Handle application errors (e.g., XML format issues)
                Output.Text = $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                // Handle general errors
                Output.Text = $"Unexpected error: {ex.Message}";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp.TryIts
{
    public partial class CaptchaTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //validate user login and display output
            if (username.Text == "member" & password.Text == "member123" && captcha.isSuccess())
            {
                Result.Text = "Login Successful";
            }
            else
            {
                Result.Text = "Login Failed";
            }
        }
    }
}
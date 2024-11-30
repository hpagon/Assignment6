using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp
{
    public partial class Captcha : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fetch fresh captcha if new session
            if (!IsPostBack)
            {
                fetchCaptcha();
            }
        }
        //check if captcha was completed successfully and updates status
        protected void submit_Click(object sender, EventArgs e)
        {
            if ((string)Session["currString"] == captchaStringInput.Text)
            {
                Session["success"] = true;
                result.Text = "Success ✔";
                promptContainer.Visible = false;

            }
            else
            {
                Session["success"] = false;
                result.Text = "Failed. Please try again.";
                fetchCaptcha();
            }
        }
        //allows access to success variable outside of captcha
        public bool isSuccess()
        {
            return (bool)Session["success"];
        }

        // fetches new random string and corresponding image for captcha
        private void fetchCaptcha()
        {
            ImageVerifier.ServiceClient prxy = new ImageVerifier.ServiceClient("BasicHttpsBinding_IService");
            //create random string
            Session["currString"] = prxy.GetVerifierString("5");
            //fetch image given string and set to image element
            captchaImage.ImageUrl = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + Session["currString"];
            //give default value to success
            Session["success"] = false;
            //make prompt visible
            promptContainer.Visible = true;
        }
    }
}
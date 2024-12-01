using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp.TryIts
{
    public partial class CookieTryIt : System.Web.UI.Page
    {
        protected void SaveCookie_Click(object sender, EventArgs e)
        {
            try
            {
                // Save a cookie with multiple attributes
                HttpCookie productCookie = new HttpCookie("TryItCookie");
                productCookie["ProductName"] = "SampleProduct123";
                productCookie["Category"] = "Electronics";
                productCookie["Timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                productCookie.Expires = DateTime.Now.AddMinutes(10); // Set expiration time
                Response.Cookies.Add(productCookie);

                // Display success message
                lblCookieOutput.Text = $"Cookie saved successfully with ProductName=SampleProduct123, Category=Electronics at {productCookie["Timestamp"]}.";
            }
            catch (Exception ex)
            {
                lblCookieOutput.Text = $"Error saving cookie: {ex.Message}";
            }
        }

        protected void ShowCookie_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the saved cookie
                HttpCookie productCookie = Request.Cookies["TryItCookie"];
                if (productCookie != null)
                {
                    // Display cookie attributes
                    string productName = productCookie["ProductName"];
                    string category = productCookie["Category"];
                    string timestamp = productCookie["Timestamp"];
                    lblCookieOutput.Text = $"Cookie Details: ProductName={productName}, Category={category}, Timestamp={timestamp}.";
                }
                else
                {
                    lblCookieOutput.Text = "No cookie found for TryItCookie.";
                }
            }
            catch (Exception ex)
            {
                lblCookieOutput.Text = $"Error retrieving cookie: {ex.Message}";
            }
        }

        protected void ClearCookie_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the cookie by setting its expiration date to the past
                HttpCookie productCookie = new HttpCookie("TryItCookie");
                productCookie.Expires = DateTime.Now.AddDays(-1); // Expire immediately
                Response.Cookies.Add(productCookie);

                lblCookieOutput.Text = "Cookie cleared successfully.";
            }
            catch (Exception ex)
            {
                lblCookieOutput.Text = $"Error clearing cookie: {ex.Message}";
            }
        }
    }
}
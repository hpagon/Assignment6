using System;
using System.Web.UI;

namespace ShopWebApp.TryIts
{
    public partial class TryItSortUserControl : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: Add any initialization logic for the page here
        }

        protected void ToDefaultBtn_Click(object sender, EventArgs e)
        {
            // Redirect back to the default page
            Response.Redirect("~/Default.aspx");
        }
    }
}

using ShopWebApp;
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
            // Display user's name in custom greeting
            memberNameLabel.Text = User.Identity.Name;
            // Initialize product inventory if not already initialized
            if (Session["Inventory"] == null)
            {
                string[] names = {  "Smartphone", "Laptop", "Bluetooth Speaker", "Smartwatch","Tablet","Wireless Headphones","Mystery Novel","Science Fiction Anthology","Self-Help Guide","Biography","Cookbook","Children's Storybook","T-Shirt","Sneakers","Jacket","Wristwatch","Handbag","Scarf","Vacuum Cleaner","Air Purifier","Coffee Maker","Blender","Mattress","Desk Lamp","Lego Set","Action Figure","Board Game","Puzzle","Dollhouse","Toy Car","Yoga Mat","Dumbbells","Tennis Racket","Soccer Ball","Basketball Shoes","Fitness Tracker",};
                string[] priceRanges = { "high", "high", "low", "high", "high", "low", "low", "low", "low", "high", "high", "low", "low", "low", "high", "high", "high", "low", "high", "high", "low", "low", "high", "low", "high", "low", "low", "low", "high", "low", "low", "high", "high", "low", "high", "high",};
                string[] productCategories = { "electronics", "books", "fashion", "home", "toys", "sports" };
                decimal[] prices = { 800, 1000, 100, 500, 400, 75, 12, 15, 15, 50, 75, 10, 10, 50, 125, 700, 600, 10, 400, 300, 80, 70, 800, 15, 300, 10, 15, 10, 200, 5, 20, 150, 175, 20, 175, 200 };
                Random random = new Random();

                for(int i = 0; i < names.Length; i++)
                {
                    Session[names[i]] = new Product { Name = names[i], Price = prices[i], Rating = random.NextDouble() * 3 + 2, InCart=false, PriceRange = priceRanges[i], ProductCategory = productCategories[i/6], Stock = random.Next(5, 101)};
                }

                Session["Inventory"] = names;
            }
            // Visually populate product catalog
            string[] inventory = (string[])Session["Inventory"];
            foreach (string productName in inventory)
            {
                itemCatalog.Items.Add(new ListItem($"{((Product)Session[productName]).Print()}"));
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
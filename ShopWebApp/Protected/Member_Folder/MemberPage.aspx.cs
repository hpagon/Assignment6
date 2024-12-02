using ShopWebApp;
using ShopWebApp.CheckoutService;
using ShopWebApp.TryIts;
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
        protected string[] names = { "Smartphone", "Laptop", "Bluetooth Speaker", "Smartwatch", "Tablet", "Wireless Headphones", "Mystery Novel", "Science Fiction Anthology", "Self-Help Guide", "Biography", "Cookbook", "Children's Storybook", "T-Shirt", "Sneakers", "Jacket", "Wristwatch", "Handbag", "Scarf", "Vacuum Cleaner", "Air Purifier", "Coffee Maker", "Blender", "Mattress", "Desk Lamp", "Lego Set", "Action Figure", "Board Game", "Puzzle", "Dollhouse", "Toy Car", "Yoga Mat", "Dumbbells", "Tennis Racket", "Soccer Ball", "Basketball Shoes", "Fitness Tracker", };
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
                string[] priceRanges = { "high", "high", "low", "high", "high", "low", "low", "low", "low", "high", "high", "low", "low", "low", "high", "high", "high", "low", "high", "high", "low", "low", "high", "low", "high", "low", "low", "low", "high", "low", "low", "high", "high", "low", "high", "high", };
                string[] productCategories = { "electronics", "books", "fashion", "home", "toys", "sports" };
                decimal[] prices = { 800, 1000, 100, 500, 400, 75, 12, 15, 15, 50, 75, 10, 10, 50, 125, 700, 600, 10, 400, 300, 80, 70, 800, 15, 300, 10, 15, 10, 200, 5, 20, 150, 175, 20, 175, 200 };
                Random random = new Random();
                //Create individual inventory items
                for (int i = 0; i < names.Length; i++)
                {
                    Session[names[i]] = new Product { Name = names[i], Price = prices[i], Rating = random.NextDouble() * 3 + 2, InCart = false, PriceRange = priceRanges[i], ProductCategory = productCategories[i / 6], Stock = random.Next(5, 101), Recommended = false};
                }
                // Create official inventory list
                List<Product> products = new List<Product>();
                foreach (string productName in names)
                {
                    products.Add((Product)Session[productName]);
                }
                Session["Inventory"] = products;
                // Used to track when to display recommendations
                Session["ShowRecs"] = false;
            }
            // Visually populate product catalog
            List<Product> inventory = (List<Product>)Session["Inventory"];
            foreach (Product product in inventory)
            {
                if(product.InCart) shoppingCart.Items.Add(new ListItem(product.Name, product.Name));
                //only display recs if ShowRecs is true
                if ((bool)Session["ShowRecs"])
                {
                    if(product.Recommended == true) itemCatalog.Items.Add(new ListItem($"{product.PrintMember()}", product.Name));
                    continue;
                }
                itemCatalog.Items.Add(new ListItem($"{product.PrintMember()}", product.Name));
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

        protected void addToCart_Click(object sender, EventArgs e)
        {
            //check if item selected 
            if (itemCatalog.SelectedIndex < 0)
            {
                catalogLabel.Text = "Please select an item.";
            }
            else
            {
                catalogLabel.Text = $"Looking for book at index {itemCatalog.SelectedIndex}, {itemCatalog.SelectedValue}";
                //get selected item
                string key = itemCatalog.SelectedValue;
                Product selectedItem = (Product)Session[key];
                // add to cart and update
                selectedItem.InCart = true;
                Session[key] = selectedItem;
                //update inventory
                updateInventory();
                //force refresh to trigger page reload functino
                Response.Redirect("./MemberPage.aspx");
            }
        }
        //updates inventory session state product list to match updates made in individual products
        protected void updateInventory()
        {
            List<Product> products = (List<Product>)Session["Inventory"];
            for (int i = 0; i < products.Count; i++)
            {
                {
                    products[i] = (Product)Session[products[i].Name];
                }
            }
        }

        protected void remove_Click(object sender, EventArgs e)
        {
            //check if item is actually selected
            if (shoppingCart.SelectedIndex < 0)
            {
                shoppingCartLabel.Text = "Please select an item to remove.";
            }
            else
            {
                catalogLabel.Text = " ";
                //get selected item
                string key = shoppingCart.SelectedValue;
                Product selectedItem = (Product)Session[key];
                //remove from cart and update
                selectedItem.InCart = false;
                Session[key] = selectedItem;
                // Update Inventory
                updateInventory();
                //force refresh to trigger page load display again
                Response.Redirect("./MemberPage.aspx");
            }
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            List<Dictionary<String, String>> shoppingCartItems = new List<Dictionary<String, String>>();
            //serialize items in shopping cart
            foreach (ListItem item in shoppingCart.Items)
            {
                Dictionary<String, String> currItem = new Dictionary<String, String>();
                Product temp = (Product)Session[item.Value];
                currItem.Add("productCategory", temp.ProductCategory);
                currItem.Add("priceRange", temp.PriceRange);
                currItem.Add("name", temp.Name);
                currItem.Add("price", temp.Price.ToString());
                currItem.Add("id", temp.Name);
                currItem.Add("inCart", temp.InCart.ToString());
                currItem.Add("stock", temp.Stock.ToString());
                shoppingCartItems.Add(currItem);
                shoppingCartLabel.Text += temp.Name + " ";
            }
            //call service to process order and update stock 
            Dictionary<String, String>[] newShoppingCartItems = shoppingCartItems.ToArray();
            //CheckoutService.Service1Client prxy = new CheckoutService.Service1Client();
            //Dictionary<String, String> updatedStock = prxy.checkout(newShoppingCartItems);
            Dictionary<String, String> updatedStock = ServiceWrapper.UseCheckoutService(newShoppingCartItems);
            //after service is done checking out visually delete items from shopping cart
            foreach (ListItem item in shoppingCart.Items)
            {
                Dictionary<String, String> currItem = new Dictionary<String, String>();
                Product temp = (Product)Session[item.Value];
                temp.InCart = false;
                Session[item.Value] = temp;
            }
            //update stock on local page to match the stock returned from service
            foreach (KeyValuePair<String, String> item in updatedStock)
            {
                Product currItem = (Product)Session[item.Key];
                shoppingCartLabel.Text += $"{currItem.Name}: {item.Value}";
                currItem.Stock = Int32.Parse(item.Value);
                Session[item.Key] = currItem;
                updateInventory();
            }
            //refresh to see updates
            Response.Redirect("./MemberPage.aspx");
        }
        // Marks which list items need to be displayed upon refresh
        protected void recommendationsButton_Click(object sender, EventArgs e)
        {
            // Call recommendation service and store results
            string[] recommendations = ServiceWrapper.useProductRecommendation(categories.SelectedItem.Value, priceRanges.SelectedItem.Value, "");
            HashSet<string> recommendationsSet = new HashSet<string>(recommendations);
            foreach(string productName in names)
            {
                // Set Recommended to true for recommended items
                Product temp = (Product)Session[productName];
                if(recommendationsSet.Contains(productName))
                {
                    temp.Recommended = true;
                } else
                {
                    temp.Recommended = false;
                }
                Session[productName] = temp;
            }
            // Force refresh to see changes
            updateInventory();
            Session["ShowRecs"] = true;
            Response.Redirect("./MemberPage.aspx");
        }
        // Hide Recommendations
        protected void hideRecommendations_Click(object sender, EventArgs e)
        {
            Session["ShowRecs"] = false;
            Response.Redirect("./MemberPage.aspx");
        }
    }
}
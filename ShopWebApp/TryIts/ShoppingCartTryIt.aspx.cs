using Assignment6.ShopWebApp.Protected.Member_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp.TryIts
{
    public partial class ShoppingCartTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if session state empty or first time visiting, populate the store
            if (Session.Count == 0)
            {
                string[] names = { "Data Structures and Algorithms", "Advanced Java Programming", "Artificial Intelligence and Deep Learning", "Python Programming Basics", "Database Management Systems" };
                double[] prices = { 59.99, 45.99, 79.99, 29.99, 39.99 };
                int[] stock = { 5, 10, 13, 1, 7 };
                for (int i = 0; i < 5; i++)
                {
                    string priceRange = i % 3 == 0 ? "Low" : i % 3 == 1 ? "Medium" : "High";
                    string id = "book" + Session.Count;
                    Item newItem = new Item("Book", priceRange, names[i], prices[i], id, false, stock[i]);
                    Session[id] = newItem;
                }
            }
            //if session state not empty and page not populated, then populate page
            if (Session.Count != 0 && itemCatalog.Items.Count == 0)
            {
                foreach (string key in Session.Keys)
                {
                    //add item to catalog
                    Item newItem = (Item)Session[key];
                    itemCatalog.Items.Add(new ListItem($"Name: {newItem.name}, Stock: {newItem.stock}", key));
                    //add corresponding items to shopping cart
                    if (newItem.inCart)
                    {
                        shoppingCart.Items.Add(new ListItem(newItem.name, key));
                    }
                }
            }
        }
        //adds selected items to users shopping cart
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
                Item selectedItem = (Item)Session[key];
                // add to cart and update
                selectedItem.inCart = true;
                Session[key] = selectedItem;
                //force refresh to trigger page reload functino
                Response.Redirect("ShoppingCartTryIt.aspx");
            }
        }
        //removes selected items from users shopping cart
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
                Item selectedItem = (Item)Session[key];
                //remove from cart and update
                selectedItem.inCart = false;
                Session[key] = selectedItem;
                //force refresh to trigger page load display again
                Response.Redirect("ShoppingCartTryIt.aspx");
            }
        }
        //triggers the checkout service to process orders and update stock levels
        protected void checkout_Click(object sender, EventArgs e)
        {
            List<Dictionary<String, String>> shoppingCartItems = new List<Dictionary<String, String>>();
            //serialize items in shopping cart
            foreach (ListItem item in shoppingCart.Items)
            {
                Dictionary<String, String> currItem = new Dictionary<String, String>();
                Item temp = (Item)Session[item.Value];
                currItem.Add("productCategory", temp.productCategory);
                currItem.Add("priceRange", temp.priceRange);
                currItem.Add("name", temp.name);
                currItem.Add("price", temp.price.ToString());
                currItem.Add("id", temp.id);
                currItem.Add("inCart", temp.inCart.ToString());
                currItem.Add("stock", temp.stock.ToString());
                shoppingCartItems.Add(currItem);
            }
            //call service to process order and update stock 
            Dictionary<String, String>[] newShoppingCartItems = shoppingCartItems.ToArray();
            CheckoutService.Service1Client prxy = new CheckoutService.Service1Client();
            Dictionary<String, String> updatedStock = prxy.checkout(newShoppingCartItems);
            //after service is done checking out visually delete items from shopping cart
            foreach (ListItem item in shoppingCart.Items)
            {
                Dictionary<String, String> currItem = new Dictionary<String, String>();
                Item temp = (Item)Session[item.Value];
                temp.inCart = false;
                Session[item.Value] = temp;
            }
            //update stock on local page to match the stock returned from service
            foreach (KeyValuePair<String, String> item in updatedStock)
            {
                Item currItem = (Item)Session[item.Key];
                shoppingCartLabel.Text += $"{currItem.name}: {item.Value}";
                currItem.stock = Int32.Parse(item.Value);
                Session[item.Key] = currItem;
            }
            //refresh to see updates
            Response.Redirect("ShoppingCartTryIt.aspx");
        }
    }
    //item class for items in online store
    public class Item
    {
        public string productCategory;
        public string priceRange;
        public string name;
        public double price;
        public string id;
        public bool inCart;
        public int stock;
        //constructor
        public Item(string productCategory, string priceRange, string name, double price, string id, bool inCart, int stock)
        {
            this.productCategory = productCategory;
            this.priceRange = priceRange;
            this.name = name;
            this.price = price;
            this.id = id;
            this.inCart = inCart;
            this.stock = stock;
        }
    }
}
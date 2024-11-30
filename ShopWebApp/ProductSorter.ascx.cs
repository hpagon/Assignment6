using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopWebApp.Controls
{
    public partial class ProductSorter : System.Web.UI.UserControl
    {
        // Hardcoded list of products
        private List<Product> products = new List<Product>
        {
            // A Product object stores the name, price, and rating
            new Product { Name = "Gaming Mouse", Price = 60, Rating = 4.3 },
            new Product { Name = "Webcam", Price = 90, Rating = 4.2 },
            new Product { Name = "Wireless Headphones", Price = 120, Rating = 4.6 },
            new Product { Name = "Mechanical Keyboard", Price = 150, Rating = 4.5 },
            new Product { Name = "4K Monitor", Price = 300, Rating = 4.8 }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SortBtn_Click(object sender, EventArgs e)
        {
            List<Product> ordered; // Sorted list of products
            string option = DropDownList1.SelectedItem.Value;

            switch (option)
            {
                case "1": // Sort by price low-to-high
                    ordered = products.OrderBy(p => p.Price).ToList();
                    UpdateList(ordered);
                    break;

                case "2": // Sort by price high-to-low
                    ordered = products.OrderByDescending(p => p.Price).ToList();
                    UpdateList(ordered);
                    break;

                case "3": // Sort by ratings (best-to-worst)
                    ordered = products.OrderByDescending(p => p.Rating).ToList();
                    UpdateList(ordered);
                    break;

                default:
                    break;
            }
        }

        private void UpdateList(List<Product> ordered)
        {
            // Update each product label with a description of the product (name, price, and rating)
            Prod1.Text = ordered[0].Print();
            Prod2.Text = ordered[1].Print();
            Prod3.Text = ordered[2].Print();
            Prod4.Text = ordered[3].Print();
            Prod5.Text = ordered[4].Print();
        }
    }

    // Product class definition
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        // Returns a string representation of the product's details
        public string Print()
        {
            return $"{Name}: ${Price}, Rating: {Rating}";
        }
    }
}

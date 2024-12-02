using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApp
{
    public class Product
    {
        //  a product has a name, price, and rating
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public string PriceRange { get; set; }
        public int Stock { get; set; }
        public string ProductCategory { get; set; }
        public bool InCart { get; set; }
        public bool Recommended {  get; set; }

        public string Print() // the prod sorter uc will need the properties displayed as a string
        {
            return $"{Name} Price: ${Price} Rating: {Rating}";
        }

        public string PrintMember() // the prod sorter uc will need the properties displayed as a string
        {
            return $"{Name}, Price: ${Price}, Rating: {Rating:F1}, Stock: {Stock}";
        }
    }
}
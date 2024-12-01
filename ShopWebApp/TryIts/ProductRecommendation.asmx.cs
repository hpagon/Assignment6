using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ShopWebApp.TryIts
{
    [WebService(Namespace = "http://onlinestore.example.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ProductRecommendation : System.Web.Services.WebService
    {
        /// <summary>
        /// Provides product recommendations based on the given product category, price range, and user ID.
        /// </summary>
        /// <param name="productCategory">The category of the product (e.g., electronics, books, fashion, home, toys, groceries, sports, pets, health).</param>
        /// <param name="priceRange">The price range of products: "low" or "high".</param>
        /// <param name="userID">The user ID to personalize recommendations (optional, currently unused).</param>
        /// <returns>A list of recommended products based on the provided inputs.</returns>
        [WebMethod(Description = "Get personalized product recommendations based on category, price range, and user ID. <br /> Example: productCategory = 'electronics', priceRange = 'low/high', userID = 'user123'")]
        public List<string> GetRecommendations(string productCategory, string priceRange, string userID)
        {
            // Mock recommendation data with price ranges
            Dictionary<string, List<Tuple<string, string>>> categoryRecommendations = new Dictionary<string, List<Tuple<string, string>>>()
            {
                { "electronics", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Smartphone", "high"),
                        Tuple.Create("Laptop", "high"),
                        Tuple.Create("Bluetooth Speaker", "low"),
                        Tuple.Create("Smartwatch", "high"),
                        Tuple.Create("Tablet", "high"),
                        Tuple.Create("Wireless Headphones", "low")
                    }
                },
                { "books", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Mystery Novel", "low"),
                        Tuple.Create("Science Fiction Anthology", "low"),
                        Tuple.Create("Self-Help Guide", "low"),
                        Tuple.Create("Biography", "high"),
                        Tuple.Create("Cookbook", "high"),
                        Tuple.Create("Children's Storybook", "low")
                    }
                },
                { "fashion", new List<Tuple<string, string>>
                    {
                        Tuple.Create("T-Shirt", "low"),
                        Tuple.Create("Sneakers", "low"),
                        Tuple.Create("Jacket", "high"),
                        Tuple.Create("Wristwatch", "high"),
                        Tuple.Create("Handbag", "high"),
                        Tuple.Create("Scarf", "low")
                    }
                },
                { "home", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Vacuum Cleaner", "high"),
                        Tuple.Create("Air Purifier", "high"),
                        Tuple.Create("Coffee Maker", "low"),
                        Tuple.Create("Blender", "low"),
                        Tuple.Create("Mattress", "high"),
                        Tuple.Create("Desk Lamp", "low")
                    }
                },
                { "toys", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Lego Set", "high"),
                        Tuple.Create("Action Figure", "low"),
                        Tuple.Create("Board Game", "low"),
                        Tuple.Create("Puzzle", "low"),
                        Tuple.Create("Dollhouse", "high"),
                        Tuple.Create("Toy Car", "low")
                    }
                },
                { "sports", new List<Tuple<string, string>>
                    {
                        Tuple.Create("Yoga Mat", "low"),
                        Tuple.Create("Dumbbells", "high"),
                        Tuple.Create("Tennis Racket", "high"),
                        Tuple.Create("Soccer Ball", "low"),
                        Tuple.Create("Basketball Shoes", "high"),
                        Tuple.Create("Fitness Tracker", "high")
                    }
                }
            };

            // Initialize recommendations list
            List<string> recommendations = new List<string>();

            // Check if the category exists in the dictionary
            if (categoryRecommendations.ContainsKey(productCategory.ToLower()))
            {
                var products = categoryRecommendations[productCategory.ToLower()];

                // Filter products by price range
                recommendations = products
                    .Where(p => p.Item2.Equals(priceRange, StringComparison.OrdinalIgnoreCase))
                    .Select(p => p.Item1)
                    .ToList();
            }
            else
            {
                recommendations.Add("No recommendations available for this category.");
            }

            // Handle empty recommendations
            if (recommendations.Count == 0)
            {
                recommendations.Add("No recommendations available for this category and price range.");
            }
            else
            {
                // Add additional items for diversity
                recommendations.Add("Trending Item");
                recommendations.Add("Limited Edition Item");
            }

            return recommendations;
        }
    }
}

// This class acts as a service wrapper so files in protected folders can access services
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebApp
{
    public class ServiceWrapper
    {
        public ServiceWrapper() { }
        // Access the checkout service
        public static Dictionary<String, String> UseCheckoutService(Dictionary<String, String>[] shoppingCartItems)
        {
            CheckoutService.Service1Client prxy = new CheckoutService.Service1Client();
            Dictionary<String, String> updatedStock = prxy.checkout(shoppingCartItems);
            return updatedStock;
        }
    }
}
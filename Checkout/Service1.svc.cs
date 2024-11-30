using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Checkout
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Dictionary<String, String> checkout(List<Dictionary<String, String>> shoppingCartItems)
        {
            //Mock inventory data
            Dictionary<String, int> inventory = new Dictionary<String, int>();
            inventory.Add("book0", 5);
            inventory.Add("book1", 10);
            inventory.Add("book2", 13);
            inventory.Add("book3", 1);
            inventory.Add("book4", 7);
            //stock replica to display to user
            Dictionary<String, String> updatedStock = new Dictionary<String, String>();
            //go through shopping cart and remove those items from inventory
            foreach (Dictionary<String, String> item in shoppingCartItems)
            {
                if (Int32.Parse(item["stock"]) == 0)
                {
                    updatedStock.Add(item["id"], 0.ToString());  //Dont change stock if already at 0
                    continue;
                }
                int newStock = Int32.Parse(item["stock"]) - 1;  //Decrease stock by 1
                inventory[item["id"]] = newStock;
                updatedStock.Add(item["id"], newStock.ToString());
            }
            return updatedStock;
        }
    }
}

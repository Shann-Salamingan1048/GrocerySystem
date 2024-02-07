using System.Collections.Generic;
namespace GrocerySystem
{
    public class Products
    {
        private Dictionary<string, double> ProductsInventory = new Dictionary<string, double>()
        {
            {"Safe Guard" , 79.24 },
            {"Palmolive", 69.43 },
            {"Casino Rubbing Alcohol", 100.42}
        };
        public Dictionary<string, double> getProducts()
        {
            return this.ProductsInventory;
        }
    }
}

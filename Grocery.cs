using System;
using System.Collections.Generic;
using System.Linq;

namespace GrocerySystem
{
    class Grocery
    {
        private Dictionary<KeyValuePair<string, double>, int> CartInventory = new Dictionary<KeyValuePair<string, double>, int>();
        public Grocery() { }
        public void Run()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("1. Cart Inventory\n2. Browse Product\n3. Exit");
                int chosen = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (chosen)
                {
                    case 1:
                        Cart();
                        break;
                    case 2:
                        BrowseProduct();
                        break;
                    case 3:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Option!");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void Cart()
        {
            if (CartInventory.Count > 0)
            {
                double Sum = 0;
                foreach (var i in CartInventory)
                {
                    Console.WriteLine("{3} = {0}x {1} - {2} each", i.Value, i.Key.Key, i.Key.Value, i.Value * i.Key.Value);
                    Sum += i.Value * i.Key.Value;
                }
                Console.WriteLine($"Total: {Sum}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cart is Empty!");
                Console.ReadKey();
            }
        }
        private void BrowseProduct()
        {
            Products prod = new Products();
            UInt16 count = 1;
            foreach (var i in prod.getProducts())
            {
                Console.WriteLine("{0}. {1} - {2}", count, i.Key, i.Value);
                count++;
            }
            int chosen = Convert.ToInt16(Console.ReadLine());
            // Validate the chosen index
            Console.Clear();
            if (chosen >= 1 && chosen <= prod.getProducts().Count())
            {
                // Accessing the element at the chosen index
                var selectedProduct = prod.getProducts().ElementAt(chosen - 1); // Adjusting for 0-based index
                string productName = selectedProduct.Key;
                double productPrice = selectedProduct.Value;

                Console.WriteLine($"You selected: {productName} - {productPrice}");
                Console.WriteLine("1. Add\n2. Exit");
                int chosen2 = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (chosen2)
                {
                    case 1:
                        Console.Write("Quantity: ");
                        int Quantity = Convert.ToInt16(Console.ReadLine());
                        AddCart(selectedProduct, Quantity);
                        break;
                    case 2:
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection!");
                Console.ReadKey();
            }
        }
        private void AddCart(KeyValuePair<String, double> selectedProduct, int Quantity)
        {
            foreach (var i in CartInventory)
            {
                if (i.Key.Key == selectedProduct.Key && i.Key.Value == selectedProduct.Value)
                {
                    CartInventory[selectedProduct] += Quantity;
                    Console.WriteLine("Successfully Added!");
                    Console.ReadKey();
                    return;
                }
            }
            CartInventory.Add(selectedProduct, Quantity);
            Console.WriteLine("Successfully Added!");
            Console.ReadKey();
        }
    }
}

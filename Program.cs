using System;

namespace GrocerySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Grocery grocery = new Grocery();
            grocery.Run();
            Console.ReadKey();
        }
    }
}

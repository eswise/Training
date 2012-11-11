using System;
using System.Linq;

namespace WorkingWithLINQ
{
    public class LinqWithDelegates
    {
        public static ProductInfo[] ItemsInStock = new[] {
                new ProductInfo{ Name = "Mac's Coffee", 
                                 Description = "Coffee with TEETH", 
                                 NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", 
                                 Description = "Milk cow's love", 
                                 NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu", 
                                 Description = "Bland as Possible", 
                                 NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops", 
                                 Description = "Cheezy, peppery goodness", 
                                 NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water", 
                                 Description = "From the tap to your wallet", 
                                 NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza", 
                                 Description = "Everyone loves pizza!", 
                                 NumberInStock = 73}
                };

        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");

            // Build the necessary Func<> delegates.
            Func<ProductInfo, bool> searchFilter = new Func<ProductInfo, bool>(Filter);
            Func<ProductInfo, string> itemToProcess = new Func<ProductInfo, string>(ProcessItem);

            // Pass the delegates into the methods of Enumerable.
            var subset = ItemsInStock
              .Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            // Print out the results.
            foreach (var name in subset)
                Console.WriteLine("Item: {0}", name);
            Console.WriteLine();
        }

        // Delegate targets.
        public static bool Filter(ProductInfo product) { return product.Name.Contains("M"); }
        public static string ProcessItem(ProductInfo product) { return product.Name; }
    }
}

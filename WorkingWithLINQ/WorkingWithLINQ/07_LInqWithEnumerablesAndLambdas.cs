using System;
using System.Linq;

namespace WorkingWithLINQ
{
    public class LInqWithEnumerablesAndLambdas
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

        #region LINQ operators
        public static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");

            var subset = from product in ItemsInStock
                         where product.Name.Contains("M")
                         orderby product.Name
                         select product.Name;

            foreach (string name in subset)
                Console.WriteLine("Item: {0}", name);
        }
        #endregion

        #region LINQ using Enumerable and =>
        public static void QueryStringsWithEnumerableAndLambdas()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions *****");
            // Build a query expression using extension methods
            // granted to the Array via the Enumerable type.
            var subset = ItemsInStock.Where(product => product.Name.Contains("M"))
              .OrderBy(product => product.Name).Select(product => product.Name);

            // Print out the results.
            foreach (var name in subset)
                Console.WriteLine("Item: {0}", name);
            Console.WriteLine();
        }

        public static void QueryStringsWithEnumerableAndLambdas2()
        {
            Console.WriteLine("***** Using Enumerable / Lambda Expressions (version 2) *****");

            // Break it down!
            var productsWithSpaces = ItemsInStock.Where(product => product.Name.Contains("M"));
            var orderedproducts = productsWithSpaces.OrderBy(product => product.Name);
            var subset = orderedproducts.Select(product => product.Name);

            foreach (var name in subset)
                Console.WriteLine("Item: {0}", name);
            Console.WriteLine();
        }

        #endregion

        #region LINQ using anon methods
        public static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            
            // Build the necessary Func<> delegates using anonymous methods.
            Func<ProductInfo, bool> searchFilter =
              delegate(ProductInfo product) { return product.Name.Contains("M"); };

            Func<ProductInfo, string> itemToProcess = delegate(ProductInfo product) { return product.Name; };

            // Pass the delegates into the methods of Enumerable.
            var subset = ItemsInStock.Where(searchFilter)
              .OrderBy(itemToProcess).Select(itemToProcess);

            // Print out the results.
            foreach (var name in subset)
                Console.WriteLine("Item: {0}", name);
            Console.WriteLine();
        }
        #endregion
    }
}

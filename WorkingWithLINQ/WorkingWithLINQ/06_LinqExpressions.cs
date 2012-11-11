using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithLINQ
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Description={1}, Number in Stock={2}",
              Name, Description, NumberInStock);
        }
    }

    public static class LinqExpressions
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

        #region Select everything
        public static void SelectEverything()
        {
            // Get everything!
            Console.WriteLine("All product details:");
            var allProducts = from p in ItemsInStock select p;

            foreach (var prod in allProducts)
            {
                Console.WriteLine(prod.ToString());
            }
        }
        #endregion

        #region Only get Names
        public static void ListProductNames()
        {
            // Now get only the names of the products.
            Console.WriteLine("Only product names:");
            var names = from p in ItemsInStock select p.Name;

            foreach (var n in names)
            {
                Console.WriteLine("Name: {0}", n);
            }
        }
        #endregion

        #region Get object subset
        public static void GetOverstock()
        {
            Console.WriteLine("The overstock items!");

            // Get only the items where we have more than
            // 25 in stock.
            var overstock = from p in ItemsInStock where p.NumberInStock > 25 select p;

            foreach (ProductInfo c in overstock)
            {
                Console.WriteLine(c.ToString());
            }
        }
        #endregion

        #region LINQ projections
        public static void GetNamesAndDescriptions()
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in ItemsInStock select new { p.Name, p.Description };

            foreach (var item in nameDesc)
            {
                // Could also use Name and Description properties directly.
                Console.WriteLine(item.ToString());
            }
        }

        public static Array GetProjectedSubset()
        {
            var nameDesc = from p in ItemsInStock select new { p.Name, p.Description };
            return nameDesc.ToArray();
        }

        #endregion

        #region Get count
        public static void GetCountFromQuery()
        {
            // Get count from the query.
            int numb =
            (from p in ItemsInStock where p.NumberInStock < 50 select p).Count();

            // Print out the number of items. 
            Console.WriteLine("{0} items honor the LINQ query.", numb);
        }

        #endregion

        #region Show results in reverse
        public static void ReverseEverything()
        {
            Console.WriteLine("Product in reverse:");
            var allProducts = from p in ItemsInStock select p;
            foreach (var prod in allProducts.Reverse())
            {
                Console.WriteLine(prod.ToString());
            }
        }

        #endregion

        #region OrderBy
        public static void AlphabetizeProductNames()
        {
            // Get names of products, alphabetized.
            var subset = from p in ItemsInStock orderby p.Name select p;

            Console.WriteLine("Ordered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p.ToString());
            }
        }
        #endregion

        #region Except(), Intersect(), Union(), Concat()
        public static void DisplayDiff()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c)
              .Except(from c2 in yourCars select c2);

            Console.WriteLine("Here is what you don't have, but I do:");
            foreach (string s in carDiff)
                Console.WriteLine(s);  // Prints Yugo.
        }

        public static void DisplayIntersection()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            // Get the common members.
            var carIntersect = (from c in myCars select c)
              .Intersect(from c2 in yourCars select c2);

            Console.WriteLine("Here is what we have in common:");
            foreach (string s in carIntersect)
                Console.WriteLine(s);  // Prints Aztec and BMW.
        }

        public static void DisplayUnion()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            // Get the union of these containers. 
            var carUnion = (from c in myCars select c)
              .Union(from c2 in yourCars select c2);

            Console.WriteLine("Here is everything:");
            foreach (string s in carUnion)
                Console.WriteLine(s);  // Prints all common members 
        }

        public static void DisplayConcat()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c)
              .Concat(from c2 in yourCars select c2);

            // Prints:
            // Yugo Aztec BMW BMW Saab Aztec.
            Console.WriteLine("Here is CONCAT");
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }
        public static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c)
              .Concat(from c2 in yourCars select c2);

            // Prints:
            // Yugo Aztec BMW Saab Aztec.
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s);
        }

        #endregion

        #region Agg Ops
        public static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            // Various aggregation examples. 
            Console.WriteLine("Max temp: {0}",
              (from t in winterTemps select t).Max());

            Console.WriteLine("Min temp: {0}",
              (from t in winterTemps select t).Min());

            Console.WriteLine("Average temp: {0}",
              (from t in winterTemps select t).Average());

            Console.WriteLine("Sum of all temps: {0}",
              (from t in winterTemps select t).Sum());
        }
        #endregion
    }
}

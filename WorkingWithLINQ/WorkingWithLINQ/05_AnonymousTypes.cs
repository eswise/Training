using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingWithLINQ
{
    public class AnonymousTypes
    {
        public static void Demonstrate()
        {
            var invoice = new
            {
                InvoiceNumber = 1,
                PurchaseDate = DateTime.Today,
                InvoiceItem = new {Quantity=1, UnitPrice=22.00, TotalPrice = 22.00}
            };

            Console.WriteLine("Invoice {0} Total Due: {1:C}", invoice.InvoiceNumber, invoice.InvoiceItem.TotalPrice);
        }

        public static void EqualityTest()
        {
            // Make 2 anonymous classes with identical name/value pairs.
            var firstProduct = new { Color = "Blue", Name = "Widget", RetailPrice = 55 };
            var secondProduct = new { Color = "Blue", Name = "Widget", RetailPrice = 55 };

            // Are they considered equal when using Equals()?
            if (firstProduct.Equals(secondProduct))
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            // Are they considered equal when using ==?
            if (firstProduct == secondProduct)
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            // Are these objects the same underlying type?
            if (firstProduct.GetType().Name == secondProduct.GetType().Name)
                Console.WriteLine("We are both the same type!");
            else
                Console.WriteLine("We are different types!");

            // Show all the details.
            Console.WriteLine();
            ReflectOverAnonymousType(firstProduct);
            ReflectOverAnonymousType(secondProduct);
        }

        static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}",
              obj.GetType().Name,
              obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }
    }
}

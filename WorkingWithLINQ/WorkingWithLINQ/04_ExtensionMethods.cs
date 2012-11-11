using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WorkingWithLINQ
{
    /* Extension methods allow you to "attach" new functionality to existing classes (like sealed ones)
     * They also can be used to clean up your code by moving logic like validation and conversion out of the main class
     * Extensions must be static and use the this keyword to identify the extended class
     */
    public static class ObjectExtensions
    {
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here:\n\t->{1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()));
        }

        public static void Demonstrate()
        {
            var myInt = 100;
            myInt.DisplayDefiningAssembly();

            var ds = new System.Data.DataSet();
            ds.DisplayDefiningAssembly();
        }
    }

   
}

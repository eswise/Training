using System;

namespace WorkingWithLINQ
{
    public class ImplicitVariables
    {
        /* Many LINQ queries return a sequence of data types which are unknown until compile time. 
         * Implicit typing was created to handle this situation
         */
        public static void Demonstrate()
        {
            var aString = "Hello implicit typing!";
            var aBool = true;
            var aDouble = 20.52;

            Console.WriteLine("aString is a: {0}", aString.GetType().Name);
            Console.WriteLine("aBool is a: {0}", aBool.GetType().Name);
            Console.WriteLine("aDouble is a: {0}", aDouble.GetType().Name);
        }
    }
}

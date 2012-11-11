using System;

// credit to Andrew Troelsen for many of these examples.  His latest book can be found here: http://www.apress.com/9781430242338
namespace WorkingWithLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImplicitVariables.Demonstrate();
            //LambdaExpressions.Demonstrate();
            //LambdaExpressions.DemonstrateEventLambda();
            //ObjectExtensions.Demonstrate();
            //AnonymousTypes.Demonstrate();
            //AnonymousTypes.EqualityTest();

            
            /*
            LinqExpressions.SelectEverything();
            Console.WriteLine();
            LinqExpressions.ListProductNames();
            Console.WriteLine();
            LinqExpressions.GetOverstock();
            Console.WriteLine();
            LinqExpressions.GetNamesAndDescriptions();
            Console.WriteLine();
            LinqExpressions.GetProjectedSubset();
            Console.WriteLine();

            Array objs = LinqExpressions.GetProjectedSubset();
            foreach (object o in objs)
            {
                Console.WriteLine(o);  // Calls ToString() on each anonymous object.
            }
            Console.WriteLine();
            LinqExpressions.GetCountFromQuery();
            Console.WriteLine();
            LinqExpressions.ReverseEverything();
            Console.WriteLine();
            LinqExpressions.AlphabetizeProductNames();
            Console.WriteLine();
            LinqExpressions.DisplayDiff();
            Console.WriteLine();

            LinqExpressions.DisplayIntersection();
            Console.WriteLine();
            LinqExpressions.DisplayUnion();
            Console.WriteLine();
            LinqExpressions.DisplayConcat();
            Console.WriteLine();
            LinqExpressions.DisplayConcatNoDups();
            Console.WriteLine();
            LinqExpressions.AggregateOps();
            Console.ReadLine(); 
            */

            LInqWithEnumerablesAndLambdas.QueryStringWithOperators();
            LInqWithEnumerablesAndLambdas.QueryStringsWithEnumerableAndLambdas();
            LInqWithEnumerablesAndLambdas.QueryStringsWithEnumerableAndLambdas2();
            LInqWithEnumerablesAndLambdas.QueryStringsWithAnonymousMethods();

            LinqWithDelegates.QueryStringsWithRawDelegates();
            Console.ReadLine();
        }
    }
}

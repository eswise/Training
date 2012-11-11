using System;
using System.Collections.Generic;

namespace WorkingWithLINQ
{
    public class LambdaExpressions
    {
        /* Lambda operators allow you to build expressions to be passed as a delegate argument
         * ( ArgumentsToProcess) => {Statements to Process}
         * Many Linq query arguments accept lambdas
         */
        public static void Demonstrate()
        {
            List<string> names = new List<string>();
            names.AddRange(new string[] { "Eric", "Jane", "Joe", "Betty", "Rachel", "Robert" });

            var filteredNames = names.FindAll(n => n.Contains("a"));
            Console.WriteLine("Here are the names containing 'a': ");

            foreach (string name in filteredNames)
                Console.Write("{0}\t", name);
        }

        /* Another lambda example using event handling
         */
        public static void DemonstrateEventLambda()
        {   
            SimpleEventRaiser s = new SimpleEventRaiser();

            s.SetMessageHandler((string msg) => Console.WriteLine("Received Event Message: {0}", msg));
            s.SendMessage("Hello!");
        }

        private class SimpleEventRaiser
        {
            public delegate void EventMessage(string msg);
            private EventMessage _emDelegate;

            public void SetMessageHandler(EventMessage target)
            {
                _emDelegate = target;
            }

            public void SendMessage(string message)
            {
                if (_emDelegate != null)
                    _emDelegate.Invoke(message);
            }
        }
    }
}

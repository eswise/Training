using System.Collections.Generic;

namespace WorkingWithLINQ
{
    public class ObjectInitializationSyntax
    {
        public static void Demonstrate()
        {
            List<Rectangle> myShapes = new List<Rectangle>
                                           {
                                               new Rectangle
                                                   {
                                                       TopLeft = new Point {X = 1, Y = 1},
                                                       BottomRight = new Point {X = 10, Y = 10}
                                                   },
                                               new Rectangle
                                                   {
                                                       TopLeft = new Point {X = 2, Y = 2},
                                                       BottomRight = new Point {X = 20, Y = 20}
                                                   },
                                               new Rectangle
                                                   {
                                                       TopLeft = new Point {X = 5, Y = 5},
                                                       BottomRight = new Point {X = 50, Y = 50}
                                                   }
                                           };

        }

        private class Rectangle
        {
            public Point TopLeft { get; set; }
            public Point BottomRight { get; set; }
    }

        private class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}

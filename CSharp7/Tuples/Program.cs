using System;

namespace Tuples
{
    public class Program
    {
        public static (int x, int y) GetPoint()
        {
            return (100, 200);
        }

        public static void Main(string[] args)
        {
            (int x, int y) point = GetPoint();
            Console.WriteLine($"{point.x} {point.y}");

            #region Change1

            //point.x = 0;
            //Console.WriteLine($"{point.x} {point.y}");

            #endregion

            #region Change2

            //(int x1, int y1) point2 = point;  // COPY!
            //point2.x1 = 0;
            //Console.WriteLine($"{point.x} {point.y}");
            //Console.WriteLine($"{point2.x1} {point2.y1}");

            #endregion


            #region Deconstruct

            //(int a, int b) = GetPoint();
            //Console.WriteLine($"{a} {b}");

            //var (i, j) = GetPoint();
            //Console.WriteLine($"{i} {j}");

            #endregion

        }
    }

    #region Point
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
            => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y)
            => (x, y) = (X, Y);

        public static implicit operator Point((int x, int y) tuple)
            => new Point(tuple.x, tuple.y);
    }

    public class MyProgram
    {
        public void Foo()
        {
            var (x, y) = new Point(1, 2);
        }

        public Point GetPoint()
        {
            return (1, 2);
        }

        public Point[] Points =
        {
            (1, 1),
            (2, 2),
            (3, 3),
            (4, 4)
        };
    }
    #endregion
}

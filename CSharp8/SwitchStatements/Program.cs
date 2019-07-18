using System;
using System.Net;
using System.Net.Http;

namespace SwitchStatements
{
    public class Program
    {
        public static void Main()
        {
            var shape = GetShape();

            //var result = shape switch
            //{
            //    Triangle t => $"Triangle: {t.A} {t.B} {t.C}",
            //    Rectangle s when s.Height == s.Width => $"Rectangle: {s.Height} {s.Width}",
            //    Rectangle r => $"Rectangle: {r.Height} {r.Width}"
            //};

            switch (shape)
            {
                case Triangle t:
                    Console.WriteLine($"Triangle: {t.A} {t.B} {t.C}");
                    break;

                case Rectangle s when s.Height == s.Width:
                    Console.WriteLine($"Square: {s.Height}");
                    break;

                case Rectangle r:
                    Console.WriteLine($"Rectangle: {r.Height} {r.Width}");
                    break;
            }
        }

        public static void Example2()
        {
            var shape = GetShape();

            var result = shape switch
            {
                Rectangle s when s.Width == s.Height => $"Square!",

            #region Tuple
                Rectangle (var w, var h, var (_, y)) => $"{w} {h} {y}",
            #endregion

            #region Positional
                Triangle (0, 0, _, _) => $"0, 0",
            #endregion
                 
            #region Properties
                Triangle { A: 5 } t => $"{t.A} {t.B}",
                #endregion

            #region Default
                _ => $"Other!"
            #endregion
            };
        }

        public static void Example3(HttpResponseMessage message)
        {
            var result = message switch
            {
                { StatusCode: HttpStatusCode.OK } => $"OK",
                { StatusCode: HttpStatusCode.NotModified } => $"NotModified",
                { StatusCode: HttpStatusCode.BadRequest } => throw new Exception("BadRequest"),
                _ => throw new Exception("Da fuq?!")
            };
        }

        private static Shape GetShape()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Shape
    {
        public Point Point { get; set; }
    }

    public class Triangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public void Deconstruct(out int a, out int b, out int c, out Point p)
        {
            a = A;
            b = B;
            c = C;
            p = Point;
        }
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void Deconstruct(out int width, out int height, out Point p)
        {
            width = Width;
            height = Height;
            p = Point;
        }
    }

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
}

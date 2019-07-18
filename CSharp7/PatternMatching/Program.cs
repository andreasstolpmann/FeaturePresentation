using System;

namespace PatternMatching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Shape shape = GetShape();

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

        private static Shape GetShape()
        {
            throw new NotImplementedException();
        }
    }


    public abstract class Shape { }

    public class Triangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
}

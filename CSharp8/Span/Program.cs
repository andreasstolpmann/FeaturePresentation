using System;

namespace Span
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var part = data[1..3];
            part[0] = 100;

            foreach (var i in data)
                Console.WriteLine(i);
            Console.WriteLine();

            Span<int> span = data.AsSpan();
            var spanPart = span[1..3];
            spanPart[0] = 100;

            foreach (var i in data)
                Console.WriteLine(i);
            Console.WriteLine();

        }
    }
}

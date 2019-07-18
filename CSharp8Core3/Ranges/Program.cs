using System;

namespace Ranges
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] part = data[2..7];
            foreach (var i in part)
                Console.WriteLine(i);
            Console.WriteLine();

            Range range = 3..^1;
            foreach (var i in data[range])
                Console.WriteLine(i);
            Console.WriteLine();

            //var range = 2..;
            //var range = ^2..;
            //var range = ..4;
            //var range = ..^4;
            //var range = ..;

            var nine = data[^1]; // Last element! (^0 == IndexOutOfBounds)
            Console.WriteLine(nine);
            Console.WriteLine();

            int start = 4;
            Index end = ^3;
            foreach (var i in data[start..end])
                Console.WriteLine(i);
            Console.WriteLine();
        }
    }
}

using System;

namespace NullCoalescingAssignmentOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(null);
        }

        static void Print(string s)
        {
            // s = s ?? "NotNull!"

            s ??= "NotNull!";

            Console.WriteLine(s);
        }

    }
}

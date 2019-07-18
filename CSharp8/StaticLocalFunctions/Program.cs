using System;

namespace StaticLocalFunctions
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int StaticX = 5;

        public void Example()
        {
            int i = 5;
            Print();

            void Print()
            {
                Console.WriteLine(i + StaticX);
            }
        }

    }
}

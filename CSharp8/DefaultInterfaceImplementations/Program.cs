using System;

namespace DefaultInterfaceImplementations
{
    public interface IFoo
    {
        void DoStuff() => Console.WriteLine("foo");
    }

    public static class FooExtensions
    {
        public static void DoStuff2(this IFoo foo) => Console.WriteLine("bar");
    }

    public class Program : IFoo
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            // Error
            //program.DoStuff();

            IFoo foo = new Program();
            foo.DoStuff();

            program.Bar();
        }

        public void Bar()
        {
            // DoStuff(); // Error
            ((IFoo) this).DoStuff();
            this.DoStuff2();
        }
    }
}
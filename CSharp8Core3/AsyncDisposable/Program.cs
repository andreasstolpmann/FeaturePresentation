using System;
using System.Threading.Tasks;

namespace AsyncDisposable
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Before");
            await using var mad = new MyAsyncDisposable();
            Console.WriteLine("After");
        }
    }

    public class MyAsyncDisposable : IAsyncDisposable
    {
        public MyAsyncDisposable()
        {
            Console.WriteLine("ctor");
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("Begin dispose");
            await Task.Delay(500);
            Console.WriteLine("End dispose");
        }
    }
}

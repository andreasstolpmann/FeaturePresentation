using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncEnumerable
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await foreach (var value in Get())
            {
                Console.WriteLine(value);
            }
        }

        private static async IAsyncEnumerable<int> Get()
        {
            yield return 0;
            for (int i = 0; i < 10; ++i)
            {
                yield return await Task.Delay(500).ContinueWith(_ => i);
            }
        }
    }
}

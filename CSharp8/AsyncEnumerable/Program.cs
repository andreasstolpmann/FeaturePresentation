using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncEnumerable
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var values = Get();
            await foreach (var value in values)
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

        private static async IAsyncEnumerable<string> GetPage()
        {
            using var client = new HttpClient();
            await using var stream = await client.GetStreamAsync("http://www.google.de");
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                yield return await reader.ReadLineAsync();
                await Task.Delay(500);
            }
        }
    }
}

using System.Net.Http;

namespace UsingDeclarations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.GetAsync("www.google.de");
            }
        }
    }
}

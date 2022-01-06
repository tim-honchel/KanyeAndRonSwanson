using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeAndRonSwanson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine("A conversation overhead between Kanye West and Ron Swanson:");
            Console.WriteLine();

            for (int i = 1; i <= 5; i++)
            {
                var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye: '{kanyeQuote}'");
                Console.WriteLine();

                var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine();
            }
        }
    }
}

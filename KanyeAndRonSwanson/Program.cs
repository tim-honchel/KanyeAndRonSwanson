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

            Console.WriteLine("We are about to hear a conversation between 2 famous characters.");
            Console.WriteLine();
            
            Console.WriteLine("Choose the first person by pressing the number next to their name:");
            Console.WriteLine("1 Kanye West");
            Console.WriteLine("2 Ron Swanson");
            Console.WriteLine("3 Jerry Seinfeld");;
            Console.WriteLine("4 Iron Man");
            Console.WriteLine("");
            var option1 = '0';
            while (option1 != '1' && option1 != '2' && option1 != '3' && option1 != '4')
            {
                Console.CursorLeft = 0;
                option1 = Console.ReadKey().KeyChar;
            }
            var person1 = "";
            switch (option1)
            {
                case '1':
                    person1 = "Kanye West";
                    break;
                case '2':
                    person1 = "Ron Swanson";
                    break;
                case '3':
                    person1 = "Jerry Seinfeld";
                    break;
                case '4':
                    person1 = "Iron Man";
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Choose the second person by pressing the number next to their name:");
            Console.WriteLine("1 Kanye West");
            Console.WriteLine("2 Ron Swanson");
            Console.WriteLine("3 Jerry Seinfeld");
            Console.WriteLine("4 Iron Man");
            Console.WriteLine("");
            var option2 = '0';
            while (option2 != '1' && option2 != '2' && option2 != '3' && option2 != '4')
            {
                Console.CursorLeft = 0;
                option2 = Console.ReadKey().KeyChar;
            }
            var person2 = "";
            switch (option2)
            {
                case '1':
                    person2 = "Kanye West";
                    break;
                case '2':
                    person2 = "Ron Swanson";
                    break;
                case '3':
                    person2 = "Jerry Seinfeld";
                    break;
                case '4':
                    person2 = "Iron Man";
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"You are about to overhear a conversation between {person1} and {person2}. Press any key when you are ready.");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            Random random = new Random();
            var number = random.Next(2, 6);

            for (int i = 1; i <= number; i++)
            {
                switch (option1)
                {
                    case '1':
                        Kanye(client);
                        break;
                    case '2':
                        Swanson(client);
                        break;
                    case '3':
                        Seinfeld(client);
                        break;
                    case '4':
                        IronMan(client);
                        break;
                }
                switch (option2)
                {
                    case '1':
                        Kanye(client);
                        break;
                    case '2':
                        Swanson(client);
                        break;
                    case '3':
                        Seinfeld(client);
                        break;
                    case '4':
                        IronMan(client);
                        break;
                }


            }
        }
        static void IronMan(HttpClient client)
        {
            var ironManResponse = client.GetStringAsync("https://superhero-search.herokuapp.com/api/quotes/random/character?name=ironMan").Result;
            var ironManQuote = JObject.Parse(ironManResponse).GetValue("quote").ToString();
            Console.WriteLine($"Iron Man: '{ironManQuote}'");
            Console.WriteLine();
        }
        static void Kanye(HttpClient client)
        {
            var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine($"Kanye: '{kanyeQuote}'");
            Console.WriteLine();
        }
        static void Seinfeld(HttpClient client)
        {
            var seinfeldResponse = client.GetStringAsync("https://seinfeld-quotes.herokuapp.com/random").Result;
            var seinfeldQuote = "";
            var seinfeldCharacter = "";

            while (seinfeldCharacter != "Jerry")
            {
                seinfeldResponse = client.GetStringAsync("https://seinfeld-quotes.herokuapp.com/random").Result;
                seinfeldQuote = JObject.Parse(seinfeldResponse).GetValue("quote").ToString();
                seinfeldCharacter = JObject.Parse(seinfeldResponse).GetValue("author").ToString();
            }
           
            Console.WriteLine($"Seinfeld: '{seinfeldQuote}'");
            Console.WriteLine();
        }
 
        static void Swanson(HttpClient client)
        {
            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine($"Ron: {ronQuote}");
            Console.WriteLine();
        }
    }
}

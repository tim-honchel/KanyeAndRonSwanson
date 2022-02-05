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
            Console.WriteLine("3 Jerry Seinfeld");
            Console.WriteLine("4 Han Solo");
            Console.WriteLine("5 Iron Man");
            Console.WriteLine("6 Donald Trump");
            Console.WriteLine("");
            var option1 = '0';
            while (option1 != '1' && option1 != '2' && option1 != '3' && option1 != '4' && option1 != '5' && option1 != '6')
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
                    person1 = "Han Solo";
                    break;
                case '5':
                    person1 = "Iron Man";
                    break;
                case '6':
                    person1 = "Donald Trump";
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Choose the second person by pressing the number next to their name:");
            Console.WriteLine("1 Kanye West");
            Console.WriteLine("2 Ron Swanson");
            Console.WriteLine("3 Jerry Seinfeld");
            Console.WriteLine("4 Han Solo");
            Console.WriteLine("5 Iron Man");
            Console.WriteLine("6 Donald Trump");
            Console.WriteLine("");
            var option2 = '0';
            while (option2 != '1' && option2 != '2' && option2 != '3' && option2 != '4' && option2 != '5' && option2 != '6')
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
                    person2 = "Han Solo";
                    break;
                case '5':
                    person2 = "Iron Man";
                    break;
                case '6':
                    person2 = "Donald Trump";
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
                        Solo(client);
                        break;
                    case '5':
                        IronMan(client);
                        break;
                    case '6':
                        Trump(client);
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
                        Solo(client);
                        break;
                    case '5':
                        IronMan(client);
                        break;
                    case '6':
                        Trump(client);
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
        static void Solo(HttpClient client)
        {
            var soloQuote = "";
            try
            {
                var soloResponse = client.GetStringAsync("http://swquotesapi.digitaljedi.dk/api/SWQuote/RandomStarWarsQuote").Result; // maybe needs header: https://wolfgang-ziegler.com/blog/starwars-quotes-web-api
                soloQuote = "";
                var hyphenPosition = 0;
                var soloCharacter = "";

                while (soloCharacter != "Han Solo")
                //for (int i=0; i < 10; i++)
                {
                    soloResponse = client.GetStringAsync("http://swquotesapi.digitaljedi.dk/api/SWQuote/RandomStarWarsQuote").Result;
                    soloQuote = JObject.Parse(soloResponse).GetValue("starWarsQuote").ToString();
                    hyphenPosition = soloQuote.LastIndexOf('—');
                    soloCharacter = soloQuote.Substring(hyphenPosition + 2);
                    //Console.WriteLine(soloCharacter + ": " + soloQuote);
                }
            }
            catch (Exception ex)
            {
                soloQuote = "Not ready yet.";
            }
            Console.WriteLine($"Solo: '{soloQuote}'");
            Console.WriteLine();
        }
        static void Swanson(HttpClient client)
        {
            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine($"Ron: {ronQuote}");
            Console.WriteLine();
        }
        static void Trump(HttpClient client)
        {
            var trumpQuote = "";
            try
            {
                var trumpResponse = client.GetStringAsync("https://api.tronalddump.io/random/quote").Result; // need to figure out headers to avoid bad request https://github.com/tronalddump-io/tronald-app#readme
                trumpQuote = JObject.Parse(trumpResponse).GetValue("value").ToString();
            }
            catch (Exception)
            {
                trumpQuote = "Not ready yet";
            }
            Console.WriteLine($"Trump: '{trumpQuote}'");
            Console.WriteLine();
        }
    }
}

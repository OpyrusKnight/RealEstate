using System.Net.Http.Json;

namespace AdminConsumer
{
    internal class Program
    {
        public static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7291")
        };
        static void Main(string[] args)
        {
            string? continueAnswer;
            bool toContinue;
            do
            {
                Console.Clear();
                string? nom, description, localisation, raison = "";
                int prix;
                List<byte[]> images = new List<byte[]>();
                bool anotherOne = true;
                Console.Write("Titre : ");
                nom = Console.ReadLine();
                Console.Write("description : ");
                description = Console.ReadLine();
                description = description.Replace("\n", "<br>");
                Console.Write("localisation : ");
                localisation = Console.ReadLine();
                Console.Write("prix : ");
                var px = Console.ReadLine();
                prix = int.Parse(px!);
                do
                {
                    Console.WriteLine("File path : ");
                    var filePath = Console.ReadLine();
                    filePath = filePath.Replace("\"", "");
                    if (File.Exists(filePath))
                    {
                        var file = File.ReadAllBytes(filePath);
                        images.Add(file);
                    }
                    else
                    {
                        Console.WriteLine("The file entered doesn't exit !");
                    }
                    Console.WriteLine("");
                    if (images.Count < 5)
                    {
                        Console.WriteLine("Want to add another one ? o(yes) | n(no)");
                        string? answer = Console.ReadLine();
                        if (answer == "n" || answer?.ToLower() == "no")
                        {
                            anotherOne = false;
                        }
                    }
                } while (anotherOne && images.Count < 5);

                Dictionary<string, object> p = new Dictionary<string, object>
                {
                    { "id", 0 },
                    { "nom", nom },
                    {"description", description},
                    {"prix", prix},
                    {"images", images.ToArray()},
                    {"disponibilite", true},
                    {"localisation", localisation},
                    {"raison", raison},
                    { "type", "Home" },
                    { "size", 1000},
                    {"contrat", "sell"}
                };

                Task.WaitAll(PostNewProduct(p));
                Console.Clear();
                Console.WriteLine("Do you want to post another announcement ? o(yes) | n(no)");
                continueAnswer = Console.ReadLine();
                toContinue = continueAnswer == "o" || continueAnswer == "yes" || continueAnswer == "oui";
            } while (toContinue);
            
        }

        static async Task PostNewProduct(Dictionary<string, object> p)
        {
            var content = JsonContent.Create(p);
            var response = await client.PostAsync("/Produits", content);
            //await Console.Out.WriteLineAsync(JsonSerializer.Serialize(p));
            await Console.Out.WriteLineAsync(response.ToString());
            Console.ReadKey(true);
        }
    }

    

    public class Produit
    {
        public int id { get; set; }
        public string nom { get; set; } = null!;
        public string description { get; set; } = null!;
        public int prix { get; set; }
        public string? type { get; set; }
        public int size { get; set; }
        public string contrat { get; set; }
        public byte[][] images { get; set; }
        public bool disponibilite { get; set; }
        public string localisation { get; set; } = null!;
        public string? raison { get; set; }
    }
}

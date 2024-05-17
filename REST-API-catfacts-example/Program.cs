using REST_API_catfacts_example;
using System.Net.Http.Headers;

HttpClient client = new HttpClient();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

try {
    var facts = CatFactAPI.RandomCatFacts(client);
    
    foreach (CatFact fact in facts.data)
    {
        Console.WriteLine("Did you know?\r\n" + fact.fact + "\r\n");
    }
} catch (Exception e) {
    Console.WriteLine("Error: " + e.Message);
}

Console.ReadKey();
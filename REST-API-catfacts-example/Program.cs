using REST_API_catfacts_example;
using System.Net.Http.Headers;

HttpClient client = new HttpClient();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

try
{
    CatFact fact = CatFactAPI.RandomCatFact(client);

    Console.WriteLine(fact.text);
} catch(Exception e)
{
    Console.WriteLine("ERROR ERROR!");
    Console.WriteLine(e);
}


Console.ReadKey();
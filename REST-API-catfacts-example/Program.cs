using REST_API_catfacts_example;
using System.Net.Http.Headers;

HttpClient client = new HttpClient();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

try {
    CatFact catFact = await CatFact.RandomCatFact(client);

    Console.WriteLine("Did you know?");
    Console.WriteLine($"-- {catFact.text}");
    Console.WriteLine($"-- This fact is exactly {catFact.characterCount} characters long");
} catch (Exception e) {
    Console.WriteLine("Oh no! A cat fact could not be found! Please check your internet connection and try again!");
} finally {
    client.Dispose();
}

Console.ReadKey();
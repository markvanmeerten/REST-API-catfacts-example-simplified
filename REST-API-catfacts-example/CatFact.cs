using System.Text.Json.Serialization;
using System.Text.Json;

namespace REST_API_catfacts_example
{
    public record class CatFact(
        [property: JsonPropertyName("fact")] string text,
        [property: JsonPropertyName("length")] int characterCount
    )
    {

    }

    public class CatFactAPI()
    {
        public static CatFact RandomCatFact(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("https://catfact.ninja/fact").Result;
            response.EnsureSuccessStatusCode();

            string responseBody = response.Content.ReadAsStringAsync().Result;
            CatFact? catFact = JsonSerializer.Deserialize<CatFact>(responseBody);

            if(catFact == null)
            {
                throw new Exception();
            }

            return catFact;
        }
    }
}

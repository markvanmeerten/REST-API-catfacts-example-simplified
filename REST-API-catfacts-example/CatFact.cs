using System.Text.Json.Serialization;
using System.Text.Json;

namespace REST_API_catfacts_example
{
    public record class CatFact(
        [property: JsonPropertyName("fact")] string text,
        [property: JsonPropertyName("length")] int characterCount
    )
    {
        public static async Task<CatFact> RandomCatFact(HttpClient client)
        {
            Stream stream = await client.GetStreamAsync("https://catfact.ninja/fact");

            CatFact? fact = await JsonSerializer.DeserializeAsync<CatFact>(stream);

            stream.Dispose(); // Of gebruik using

            if (fact == null)
            {
                // Is er geen internet? Of er ging iets fout tijdens het deserialiseren van de JSON?
                throw new Exception();
            }

            return fact;
        }
    }
}

using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using System.Xml.Linq;

namespace REST_API_catfacts_example
{
    public class CatFact
    {
        public string fact { get; set; }
        public int length { get; set; }
    }

    public class CatFacts
    {
        public int total { get; set; }

        public List<CatFact> data { get; set; }
    }

    public class CatFactAPI()
    {
        public static CatFact RandomCatFact(HttpClient client)
        {
            // Vraag via HTTP data op
            HttpResponseMessage response = client.GetAsync("https://catfact.ninja/fact").Result;

            // Gooi een Exception als de server een ongeldige statuscode teruggeeft
            response.EnsureSuccessStatusCode();

            // De JSON als pure tekst
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // De variabele `catFact` is van het type `CatFact`, maar het vraagteken betekent dat null ook een geldige waarde is
            CatFact? catFact = JsonSerializer.Deserialize<CatFact>(responseBody);

            if (catFact == null)
            {
                throw new Exception("Invalid JSON");
            }

            // Geef het object terug
            return catFact;
        }

        public static CatFacts RandomCatFacts(HttpClient client)
        {
            // Vraag via HTTP data op
            HttpResponseMessage response = client.GetAsync("https://catfact.ninja/facts").Result;

            // Gooi een Exception als de server een ongeldige statuscode teruggeeft
            response.EnsureSuccessStatusCode();

            // De JSON als pure tekst
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // De variabele `catFacts` is van het type `CatFacts`, maar het vraagteken betekent dat null ook een geldige waarde 
            CatFacts? catFacts = JsonSerializer.Deserialize<CatFacts>(responseBody);

            if (catFacts == null)
            {
                throw new Exception("Invalid JSON");
            }

            return catFacts;
        }
    }
}

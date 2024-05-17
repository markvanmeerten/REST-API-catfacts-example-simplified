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
        public CatFact[] data { get; set; }
    }

    public class CatFactAPI()
    {
        public static CatFact RandomCatFact(HttpClient client)
        {
            // Gebruik HTTP om verbinding te maken met de API
            HttpResponseMessage response = client.GetAsync("https://catfact.ninja/fact").Result;

            // Gooi een Exception als de server een ongeldige statuscode teruggeeft (bijvoorbeeld als de server down is)
            response.EnsureSuccessStatusCode();

            // Vraag de API om de JSON string
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // Zet de JSON string om naar data (van het type CatFact)
            // Het vraagteken betekent dat null ook een geldige waarde is
            CatFact? catFact = JsonSerializer.Deserialize<CatFact>(responseBody);

            // Als `catFact` null is dan is het niet gelukt de JSON tekst te converteren naar data
            if (catFact == null)
            {
                throw new Exception("Invalid JSON");
            }

            // Geef het resultaat terug
            return catFact;
        }

        public static CatFacts RandomCatFacts(HttpClient client)
        {
            // Gebruik HTTP om verbinding te maken met de API
            HttpResponseMessage response = client.GetAsync("https://catfact.ninja/facts").Result;

            // Gooi een Exception als de server een ongeldige statuscode teruggeeft (bijvoorbeeld als de server down is)
            response.EnsureSuccessStatusCode();

            // Vraag de API om de JSON string
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // Zet de JSON string om naar data (van het type CatFact)
            // Het vraagteken betekent dat null ook een geldige waarde is
            CatFacts? catFacts = JsonSerializer.Deserialize<CatFacts>(responseBody);

            // Als `catFact` null is dan is het niet gelukt de JSON tekst te converteren naar data
            if (catFacts == null)
            {
                throw new Exception("Invalid JSON");
            }

            // Geef het resultaat terug
            return catFacts;
        }
    }
}

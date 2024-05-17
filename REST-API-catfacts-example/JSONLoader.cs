using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace REST_API_catfacts_example
{
    public class JSONLoader
    {
        public class Familielid
        {
            public string naam { get; set; }
            public int leeftijd { get; set; }
            public string geboorteplaats { get; set; }
            public string rol { get; set; }
        }

        public class Familie
        {
            public Familielid[] familieleden { get; set; }
        }

        public static string getJSON()
        {
            string json = """
                 [
                    {
                        "naam" : "Tim",
                        "Leeftijd" : 18,
                        "geboorteplaats" : "Elst Utrecht",
                        "rol" : "zoon"
                    },
                    {
                        "naam" : "Jolien",
                        "leeftijd" : 20,
                        "geboorteplaats" : "Elst Utrecht",
                        "rol" : "dochter"
                    },
                    {
                        "naam" : "Johan",
                        "leeftijd" : 52,
                        "geboorteplaats" : "Ederveen",
                        "rol" : "vader"
                    },
                    {
                        "naam" : "Helma",
                        "leeftijd" : 54,
                        "geboorteplaats" : "Ede",
                        "rol" : "Moeder"
                    }
                ]
                
            """;

            List<Familielid>? familie = JsonSerializer.Deserialize<List<Familielid>>(json);

            foreach (Familielid lid in familie)
            {
                Console.WriteLine(lid.naam);
            }

            return json;
        }
    }
}

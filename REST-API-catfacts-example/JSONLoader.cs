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

        public static string getJSON(string filename)
        {
            string json = "{\"fact\":\"A cat can\\u2019t climb head first down a tree because every claw on a cat\\u2019s paw points the same way. To get down from a tree, a cat must back down.\",\"length\":142}";

            CatFact? data = JsonSerializer.Deserialize<CatFact>(json);

            Console.WriteLine("!" + data.fact + "!");

            return json;
        }
    }
}

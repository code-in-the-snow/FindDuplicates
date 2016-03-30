using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIExample
{
    public class Result
    {
        public string id { get; set; }
        public string marketname { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
    }
    
    class Program
    {
        private const string urlBase = "http://search.ams.usda.gov/farmersmarkets/v1/data.svc/zipSearch";
        private static string urlParams = "?zip=94550";
        
        static void Main(string[] args)
        {
            //HttpClient client = new HttpClient();
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);

            // Add an Accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response
            // OLD  HttpResponseMessage response = client.GetAsync(urlParams).Result;
            var response = client.GetAsync(urlParams).Result;
            // Block call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                //var results = JsonConvert.DeserializeObject<RootObject>(string json);
                var vContent = response.Content.ReadAsStringAsync();
                string sContent = vContent.ToString();
                Console.WriteLine(JObject.Parse(sContent));
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("{0}", response.ReasonPhrase);
            }
        }
    }
}

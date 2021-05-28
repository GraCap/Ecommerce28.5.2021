using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Ecommerce.HTTPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Orders HttpClient ===");

            HttpClient client = new();

            #region GET REQUEST

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44345/order")
            };

            HttpResponseMessage response = client.SendAsync(httpRequest).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonData = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<OrderContract>>(jsonData);

                foreach (var item in result)
                    Console.WriteLine($"Ordine n° {item.ID}. Data: {item.OrderDate}. Codice Prodotto: {item.ProductCode}." +
                      $"Importo: {item.Amount}"); ;

            }

            #endregion

            #region POST REQUEST

            HttpRequestMessage httpPostRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44345/order")
            };

            OrderContract payload = new OrderContract
            {
                ID = 10,
                OrderDate = DateTime.Now,
                OrderCode = "A3289-3829-9503",
                ProductCode = "KKK8290",
                Amount = 120,
                ClientId = 1,
            };
            string json = JsonConvert.SerializeObject(payload);
            httpPostRequest.Content = new StringContent(json,
                Encoding.UTF8, "application/json");

            HttpResponseMessage postResponse = client.SendAsync(httpPostRequest).Result;

            if (postResponse.IsSuccessStatusCode)
            {
                // mi occupo di leggere i dati dal body
                string jsonData = postResponse.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<OrderContract>(jsonData);
                Console.WriteLine();
                Console.WriteLine($"[{result.ID}] [{result.OrderDate}] [{result.ProductCode}]" +
                      $"[{result.Amount}] - SAVED!");
            }

            #endregion
        }
    }
}

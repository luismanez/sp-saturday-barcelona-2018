using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GraphBatchRequest.Authentication;
using GraphBatchRequest.Helpers;
using GraphBatchRequest.Models;
using Newtonsoft.Json;

namespace GraphBatchRequest
{
    /// <summary>
    /// Net 4.6 Console app showing how to call Graph API to get different endpoint in a Batch request
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                BatchRequestDemo().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();            
        }

        private static async Task BatchRequestDemo()
        {
            var token = await TokenProvider.GetToken();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var data = BatchRequestHelper.GetSampleBatchRequest().ToString();

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://graph.microsoft.com/v1.0/$batch", content);

            var json = await response.Content.ReadAsStringAsync();

            var batchResponse = JsonConvert.DeserializeObject<BatchResponse>(json);

            var tasks = batchResponse.responses
                .Where(r => r.id.Equals("1"))
                .Select(t => t.body.value).FirstOrDefault();

            Console.WriteLine("My Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"    {task.title}");
            }

            var events = batchResponse.responses
                .Where(r => r.id.Equals("2"))
                .Select(t => t.body.value).FirstOrDefault();

            Console.WriteLine("\r\nMy Events:");
            foreach (var e in events)
            {
                Console.WriteLine($"    {e.subject}");
            }

            var emails = batchResponse.responses
                .Where(r => r.id.Equals("3"))
                .Select(t => t.body.value).FirstOrDefault();

            Console.WriteLine("\r\nMy Emails:");
            foreach (var email in emails)
            {
                Console.WriteLine($"    {email.subject}");
            }

        }
    }
}

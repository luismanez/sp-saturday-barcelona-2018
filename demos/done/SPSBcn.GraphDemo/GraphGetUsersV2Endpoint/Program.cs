using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace GraphGetUsersV2Endpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetUsers().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static async Task GetUsers()
        {
            var scopes = new[] { "user.read.all" };

            var token = await TokenProvider.GetToken(scopes);

            var delegateAuthProvider = new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

                return Task.FromResult(0);
            });

            var graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0", delegateAuthProvider);

            //Get 10 Users sorted by Name
            var users = await graphClient.Users.Request()
                .Top(10)
                .OrderBy("displayName")
                .Select("id, displayName")
                .GetAsync();

            Console.WriteLine("First 10 Users in your tenant...");
            foreach (var user in users)
            {
                Console.WriteLine($"    {user.DisplayName}. Id: {user.Id}");
            }            
        }
    }
}

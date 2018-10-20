using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace GraphGetGroups
{
    /// <summary>
    /// .NET Core 2.1 Console App showing how to call MS Graph getting Groups using App Permissions and MS Graph .Net SDK
    /// Dependencies:
    ///     Microsoft.Graph
    ///     Microsoft.IdentityModel.Clients.ActiveDirectory
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {                
                GetGroups().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();            
        }

        private static async Task GetGroups()
        {
            var token = await TokenProvider.GetToken();

            //DelegateAuthenticationProvider bearer Token

            //create GraphServiceClient


            //Get 10 Groups sorted by displayName. Select: id, visibility, createdDateTime, displayName
            

            //Console.WriteLine("First 10 Groups in your tenant...");
            //foreach (var group in groups)
            //{
            //    Console.WriteLine($"    {group.DisplayName}. Created: {group.CreatedDateTime}. Visibility {group.Visibility}");
            //}

            //Get Groups where name starts with "Yam": startsWith('yam', displayName)
            

            //Console.WriteLine("\r\nGroups starting by 'Yam'...");
            //foreach (var group in groups)
            //{
            //    Console.WriteLine($"    {group.DisplayName}. Created: {group.CreatedDateTime}. Visibility {group.Visibility}");
            //}

        }
    }
}

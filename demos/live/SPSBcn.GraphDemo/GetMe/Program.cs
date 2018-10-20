using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GetMe
{
    internal class Program
    {
        /// <summary>
        /// Net 4.6 Console app showing how to call Graph API to get the Me endpoint using Delegated permissions and pure REST queries
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            try
            {
                var me = GetMe().GetAwaiter().GetResult();
                Console.WriteLine(me.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static async Task<MeInfo> GetMe()
        {
            //Get Delegated permissions Token using Web Login
            var token = await TokenProvider.GetToken();

            //Create HttpClient and Add Bearer header            

            //GET Graph endpoint: https://graph.microsoft.com/v1.0/me?$select=Id,DisplayName,JobTitle,GivenName,Surname,Mail
            

            //var json = await response.Content.ReadAsStringAsync();

            //var me = JsonConvert.DeserializeObject<MeInfo>(json);

            //return me;
        }
    }
}

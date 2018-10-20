using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace GraphGetGroups
{
    public static class TokenProvider
    {
        private const string GraphResourceUri = "https://graph.microsoft.com";

        /// <summary>
        /// Uses ADAL to return a App-Only Token (application permissions)
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetToken()
        {
            var azureAdSettings = AzureActiveDirectorySettings.Initialize();

            var credentials = new ClientCredential(azureAdSettings.ClientId, azureAdSettings.Secret);
            var authority = string.Format(azureAdSettings.Authority, azureAdSettings.Tenant);

            // Specify your own TokenCache. Using default In-memory TokenCache
            var authContext = new AuthenticationContext(authority);

            try
            {
                var authResult = await authContext.AcquireTokenAsync(GraphResourceUri, credentials);

                return authResult.AccessToken;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

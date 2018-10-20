using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace GraphGetUsersV2Endpoint
{
    public static class TokenProvider
    {
        private const string GraphResourceUri = "https://graph.microsoft.com";

        /// <summary>
        /// Uses MSAL (v2 endpoint) to return a Token using Web Login form (delegated permissions)
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetToken(string[] scopes)
        {
            var azureAdSettings = AzureActiveDirectorySettings.Initialize();

            AuthenticationResult authResult;

            var publicClientApp = new PublicClientApplication(azureAdSettings.ClientId);

            var accounts = await publicClientApp.GetAccountsAsync();

            try
            {
                authResult = await publicClientApp.AcquireTokenSilentAsync(scopes, accounts.FirstOrDefault());

                return authResult.AccessToken;
            }
            catch (MsalUiRequiredException ex)
            {
                try
                {
                    authResult = await publicClientApp.AcquireTokenAsync(scopes);

                    return authResult.AccessToken;
                }
                catch (MsalException msalex)
                {
                    System.Diagnostics.Debug.WriteLine($"MsalException: {ex.Message}");
                }
            }

            return null;
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace GraphBatchRequest.Authentication
{
    public static class TokenProvider
    {
        private const string GraphResourceUri = "https://graph.microsoft.com";

        /// <summary>
        /// Uses ADAL to return a Token using Web Login form (delegated permissions)
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetToken()
        {
            var azureAdSettings = AzureActiveDirectorySettings.Initialize();

            var authority = string.Format(azureAdSettings.Authority, azureAdSettings.Tenant);
            AuthenticationResult authResult;
            var authContext = new AuthenticationContext(authority);

            try
            {
                authResult = await authContext.AcquireTokenSilentAsync(GraphResourceUri, azureAdSettings.ClientId);

                return authResult.AccessToken;
            }
            catch (AdalSilentTokenAcquisitionException)
            {
                authResult = await authContext.AcquireTokenAsync(
                    GraphResourceUri,
                    azureAdSettings.ClientId,
                    new Uri(azureAdSettings.ReturnUri),
                    new PlatformParameters(PromptBehavior.Auto));

                return authResult.AccessToken;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

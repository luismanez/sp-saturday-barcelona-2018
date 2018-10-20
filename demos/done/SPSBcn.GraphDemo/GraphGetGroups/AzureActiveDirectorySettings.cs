using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace GraphGetGroups
{
    public class AzureActiveDirectorySettings
    {
        public string Tenant { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Authority { get; set; }
        public string ReturnUri { get; set; }

        public static AzureActiveDirectorySettings Initialize()
        {
            return JsonConvert.DeserializeObject<AzureActiveDirectorySettings>(
                File.ReadAllText(@"C:\Github\sp-saturday-madrid-2018\demos\done\SPSMadrid.GraphDemo\secrets.app1.json"));
        }
    }
}

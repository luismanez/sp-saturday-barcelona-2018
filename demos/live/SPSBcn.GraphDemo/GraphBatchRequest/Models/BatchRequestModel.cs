using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace GraphBatchRequest.Models
{
    public class BatchRequest
    {
        public List<Request> Requests { get; set; }

        public override string ToString()
        {
            var serializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

            return JsonConvert.SerializeObject(this,
                Formatting.Indented,
                serializerSettings);
        }
    }

    public class Request
    {
        public string Id { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
    }

    public class Headers
    {
        public string ContentType { get; set; }
    }
}

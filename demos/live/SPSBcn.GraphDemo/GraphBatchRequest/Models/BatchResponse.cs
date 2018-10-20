using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBatchRequest.Models
{
    public class BatchResponse
    {
        public List<Response> responses { get; set; }
    }

    public class Response
    {
        public string id { get; set; }
        public int status { get; set; }
        public Headers headers { get; set; }
        public Body body { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string subject { get; set; }
        public string title { get; set; }
    }

    public class Body
    {
        public List<Value> value { get; set; }
    }       
}

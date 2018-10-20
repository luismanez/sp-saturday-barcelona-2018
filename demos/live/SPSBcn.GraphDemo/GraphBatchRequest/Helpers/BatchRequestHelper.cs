using GraphBatchRequest.Models;
using System.Collections.Generic;

namespace GraphBatchRequest.Helpers
{
    public class BatchRequestHelper
    {
        public static BatchRequest GetSampleBatchRequest()
        {
            return new BatchRequest
            {
                Requests = new List<Request>
                {
                    new Request
                    {
                        Id = "1",
                        Method = "GET",
                        Url = "/me/planner/tasks?$select=title&$top=3"
                    },
                    new Request
                    {
                        Id = "2",
                        Method = "GET",
                        Url = "/me/calendar/events?$select=subject&$top=3"
                    },
                    new Request
                    {
                        Id = "3",
                        Method = "GET",
                        Url = "/me/messages?$select=subject&$top=3"
                    }
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMe
{
    public class MeInfo
    {
        public string Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string Mail { get; set; }

        public override string ToString()
        {
            return $"{Surname}, {GivenName}\r\n ({DisplayName}). \r\n JobTitle: {JobTitle}\r\n Email: {Mail}";
        }
    }
}

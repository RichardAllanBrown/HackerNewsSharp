using System;
using System.Collections.Generic;

namespace HackerNewsSharp.Responses
{
    public class UserResponse
    {
        public string id { get; set; }

        public long delay { get; set; }

        public long created { get; set; }

        public int karma { get; set; }

        public string about { get; set; }

        public List<int> submitted { get; set; }
    }
}

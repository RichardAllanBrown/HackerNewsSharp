using System;
using System.Collections.Generic;

namespace HackerNewsSharp.Responses
{
    public class ItemResponse
    {
        public string id { get; set; }

        public bool deleted { get; set; }

        public string type { get; set; }

        public string by { get; set; }

        public long time { get; set; }

        public string text { get; set; }

        public bool dead { get; set; }

        public string parent { get; set; }

        public List<string> kids { get; set; }

        public string url { get; set; }

        public int score { get; set; }

        public string title { get; set; }

        public List<string> parts { get; set; }
    }
}

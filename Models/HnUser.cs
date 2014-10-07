using System;
using System.Collections.Generic;

namespace HackerNewsSharp.Models
{
    public class HnUser
    {
        public string Id { get; set; }

        public TimeSpan VisibilityDelay { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Karma { get; set; }

        public string About { get; set; }

        public IEnumerable<string> SubmittedIds { get; set; }
    }
}

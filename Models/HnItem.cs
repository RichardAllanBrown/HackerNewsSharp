using System;
using System.Collections.Generic;

namespace HackerNewsSharp.Models
{
    public class HnItem
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public HnType Type { get; set; }

        public string ById { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Text { get; set; }

        public bool IsDead { get; set; }

        public string ParentId { get; set; }

        public IEnumerable<string> KidIds { get; set; }

        public Uri Url { get; set; }

        public int Score { get; set; }

        public IEnumerable<string> PollOptions { get; set; }
    }
}

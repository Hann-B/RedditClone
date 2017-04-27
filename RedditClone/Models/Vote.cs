using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedditClone.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public bool IsUpVote { get; set; }

        public int PostId { get; set; }
        public RedditPost OnePost { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
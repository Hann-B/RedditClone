using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedditClone.Models
{
    public class RedditPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public string Img { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
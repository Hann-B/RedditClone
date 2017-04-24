using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedditClone.Models;

namespace RedditClone.ViewModels
{
    public class HomePageVM
    {
        public IEnumerable<RedditPost> Posts { get; set; } = new HashSet<RedditPost>();

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public LoginViewModel LoginVM { get; set; }
    }
}
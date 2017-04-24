using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedditClone.Models;
using Microsoft.AspNet.Identity;

namespace RedditClone.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "What's Hot";
            var db = new ApplicationDbContext();
            var posts = db.Posts.OrderByDescending(o=>o.DatePosted).ToList();
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserId = User.Identity.GetUserId();
            }
            return View(posts);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RedditClone.Models;

namespace RedditClone.Controllers
{
    public class RedditPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RedditPosts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: RedditPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.Posts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // GET: RedditPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RedditPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,UpVotes,DownVotes,DatePosted,Img")] RedditPost redditPost)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(redditPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(redditPost);
        }

        // GET: RedditPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.Posts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // POST: RedditPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,UpVotes,DownVotes,DatePosted,Img")] RedditPost redditPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redditPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(redditPost);
        }

        // GET: RedditPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedditPost redditPost = db.Posts.Find(id);
            if (redditPost == null)
            {
                return HttpNotFound();
            }
            return View(redditPost);
        }

        // POST: RedditPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RedditPost redditPost = db.Posts.Find(id);
            db.Posts.Remove(redditPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

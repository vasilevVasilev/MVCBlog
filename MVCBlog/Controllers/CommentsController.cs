using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBlog.Models;

namespace MVCBlog.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index(int p)
        {
            var commentsWtihAuthors = db.Comments.Include(post => post.Author).ToList();
            var comment = commentsWtihAuthors.FindAll(post => post.Post == p)
                .OrderByDescending(c => c.Date).ToList();
            if (comment.Count == 0)
            {                
                return RedirectToAction("Create", new { p = p });  
            }
            return View(comment);
        }

        // GET: Comments/Details
        public ActionResult Details(int p)
        {
                                   
            
            return View();
        }

        // GET: Comments/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int p, [Bind(Include = "Id,Text,Date")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                comment.Post = p;
                db.Posts.ToList().Find(i => i.Id == p).Comments.Add(comment);
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", new { p = p });
            }

            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date")] Comment comment, int p)
        {
            if (ModelState.IsValid)
            {
                comment.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                db.Entry(comment).State = EntityState.Modified;
                comment.Post = p;
                db.Posts.ToList().Find(i => i.Id == p).Comments.Add(comment);
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", new { p = p });
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id, int p)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int p)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index", new { p = p });
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

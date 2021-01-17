using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;

namespace FivePSocialNetwork.Controllers.ControllerFramword
{
    public class Comment_AnswerController : Controller
    {
        private FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();

        // GET: Comment_Answer
        public ActionResult Index()
        {
            var comment_Answer = db.Comment_Answer.Include(c => c.Answer).Include(c => c.User);
            return View(comment_Answer.ToList());
        }

        // GET: Comment_Answer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Answer comment_Answer = db.Comment_Answer.Find(id);
            if (comment_Answer == null)
            {
                return HttpNotFound();
            }
            return View(comment_Answer);
        }

        // GET: Comment_Answer/Create
        public ActionResult Create()
        {
            ViewBag.answer_id = new SelectList(db.Answers, "answer_id", "answer_content");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass");
            return View();
        }

        // POST: Comment_Answer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "commentAnswer_id,commentAnswer_content,commentAnswer_dateCreate,commentAnswer_dateEdit,user_id,answer_id,commentAnswer_recycleBin,commentAnswer_activate,commentAnswer_userStatus")] Comment_Answer comment_Answer)
        {
            if (ModelState.IsValid)
            {
                db.Comment_Answer.Add(comment_Answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.answer_id = new SelectList(db.Answers, "answer_id", "answer_content", comment_Answer.answer_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass", comment_Answer.user_id);
            return View(comment_Answer);
        }

        // GET: Comment_Answer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Answer comment_Answer = db.Comment_Answer.Find(id);
            if (comment_Answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.answer_id = new SelectList(db.Answers, "answer_id", "answer_content", comment_Answer.answer_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass", comment_Answer.user_id);
            return View(comment_Answer);
        }

        // POST: Comment_Answer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "commentAnswer_id,commentAnswer_content,commentAnswer_dateCreate,commentAnswer_dateEdit,user_id,answer_id,commentAnswer_recycleBin,commentAnswer_activate,commentAnswer_userStatus")] Comment_Answer comment_Answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment_Answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.answer_id = new SelectList(db.Answers, "answer_id", "answer_content", comment_Answer.answer_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "user_pass", comment_Answer.user_id);
            return View(comment_Answer);
        }

        // GET: Comment_Answer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Answer comment_Answer = db.Comment_Answer.Find(id);
            if (comment_Answer == null)
            {
                return HttpNotFound();
            }
            return View(comment_Answer);
        }

        // POST: Comment_Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment_Answer comment_Answer = db.Comment_Answer.Find(id);
            db.Comment_Answer.Remove(comment_Answer);
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

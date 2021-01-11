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
    public class UsersController : Controller
    {
        private FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Commune).Include(u => u.District).Include(u => u.Provincial).Include(u => u.Role_User).Include(u => u.Sex_User);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.commune_id = new SelectList(db.Communes, "commune_id", "commune_name");
            ViewBag.district_id = new SelectList(db.Districts, "district_id", "district_name");
            ViewBag.provincial_id = new SelectList(db.Provincials, "provincial_id", "provincial_name");
            ViewBag.role_id = new SelectList(db.Role_User, "role_id", "role_name");
            ViewBag.sex_id = new SelectList(db.Sex_User, "sex_id", "sex_name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_pass,user_firstName,user_lastName,user_email,user_token,role_id,user_code,user_avatar,user_coverImage,user_activate,user_recycleBin,user_dateCreate,user_dateEdit,user_dateLogin,user_emailAuthentication,user_verifyPhoneNumber,user_loginAuthentication,provincial_id,district_id,commune_id,user_addressRemaining,sex_id,user_linkFacebook,user_linkGithub,user_anotherWeb,user_hobbyWork,user_hobby,user_birthday,user_popular,user_goldMedal,user_silverMedal,user_brozeMedal,user_vipMedal,user_phone")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commune_id = new SelectList(db.Communes, "commune_id", "commune_name", user.commune_id);
            ViewBag.district_id = new SelectList(db.Districts, "district_id", "district_name", user.district_id);
            ViewBag.provincial_id = new SelectList(db.Provincials, "provincial_id", "provincial_name", user.provincial_id);
            ViewBag.role_id = new SelectList(db.Role_User, "role_id", "role_name", user.role_id);
            ViewBag.sex_id = new SelectList(db.Sex_User, "sex_id", "sex_name", user.sex_id);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.commune_id = new SelectList(db.Communes, "commune_id", "commune_name", user.commune_id);
            ViewBag.district_id = new SelectList(db.Districts, "district_id", "district_name", user.district_id);
            ViewBag.provincial_id = new SelectList(db.Provincials, "provincial_id", "provincial_name", user.provincial_id);
            ViewBag.role_id = new SelectList(db.Role_User, "role_id", "role_name", user.role_id);
            ViewBag.sex_id = new SelectList(db.Sex_User, "sex_id", "sex_name", user.sex_id);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_pass,user_firstName,user_lastName,user_email,user_token,role_id,user_code,user_avatar,user_coverImage,user_activate,user_recycleBin,user_dateCreate,user_dateEdit,user_dateLogin,user_emailAuthentication,user_verifyPhoneNumber,user_loginAuthentication,provincial_id,district_id,commune_id,user_addressRemaining,sex_id,user_linkFacebook,user_linkGithub,user_anotherWeb,user_hobbyWork,user_hobby,user_birthday,user_popular,user_goldMedal,user_silverMedal,user_brozeMedal,user_vipMedal,user_phone")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commune_id = new SelectList(db.Communes, "commune_id", "commune_name", user.commune_id);
            ViewBag.district_id = new SelectList(db.Districts, "district_id", "district_name", user.district_id);
            ViewBag.provincial_id = new SelectList(db.Provincials, "provincial_id", "provincial_name", user.provincial_id);
            ViewBag.role_id = new SelectList(db.Role_User, "role_id", "role_name", user.role_id);
            ViewBag.sex_id = new SelectList(db.Sex_User, "sex_id", "sex_name", user.sex_id);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

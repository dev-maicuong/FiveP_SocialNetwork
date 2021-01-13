using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Areas.Admin.Controllers
{
    public class TechnologyAdminController : Controller
    {
        private FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Admin/TechnologyAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult AddTechnology([Bind(Include = "technology_id,technology_name,technology_popular,technology_activate,technology_recycleBin,technology_dateCreate,technology_dateEdit,technology_note,technology_totalQuestion")] Technology technology)
        {
            Technology checkName = db.Technologies.SingleOrDefault(n => n.technology_name == technology.technology_name);
            if(checkName != null)
            {
                return RedirectToAction("Index");
            }
            technology.technology_activate = true;
            technology.technology_recycleBin = false;
            technology.technology_dateCreate = DateTime.Now;
            technology.technology_dateEdit = DateTime.Now;
            technology.technology_totalQuestion = 0;
            db.Technologies.Add(technology);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult TeachnologyJson()
        {
            List<Technology> technologies = db.Technologies.Where(n => n.technology_recycleBin == false).ToList();
            List<TeachnologyAdmin> listUsers = technologies.Select(n => new TeachnologyAdmin
            {
                technology_id = n.technology_id,
                technology_name = n.technology_name,
                technology_note = n.technology_note,
                technology_popular = n.technology_popular,
                technology_activate = n.technology_activate,
                technology_dateCreate = n.technology_dateCreate.ToString(),
                technology_dateEdit = n.technology_dateEdit.ToString(),
                technology_recycleBin = n.technology_recycleBin,
                technology_totalQuestion = n.technology_totalQuestion

            }).ToList();
            return Json(listUsers, JsonRequestBehavior.AllowGet);
        }
    }
}
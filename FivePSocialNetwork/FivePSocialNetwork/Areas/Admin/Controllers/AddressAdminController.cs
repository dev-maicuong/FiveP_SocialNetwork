using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Areas.Admin.Controllers
{
    public class AddressAdminController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Admin/AddressAdmin
        public ActionResult Provincial()
        {
            return View();
        }
        public JsonResult ProvincialJson()
        {
            List<Provincial> provincials = db.Provincials.Where(n => n.provincial_recycleBin == false).ToList();
            List<ProvincialAdmin> provincialAdmins = provincials.Select(n => new ProvincialAdmin
            {
                provincial_id = n.provincial_id,
                provincial_name = n.provincial_name,
                provincial_activate = n.provincial_activate,
                provincial_dateCreate = n.provincial_dateCreate.ToString(),
                provincial_dateEdit = n.provincial_dateEdit.ToString(),
                provincial_recycleBin = n.provincial_recycleBin

            }).ToList();
            return Json(provincialAdmins, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RecycleBinProvincialJson()
        {
            List<Provincial> provincials = db.Provincials.Where(n => n.provincial_recycleBin == true).ToList();
            List<ProvincialAdmin> provincialAdmins = provincials.Select(n => new ProvincialAdmin
            {
                provincial_id = n.provincial_id,
                provincial_name = n.provincial_name,
                provincial_activate = n.provincial_activate,
                provincial_dateCreate = n.provincial_dateCreate.ToString(),
                provincial_dateEdit = n.provincial_dateEdit.ToString(),
                provincial_recycleBin = n.provincial_recycleBin

            }).ToList();
            return Json(provincialAdmins, JsonRequestBehavior.AllowGet);
        }
        //xóa tạm thời tỉnh
        public JsonResult RecycleBinProvincial(int? id)
        {
            Provincial provincial = db.Provincials.Find(id);
            provincial.provincial_recycleBin = !provincial.provincial_recycleBin;
            db.SaveChanges();
            return Json(provincial,JsonRequestBehavior.AllowGet);
        }
        //hoạt động tỉnh
        public JsonResult ActivateProvincail(int? id)
        {
            Provincial provincial = db.Provincials.Find(id);
            provincial.provincial_activate = !provincial.provincial_activate;
            db.SaveChanges();
            return Json(provincial, JsonRequestBehavior.AllowGet);
        }
        // thêm tỉnh
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateProvincail([Bind(Include = "provincial_id,provincial_name,provincial_activate,provincial_dateCreate,provincial_dateEdit,provincial_recycleBin")] Provincial provincial)
        {
            provincial.provincial_activate = true;
            provincial.provincial_dateCreate = DateTime.Now;
            provincial.provincial_dateEdit = DateTime.Now;
            provincial.provincial_recycleBin = false;
            db.Provincials.Add(provincial);
            db.SaveChanges();
            return RedirectToAction("Provincial");
        }
        // sửa tỉnh
        public ActionResult EditProvincial(string provincial_name, int? provincial_id)
        {
            Provincial provincial = db.Provincials.Find(provincial_id);
            provincial.provincial_name = provincial_name;
            db.SaveChanges();
            return RedirectToAction("Provincial");
        }
        public ActionResult District()
        {
            return View();
        }
        public ActionResult Commune()
        {
            return View();
        }
    }
}
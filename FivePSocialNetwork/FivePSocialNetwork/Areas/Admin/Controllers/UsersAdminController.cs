using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models.Json;
using FivePSocialNetwork.Models;

namespace FivePSocialNetwork.Areas.Admin.Controllers
{
    public class UsersAdminController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Admin/UsersAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }
        public JsonResult RoleJson()
        {
            List<Role_User> role_Users = db.Role_User.Where(n => n.role_recycleBin == false).ToList();
            List<RoleAdmin> listUsers = role_Users.Select(n => new RoleAdmin
            {
                role_id = n.role_id,
                role_name = n.role_name,
                role_activate = n.role_activate,
                role_dateCreate = n.role_dateCreate.ToString(),
                role_dateEdit = n.role_dateEdit.ToString(),
                role_recycleBin = n.role_recycleBin

            }).ToList();
            return Json(listUsers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Friend()
        {
            return View();
        }
        public ActionResult Sex()
        {
            return View();
        }
        public JsonResult SexJson()
        {
            List<Sex_User> sex_Users = db.Sex_User.Where(n => n.sex_recycleBin == false).ToList();
            List<SexAdmin> listUsers = sex_Users.Select(n => new SexAdmin
            {
                sex_id = n.sex_id,
                sex_name = n.sex_name,
                sex_activate = n.sex_activate,
                sex_dateCreate = n.sex_dateCreate.ToString(),
                sex_dateEdit = n.sex_dateEdit.ToString(),
                sex_recycleBin = n.sex_recycleBin

            }).ToList();
            return Json(listUsers, JsonRequestBehavior.AllowGet);
        }
    }
}
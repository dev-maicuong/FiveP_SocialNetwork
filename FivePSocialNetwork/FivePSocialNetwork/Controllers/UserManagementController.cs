using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FivePSocialNetwork.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult OverviewUser()
        {
            return View();
        }
        public ActionResult ManagementQuestion()
        {
            return View();
        }
        public ActionResult ManagementFriend()
        {
            return View();
        }
        public ActionResult ManagementTick()
        {
            return View();
        }
        public ActionResult ManagementNotification()
        {
            return View();
        }
        public ActionResult ManagementPost()
        {
            return View();
        }
    }
}
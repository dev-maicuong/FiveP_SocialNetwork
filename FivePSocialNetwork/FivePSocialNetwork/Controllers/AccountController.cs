using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FivePSocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        // Cài đặt thông tin cá nhân
        public ActionResult IndexAccount()
        {
            return View();
        }
        public ActionResult SettingAccount()
        {
            return View();
        }
        public ActionResult TechnologyUser()
        {
            return View();
        }
        public ActionResult Security()
        {
            return View();
        }
        public ActionResult Address()
        {
            return View();
        }
        public ActionResult LinkWebAnother()
        {
            return View();
        }
    }
}
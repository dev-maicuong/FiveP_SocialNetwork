using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FivePSocialNetwork.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        //Tất cả thành viên đang hoạt động trên 5p
        public ActionResult Member()
        {
            return View();
        }
        //Tất cả công nghệ đang hoạt động trên 5P   
        public ActionResult Technology()
        {
            return View();
        }
        public ActionResult Post()
        {
            return View();
        }
    }
}
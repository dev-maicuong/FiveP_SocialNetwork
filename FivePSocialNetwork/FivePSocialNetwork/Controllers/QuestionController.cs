using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FivePSocialNetwork.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        //Giao diện đăng câu hỏi.
        public ActionResult PostQuestion()
        {
            return View();
        }
    }
}
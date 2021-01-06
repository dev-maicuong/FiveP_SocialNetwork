using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FivePSocialNetwork.Controllers
{
    public class ShareViewController : Controller
    {
        // GET: ShareView
        //Menu của trang chủ index
        public PartialViewResult MenuIndex()
        {
            return PartialView();
        }
        //panel trên cùng của indexcenter
        public PartialViewResult PanelCenter()
        {
            return PartialView();
        }
        //menu tùy chọn bên trái của center
        public PartialViewResult MenuCenter()
        {
            return PartialView();
        }
        //Thống kê của center

        public PartialViewResult Select2T()
        {
            return PartialView();
        }
    }
}
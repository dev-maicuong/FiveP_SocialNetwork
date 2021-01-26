using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;


namespace FivePSocialNetwork.Controllers
{
    public class ShareViewController : Controller
    {
        // GET: ShareView
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        //Menu của trang chủ index
        public PartialViewResult MenuIndex()
        {
            return PartialView();
        }
        //panel trên cùng của indexcenter
        public PartialViewResult PanelCenter()
        {
            //Tồn tại cookie 
            if (Request.Cookies["user_id"] != null)
            {
                int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
                List<Notification> notifications = db.Notifications.Where(n => n.notification_status == false && n.notification_recycleBin == false && n.receiver_id == user_id).ToList();
                ViewBag.listNotifications = notifications;
                ViewBag.countNotifications = notifications.Count();
            }
            
            return PartialView();
        }
        //menu tùy chọn bên trái của center
        public PartialViewResult MenuCenter()
        {
            return PartialView();
        }
        //Thống kê của center

        public PartialViewResult SelectMuntiple()
        {
            return PartialView();
        }
    }
}
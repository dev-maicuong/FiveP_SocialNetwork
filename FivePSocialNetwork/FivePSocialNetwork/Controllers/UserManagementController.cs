using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Controllers
{
    public class UserManagementController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
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
        //hiển thị tất cả thông báo trong phần quản lý
        public ActionResult ManagementNotification()
        {
            return View();
        }
        //hiển thị thông báo trên chuông thông báo
        public JsonResult Notifications()
        {
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            List<Notification> notifications = db.Notifications.Where(n => n.notification_status == false && n.notification_recycleBin == false && n.receiver_id == user_id).ToList();
            List<ListNotification> listNotifications = notifications.Select(n => new ListNotification
            {
                notification_id = n.notification_id,
                notification_content = n.notification_content,
                receiver_id = n.receiver_id,
                notification_dateCreate = n.notification_dateCreate.Value.ToShortDateString(),
                impactUser_id = n.impactUser_id,
                question_id = n.question_id,
                notification_status = n.notification_status,
                notification_recycleBin = n.notification_recycleBin,
                impactUser_user_firstName = n.User1.user_firstName,
                impactUser_user_lastName = n.User1.user_lastName,
                impactUser_avatar = n.User.user_avatar,
            }).ToList();
            return Json(listNotifications, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ManagementPost()
        {
            return View();
        }
    }
}
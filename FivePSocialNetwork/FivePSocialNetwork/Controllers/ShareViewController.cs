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
            
            return PartialView();
        }
        //--------------------------đồi trạng thái tin nhắn ---------------------------
        public ActionResult StatusMessage()
        {
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            List<Message> checkMessages = db.Messages.Where(n => n.messageRecipients_id == user_id && n.message_status == false).ToList();
            if(checkMessages != null)
            {
                foreach (var item in checkMessages)
                {
                    db.Messages.Find(item.message_id).message_status = true;
                }
                db.SaveChanges();
            }
            return View();
        }
        //--------------------------đồi trạng thái thông báo ---------------------------
        public ActionResult StatusNotification()
        {
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            List<Notification> checkNotification = db.Notifications.Where(n => n.receiver_id == user_id && n.notification_status == false && n.notification_recycleBin == false).ToList();
            if(checkNotification !=null)
            {
                foreach (var item in checkNotification)
                {
                    db.Notifications.Find(item.notification_id).notification_status = true;
                }
                db.SaveChanges();
            }
            return View();
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
        //----------------share thanh đặt câu hỏi/ đăng bài viết/ công nghệ phổ biến/ các lọc câu hỏi-----------------
        public PartialViewResult DefaultIndexCenter()
        {
            return PartialView();
        }
        //----------------------------------------------share Thanh bạn bè ------------------------------
        public PartialViewResult FriendIndexCenter()
        {
            return PartialView();
        }
        //----------------------------------------------các đề xuất cho trang indexcenter ------------------------------
        public PartialViewResult OfferIndexCenter()
        {
            return PartialView();
        }
    }
}
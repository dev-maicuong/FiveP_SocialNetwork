using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;

namespace FivePSocialNetwork.Controllers
{
    
    public class MessageController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Message
        public ActionResult Index(int? id)
        {
            if(id == null)
            {

                return Redirect("/Center/IndexCenter");
            }

            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Center/IndexCenter");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            Friend friend = db.Friends.SingleOrDefault(n => (n.userRequest_id == id && n.userResponse_id == user_id && n.friend_status == true && n.friend_recycleBin == false) || (n.userRequest_id == user_id && n.userResponse_id == id && n.friend_status == true && n.friend_recycleBin == false));
            if(friend == null)
            {
                return Redirect("/Center/IndexCenter");

            }
            ViewBag.idFriend = friend.friend_id;
            ViewBag.id = id;
            List<Message> messages = db.Messages.Where(n => (n.messageSender_id == id && n.messageRecipients_id == user_id && n.message_recycleBin == false) || (n.messageSender_id == user_id && n.messageRecipients_id == id && n.message_recycleBin == false)).OrderBy(n => n.message_dateSend).Take(10).ToList();
            return View(messages);
        }
    }
}
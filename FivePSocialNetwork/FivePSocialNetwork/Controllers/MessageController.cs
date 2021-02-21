using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

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
        [HttpPost]
        public ActionResult SaveMessage(Message message,string message_content, int messageRecipients_id)
        {
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Center/IndexCenter");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());

            message.messageSender_id = user_id;
            message.messageRecipients_id = messageRecipients_id;
            message.message_content = message_content;
            message.message_dateSend = DateTime.Now;
            message.message_status = false;
            message.message_recycleBin = false;
            db.Messages.Add(message);
            db.SaveChanges();
            return View();
        }
        public ActionResult StatusMessage(Message message, int messageRecipients_id)
        {
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            List<Message> checkMessages = db.Messages.Where(n => n.messageSender_id == messageRecipients_id && n.messageRecipients_id == user_id && n.message_status == false).ToList();
           
            foreach(var item in checkMessages)
            {
                db.Messages.Find(item.message_id).message_status = true;
            }
            db.SaveChanges();
            return View();
        }
        //--------------------------------list user massage---------------------------
        public JsonResult ListUsers()
        {
            //Kiểm tra cookie
            if (Request.Cookies["user_id"] != null)
            {
                int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
                List<Friend> friends = db.Friends.Where(n =>(n.userResponse_id == user_id || n.userRequest_id== user_id) && n.friend_recycleBin == false && n.friend_status == true).ToList();
                List<ListUsers> fiterUsers = new List<ListUsers>();
                foreach(var item in friends)
                {
                    if(item.userRequest_id != user_id)
                    {
                        fiterUsers.Add(new ListUsers
                        {
                            user_statusOnline = item.User.user_statusOnline,
                            user_id = (int)item.userRequest_id ,
                            user_firstName = item.User.user_firstName,
                            user_lastName = item.User.user_lastName,
                            user_vipMedal = item.User.user_vipMedal,
                            user_goldMedal = item.User.user_goldMedal,
                            user_silverMedal = item.User.user_silverMedal,
                            user_brozeMedal = item.User.user_brozeMedal,
                            user_avatar = item.User.user_avatar
                        });
                    }
                    else if(item.userResponse_id != user_id)
                    {
                        fiterUsers.Add(new ListUsers
                        { 
                            user_statusOnline = item.User1.user_statusOnline,
                            user_id = (int)item.userResponse_id,
                            user_firstName = item.User1.user_firstName,
                            user_lastName = item.User1.user_lastName,
                            user_vipMedal = item.User1.user_vipMedal,
                            user_goldMedal = item.User1.user_goldMedal,
                            user_silverMedal = item.User1.user_silverMedal,
                            user_brozeMedal = item.User1.user_brozeMedal,
                            user_avatar = item.User1.user_avatar
                        });
                    }
                }
                List<ListUsers> listUsers = fiterUsers.Select(n => new ListUsers
                {
                    user_id = n.user_id,
                    user_statusOnline = n.user_statusOnline,
                    user_firstName = n.user_firstName,
                    user_lastName = n.user_lastName,
                    user_avatar = n.user_avatar,
                    user_vipMedal = n.user_vipMedal,
                    user_goldMedal = n.user_goldMedal,
                    user_silverMedal = n.user_silverMedal,
                    user_brozeMedal = n.user_brozeMedal,
                    message = db.Messages.OrderByDescending(m=>m.message_dateSend).FirstOrDefault(m=>m.messageSender_id == n.user_id).message_content,
                    message_dateSend = db.Messages.OrderByDescending(m => m.message_dateSend).FirstOrDefault(m => m.messageSender_id == n.user_id).message_dateSend.ToString()
                }).ToList();
                return Json(listUsers, JsonRequestBehavior.AllowGet);
            }

            return Json("Hello bạn !", JsonRequestBehavior.AllowGet);
        }

    }
}
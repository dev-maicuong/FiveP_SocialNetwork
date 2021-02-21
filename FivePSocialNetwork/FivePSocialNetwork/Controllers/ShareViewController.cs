using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

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
        // gợi ý kết bạn
        public JsonResult SuggestiotMakeFriends()
        {
            //giải pháp lấy danh sách công nghệ của user / sau đó lấy danh sách công nghệ của của các user khác / sau đó so sánh và id công nghệ giống thì thêm vào ds và thoát khỏi vòng lặp và so sánh vòng tiếp theo
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            List<ListUsers> listUser = new List<ListUsers>();
            List<Teachnology_User> teachnology_User = db.Teachnology_User.Where(n => n.user_id == user_id && n.technology_recycleBin == false).ToList();
            List<Teachnology_User> teachnology_Users = db.Teachnology_User.Where(n => n.technology_recycleBin == false && n.user_id != user_id).ToList();
            // lấy ds bạn bè
            List<Friend> friends = db.Friends.Where(n => (n.userResponse_id == user_id || n.userRequest_id == user_id) && n.friend_recycleBin == false && n.friend_status == true).ToList();
            List<ListUsers> fiterUsers = new List<ListUsers>();
            foreach (var item in friends)
            {
                if (item.userRequest_id != user_id)
                {
                    fiterUsers.Add(new ListUsers
                    {
                        user_statusOnline = item.User.user_statusOnline,
                        user_id = (int)item.userRequest_id,
                        user_firstName = item.User.user_firstName,
                        user_lastName = item.User.user_lastName,
                        user_vipMedal = item.User.user_vipMedal,
                        user_goldMedal = item.User.user_goldMedal,
                        user_silverMedal = item.User.user_silverMedal,
                        user_brozeMedal = item.User.user_brozeMedal,
                        user_avatar = item.User.user_avatar
                    });
                }
                else if (item.userResponse_id != user_id)
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
            List<ListUsers> listFriend = fiterUsers.Select(n => new ListUsers
            {
                user_id = n.user_id,
                user_statusOnline = n.user_statusOnline,
                user_firstName = n.user_firstName,
                user_lastName = n.user_lastName,
                user_vipMedal = n.user_vipMedal,
                user_goldMedal = n.user_goldMedal,
                user_silverMedal = n.user_silverMedal,
                user_brozeMedal = n.user_brozeMedal,
                user_avatar = n.user_avatar,
            }).ToList();
            // ^
            //lọc các user cùng công nghệ
            foreach (var item in teachnology_User)
            {
                foreach (var item2 in teachnology_Users)
                {
                    if (item.technology_id == item2.technology_id)
                    {
                        listUser.Add(new ListUsers
                        {
                            user_id = (int)item2.user_id,
                            user_statusOnline = item2.User.user_statusOnline,
                            user_firstName = item2.User.user_firstName,
                            user_lastName = item2.User.user_lastName,
                            user_vipMedal = item2.User.user_vipMedal,
                            user_goldMedal = item2.User.user_goldMedal,
                            user_silverMedal = item2.User.user_silverMedal,
                            user_brozeMedal = item2.User.user_brozeMedal,
                            user_avatar = item2.User.user_avatar
                        });
                    }
                }
            }
            List<ListUsers> listUsers = listUser.GroupBy(n => n.user_id).Select(n => n.FirstOrDefault()).ToList();
            //lọc các user ko phải bạn bè
            List<ListUsers> listSuggestiotMakeFriends = new List<ListUsers>();
            int temp = 0;
            foreach (var item in listUsers)
            {
                foreach (var item2 in listFriend)
                {
                    if(item.user_id == item2.user_id)
                    {
                        temp = 0;
                        break;
                    }
                    else
                    {
                        temp = 1;
                    }
                }
                if(temp == 1)
                {
                    listSuggestiotMakeFriends.Add(new ListUsers
                    {
                        user_id = (int)item.user_id,
                        user_statusOnline = item.user_statusOnline,
                        user_firstName = item.user_firstName,
                        user_lastName = item.user_lastName,
                        user_vipMedal = item.user_vipMedal,
                        user_goldMedal = item.user_goldMedal,
                        user_silverMedal = item.user_silverMedal,
                        user_brozeMedal = item.user_brozeMedal,
                        user_avatar = item.user_avatar
                    });
                    temp = 0;
                }
            }
            return Json(listSuggestiotMakeFriends, JsonRequestBehavior.AllowGet);
        }
    }
}
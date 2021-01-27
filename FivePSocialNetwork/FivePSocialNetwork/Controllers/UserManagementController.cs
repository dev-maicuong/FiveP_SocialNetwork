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
        public ActionResult PageUser()
        {
            return View();
        }
        //---------------------------------------------user Quản lý câu hỏi --------------------------------
        public ActionResult ManagementQuestion()
        {
            return View();
        }
        public JsonResult ListQuestions()
        {
            //Kiểm tra cookie
            if (Request.Cookies["user_id"] != null)
            {
                int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
                List<Question> questions = db.Questions.Where(n => n.question_activate == true && n.question_admin_recycleBin == false && n.user_id == user_id).ToList();
                List<ListQuestions> listQuestions = questions.Select(n => new ListQuestions
                {
                    question_id = n.question_id,
                    question_content = n.question_content,
                    question_dateCreate = n.question_dateCreate.Value.ToShortDateString(),
                    question_dateEdit = n.question_dateEdit.Value.ToShortDateString(),
                    user_id = n.user_id,
                    question_title = n.question_title,
                    question_Answer = n.question_Answer,
                    question_view = n.question_view,
                    question_totalComment = n.question_totalComment,
                    question_totalRate = n.question_totalRate,
                    question_medalCalculator = n.question_medalCalculator,
                    question_userStatus = n.question_userStatus,
                    question_popular = n.question_popular,
                    user_avatar = n.User.user_avatar,
                }).ToList();
                return Json(listQuestions, JsonRequestBehavior.AllowGet);
            }

            return Json("Hello bạn !", JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------------user quản lý bạn bè--------------------------------
        public ActionResult ManagementFriend()
        {
            return View();
        }
        public JsonResult ListFriend()
        {
            //Kiểm tra cookie
            if (Request.Cookies["user_id"] != null)
            {
                int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
                List<Friend> friends = db.Friends.Where(n => (n.userResponse_id == user_id || n.userRequest_id == user_id) && n.friend_status == true && n.friend_recycleBin == false).ToList();
                List<ListFriend> listFriends = friends.Select(n => new ListFriend
                {
                    userRequest_id = n.userRequest_id,
                    userResponse_id = n.userResponse_id,
                    friend_dateRequest = n.friend_dateRequest.Value.ToShortDateString(),
                    friend_dateResponse = n.friend_dateResponse.Value.ToShortDateString(),
                    friend_dateUnfriend = n.friend_dateUnfriend.Value.ToShortDateString(),
                    friend_status = n.friend_status,
                    user_firstName = n.User.user_firstName,
                    user_lastName = n.User.user_lastName,
                    user_avatar = n.User.user_avatar,
                    user_popular = n.User.user_popular,
                    user_goldMedal = n.User.user_goldMedal,
                    user_silverMedal = n.User.user_silverMedal,
                    user_brozeMedal = n.User.user_brozeMedal,
                    user_vipMedal = n.User.user_vipMedal,

                }).ToList();
                return Json(listFriends, JsonRequestBehavior.AllowGet);
            }

            return Json("Hello bạn !", JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------------user quản lý các bài viết đã đánh dấu--------------------------------
        public ActionResult ManagementTick()
        {
            return View();
        }
        public JsonResult ListTick()
        {
            //Kiểm tra cookie
            if (Request.Cookies["user_id"] != null)
            {
                int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
                List<Tick_Question> tick_Questions = db.Tick_Question.Where(n => n.tickQuestion_recycleBin == false && n.user_id == user_id).ToList();
                List<ListTick> listTicks = tick_Questions.Select(n => new ListTick
                {
                    tickQuestion_id = n.tickQuestion_id,
                    question_id = n.question_id,
                    tickQuestion_dateCreate = n.tickQuestion_dateCreate.Value.ToShortDateString(),
                    question_content = n.Question.question_content,
                    question_title = n.Question.question_title,


                }).ToList();
                return Json(listTicks, JsonRequestBehavior.AllowGet);
            }
            return Json("Hello bạn !", JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------------user quản lý các thông báo--------------------------------
        //hiển thị tất cả thông báo trong phần quản lý
        public ActionResult ManagementNotification()
        {
            return View();
        }
        //hiển thị thông báo trên chuông thông báo
        public JsonResult ListNotification()
        {
            if (Request.Cookies["user_id"] != null)
            {
                int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
                List<Notification> notifications = db.Notifications.Where(n => n.notification_recycleBin == false && n.receiver_id == user_id).ToList();
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
                    question_title = n.Question.question_title
                }).ToList();
                return Json(listNotifications, JsonRequestBehavior.AllowGet);
            }
            return Json("Hello bạn !", JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------------user quản lý các bài viết--------------------------------
        public ActionResult ManagementPost()
        {
            return View();
        }
        public JsonResult ListPost()
        {
            List<User> users = db.Users.Where(n => n.user_activate == true && n.user_recycleBin == false && n.role_id == 1).ToList();
            List<ListUsers> listUsers = users.Select(n => new ListUsers
            {
                user_id = n.user_id,
                user_firstName = n.user_firstName,
                user_lastName = n.user_lastName,
                user_email = n.user_email,
                user_avatar = n.user_avatar,
                user_goldMedal = n.user_goldMedal,
                user_silverMedal = n.user_silverMedal,
                user_brozeMedal = n.user_brozeMedal,
                user_vipMedal = n.user_vipMedal,
                total_answer = db.Answers.Where(m => m.user_id == n.user_id).ToList().Count(),
                total_Question = db.Questions.Where(m => m.user_id == n.user_id).ToList().Count()
            }).ToList();
            return Json(listUsers, JsonRequestBehavior.AllowGet);
        }
    }
}
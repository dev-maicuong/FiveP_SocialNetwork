using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Controllers
{
    public class FunctionAtDetailQuestionController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: FunctionAtDetailQuestion
        public ActionResult DetailQuestion(int? id,int? notification_id)
        {
            if(notification_id != null)
            {
                db.Notifications.Find(notification_id).notification_status = true;
                db.SaveChanges();
            }
            Question question = db.Questions.SingleOrDefault(n => n.question_id == id && n.question_activate == true && n.question_userStatus == true && n.question_recycleBin == false && n.question_admin_recycleBin == false);
            return View(question);
        }
        //Danh gia1 questions true
        [HttpPost]
        [AllowAnonymous]
        public ActionResult RateQuestionT(Rate_Question rate_Question,int? question_id)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Center/IndexCenter");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            Rate_Question checkRate_Question = db.Rate_Question.Where(n => n.question_id == question_id && n.user_id == user_id).SingleOrDefault();
            if (checkRate_Question == null)
            {
                db.Questions.Find(question_id).question_popular++;
                db.Questions.Find(question_id).question_medalCalculator++;
                db.SaveChanges();
                //tính huy chương đưa vào user
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 4)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 8)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 15)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                }
                else if (postCalulateMedal == 30)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal++;
                }
                //Lưu đánh giá của bài viết
                rate_Question.user_id = user_id;
                rate_Question.rateQuestion_rateStatus = true;
                rate_Question.rateQuestion_dateCreate = DateTime.Now;
                db.Rate_Question.Add(rate_Question);
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (checkRate_Question.rateQuestion_rateStatus == true)
            {
                db.Questions.Find(question_id).question_medalCalculator--;
                db.SaveChanges();
                //tính huy chương đưa vào user
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 3)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 7)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 14)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                }
                else if (postCalulateMedal == 29)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal--;
                }
                //Đánh giá
                db.Questions.Find(question_id).question_popular--;
                db.Rate_Question.Find(checkRate_Question.rateQuestion_id).rateQuestion_rateStatus = null;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());

            }
            else if (checkRate_Question.rateQuestion_rateStatus == null)
            {
                db.Questions.Find(question_id).question_medalCalculator++;
                db.SaveChanges();
                //tính huy chương đưa vào user
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 4)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 8)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 15)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                }
                else if (postCalulateMedal == 30)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                }
                // lưu đánh giá
                db.Questions.Find(question_id).question_popular++;
                db.Rate_Question.Find(checkRate_Question.rateQuestion_id).rateQuestion_rateStatus = true;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());

            }
            else
            {
                db.Questions.Find(question_id).question_medalCalculator += 2;
                db.SaveChanges();
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 4 || postCalulateMedal == 5)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 8 || postCalulateMedal == 9)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 15 || postCalulateMedal == 16)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                }
                else if (postCalulateMedal == 30 || postCalulateMedal == 31)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal++;
                }
                db.Questions.Find(question_id).question_popular += 2;
                db.Rate_Question.Find(checkRate_Question.rateQuestion_id).rateQuestion_rateStatus = true;
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());

            }
        }
        // đánh giá question false
        [HttpPost]
        public ActionResult RateQuestionF(Rate_Question rate_Question, int? question_id)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Center/IndexCenter");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            Rate_Question checkRateQuestion = db.Rate_Question.Where(n => n.question_id == question_id && n.user_id == user_id).SingleOrDefault();
            if (checkRateQuestion == null)
            {
                //tính huy chương user
                db.Questions.Find(question_id).question_medalCalculator--;
                db.SaveChanges();
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 3)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 7)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 14)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                }
                else if (postCalulateMedal == 29)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                }
                //Lưu đánh giá
                db.Questions.Find(question_id).question_popular--;
                rate_Question.user_id = user_id;
                rate_Question.rateQuestion_rateStatus = false;
                rate_Question.rateQuestion_dateCreate = DateTime.Now;
                db.Rate_Question.Add(rate_Question);
                db.SaveChanges();
                return View();
            }
            else if (checkRateQuestion.rateQuestion_rateStatus == false)
            {
                //Tính huy chương cho user
                db.Questions.Find(question_id).question_medalCalculator++;
                db.SaveChanges();
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 4)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 8)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 15)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                }
                else if (postCalulateMedal == 30)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal++;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                }
                //Lưu đánh giá
                db.Questions.Find(question_id).question_popular++;
                db.Rate_Question.Find(checkRateQuestion.rateQuestion_id).rateQuestion_rateStatus = null;
                db.SaveChanges();
                return View();
            }
            else if (checkRateQuestion.rateQuestion_rateStatus == null)
            {
                //Lưu Huy chương user
                db.Questions.Find(question_id).question_medalCalculator--;
                db.SaveChanges();
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 3)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 7)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 14)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                }
                else if (postCalulateMedal == 29)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                }
                //Lưu đánh giá
                db.Questions.Find(question_id).question_popular--;
                db.Rate_Question.Find(checkRateQuestion.rateQuestion_id).rateQuestion_rateStatus = false;
                db.SaveChanges();
                return View();
            }
            else
            {
                //tính huy chương user
                db.Questions.Find(question_id).question_medalCalculator -= 2;
                db.SaveChanges();
                var postCalulateMedal = db.Questions.Find(question_id).question_medalCalculator;
                if (postCalulateMedal == 3 || postCalulateMedal == 2)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal--;
                }
                else if (postCalulateMedal == 7 || postCalulateMedal == 6)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_brozeMedal++;
                }
                else if (postCalulateMedal == 14 || postCalulateMedal == 13)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_silverMedal++;
                }
                else if (postCalulateMedal == 29 || postCalulateMedal == 28)
                {
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_vipMedal--;
                    db.Users.Find(db.Questions.Find(question_id).user_id).user_goldMedal++;
                }
                //Luu đánh giá
                db.Questions.Find(question_id).question_popular -= 2;
                db.Rate_Question.Find(checkRateQuestion.rateQuestion_id).rateQuestion_rateStatus = false;
                db.SaveChanges();
                return View();
            }
        }
        //Đánh giấu bài viết tick post
        [HttpPost]
        public ActionResult TickQuestion(Tick_Question tick_Question, int? question_id)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Center/IndexCenter");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            Tick_Question checkTickQuestion = db.Tick_Question.Where(n => n.question_id == question_id && n.user_id == user_id).FirstOrDefault();
            if (checkTickQuestion == null)
            {
                db.Questions.Find(question_id).question_popular++;
                tick_Question.user_id = user_id;
                tick_Question.tickQuestion_recycleBin = false;
                tick_Question.tickQuestion_dateCreate = DateTime.Now;
                db.Tick_Question.Add(tick_Question);
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Questions.Find(question_id).question_popular--;
                db.Tick_Question.Remove(db.Tick_Question.Find(checkTickQuestion.tickQuestion_id));
                db.SaveChanges();
                return View();
            }
        }
        // show hoạt động cho bài viết
        [HttpPost]
        public ActionResult ShowActivateQuestion(Show_Activate_Question show_Activate_Question, int? question_id)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Center/IndexCenter");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            Show_Activate_Question check = db.Show_Activate_Question.FirstOrDefault(n => n.question_id == question_id && n.user_id == user_id);
            if (check == null)
            {
                db.Questions.Find(question_id).question_popular++;
                show_Activate_Question.user_id = user_id;
                show_Activate_Question.showActivateQ_dateCreate = DateTime.Now;
                db.Show_Activate_Question.Add(show_Activate_Question);
                db.SaveChanges();
                return View();
            }
            else
            {
                db.Questions.Find(question_id).question_popular--;
                db.Show_Activate_Question.Remove(db.Show_Activate_Question.Find(check.showActivateQ_id));
                db.SaveChanges();
                return View();
            }

        }
        //public JsonResult DetailQuestionJson(ListQuestions listQuestions, int? id)
        //{
        //    Question question = db.Questions.Find(id);
        //    listQuestions.question_id = question.question_id;
        //    listQuestions.question_content = question.question_content;
        //    listQuestions.user_id = question.user_id;
        //    listQuestions.question_dateCreate = question.question_dateCreate.Value.ToShortDateString();
        //    listQuestions.question_dateEdit = question.question_dateEdit.Value.ToShortDateString();
        //    listQuestions.user_firstName = question.User.user_firstName;
        //    listQuestions.user_lastName = question.User.user_lastName;
        //    listQuestions.user_popular = question.User.user_popular;
        //    listQuestions.user_silverMedal = question.User.user_silverMedal;
        //    listQuestions.user_goldMedal = question.User.user_goldMedal;
        //    listQuestions.user_brozeMedal = question.User.user_brozeMedal;
        //    listQuestions.user_vipMedal = question.User.user_vipMedal;
        //    listQuestions.question_title = question.question_title;
        //    listQuestions.question_Answer = question.question_Answer;
        //    listQuestions.question_totalComment = question.question_totalComment;
        //    listQuestions.question_view = question.question_view;
        //    listQuestions.question_totalRate = question.question_totalRate;
        //    listQuestions.question_medalCalculator = question.question_medalCalculator;
        //    listQuestions.question_recycleBin = question.question_recycleBin;
        //    listQuestions.question_userStatus = question.question_userStatus;
        //    listQuestions.question_popular = question.question_popular;
        //    listQuestions.question_admin_recycleBin = question.question_admin_recycleBin;
        //    listQuestions.question_keywordSearch = question.question_keywordSearch;
        //    listQuestions.user_avatar = question.User.user_avatar;
        //    return Json(listQuestions, JsonRequestBehavior.AllowGet);
        //}
        // thẻ câu hỏi
        // thẻ tags
        public JsonResult TagsQuestionJson(int? id)
        {
            List<Tags_Question> tags_Questions = db.Tags_Question.Where(n => n.question_id == id).ToList();
            List<ListTags> listTags = tags_Questions.Select(n => new ListTags
            {
                tagsQuestion_id = n.tagsQuestion_id,
                question_id = n.question_id,
                tagsQuestion_name = n.tagsQuestion_name,
                tagsQuestion_dateCreate = n.tagsQuestion_dateCreate.Value.ToShortDateString(),
            }).ToList();
            return Json(listTags, JsonRequestBehavior.AllowGet);
        }
        // thẻ tags
        public JsonResult QuestionRelationship(int? id)
        {
            Teachnology_Question teachnology_Questions = db.Teachnology_Question.FirstOrDefault(n => n.question_id == id);

            List<Question> questions = db.Teachnology_Question.Where(n=>n.technology_id == teachnology_Questions.technology_id).Select(n=>n.Question).ToList();
            List<ListQuestions> listTags = questions.Select(n => new ListQuestions
            {
                question_title = n.question_title,
                question_id = n.question_id,
            }).Take(8).ToList();
            return Json(listTags, JsonRequestBehavior.AllowGet);
        }
    }
}
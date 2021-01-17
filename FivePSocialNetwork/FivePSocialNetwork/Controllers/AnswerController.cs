using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Controllers
{
    public class AnswerController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Answer
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult PostAnswer([Bind(Include = "answer_id,answer_content,answer_dateCreate,answer_dateEdit,user_id,answer_activate,answer_userStatus,question_id,answer_totalRate,answer_medalCalculate,answer_recycleBin,answer_admin_recycleBin")] Answer answer)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Home/Index");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            Answer checkAnswer = db.Answers.FirstOrDefault(n => n.user_id == user_id && n.question_id == answer.question_id);
            if(checkAnswer != null)
            {
                Session["Message"] = "alert('Hello cc');";
                return Redirect(Request.UrlReferrer.ToString());
            }
            answer.answer_dateCreate = DateTime.Now;
            answer.answer_dateEdit = DateTime.Now;
            answer.user_id = user_id;
            answer.answer_activate = true;
            answer.answer_userStatus = true;
            answer.answer_totalRate = 0;
            answer.answer_medalCalculate = 0;
            answer.answer_recycleBin = false;
            answer.answer_admin_recycleBin = false;
            db.Answers.Add(answer);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // danh sách đáp án
        public JsonResult AnswerJson(int? id)
        {
            List<Answer> answers = db.Answers.Where(n => (n.answer_activate == true && n.answer_admin_recycleBin== false)||(n.answer_activate == true && n.answer_userStatus == true && n.answer_recycleBin == false && n.answer_admin_recycleBin == false)).ToList();
            List<ListAnswer> listAnswers = answers.Select(n => new ListAnswer
            {
                answer_id = n.answer_id,
                answer_content = n.answer_content,
                question_id = n.question_id,
                answer_dateCreate = n.answer_dateCreate.Value.ToShortDateString(),
                answer_dateEdit = n.answer_dateEdit.Value.ToShortDateString(),
                user_id = n.user_id,
                answer_activate = n.answer_activate,
                answer_userStatus = n.answer_userStatus,
                answer_medalCalculate = n.answer_medalCalculate,
                answer_recycleBin = n.answer_recycleBin,
                answer_admin_recycleBin = n.answer_admin_recycleBin,
                user_firstName = n.User.user_firstName,
                user_lastName = n.User.user_lastName,
                user_popular = n.User.user_popular,
                user_goldMedal = n.User.user_goldMedal,
                user_silverMedal = n.User.user_silverMedal,
                user_vipMedal = n.User.user_vipMedal,
                user_brozeMedal = n.User.user_brozeMedal,
                user_avatar = n.User.user_avatar

            }).ToList();
            return Json(listAnswers, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateComment([Bind(Include = "commentAnswer_id,commentAnswer_content,commentAnswer_dateCreate,commentAnswer_dateEdit,user_id,answer_id,commentAnswer_recycleBin,commentAnswer_activate,commentAnswer_userStatus")] Comment_Answer comment_Answer, int? question_id)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect("/Home/Index");
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            comment_Answer.commentAnswer_dateCreate = DateTime.Now;
            comment_Answer.commentAnswer_dateEdit = DateTime.Now;
            comment_Answer.user_id = user_id;
            comment_Answer.commentAnswer_recycleBin = false;
            comment_Answer.commentAnswer_activate = true;
            comment_Answer.commentAnswer_userStatus = true;
            // lưu tổng comment câu hỏi
            Question question = db.Questions.Find(question_id);
            question.question_totalComment += 1;

            db.Comment_Answer.Add(comment_Answer);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
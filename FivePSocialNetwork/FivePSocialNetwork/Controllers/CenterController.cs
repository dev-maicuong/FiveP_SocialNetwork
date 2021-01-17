using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Controllers
{
    public class CenterController : Controller
    {
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Center
        public ActionResult IndexCenter()
        {
            return View();
        }
        //ds câu hỏi
        public JsonResult QuestionsJson()
        {
            List<Question> questions = db.Questions.Where(n => (n.question_recycleBin == false && n.question_userStatus == true) || (n.question_activate == true && n.question_admin_recycleBin == false) ).ToList();
            

            List<ListQuestions> listQuestions = questions.Select(n => new ListQuestions
            {
                question_id = n.question_id,
                question_content = n.question_content,
                user_id = n.user_id,
                question_dateCreate = n.question_dateCreate.Value.ToShortDateString(),
                question_dateEdit = n.question_dateEdit.Value.ToShortDateString(),
                user_firstName = n.User.user_firstName,
                user_lastName = n.User.user_lastName,
                user_popular = n.User.user_popular,
                user_silverMedal = n.User.user_silverMedal,
                user_goldMedal = n.User.user_goldMedal,
                user_brozeMedal = n.User.user_brozeMedal,
                user_vipMedal = n.User.user_vipMedal,
                question_title = n.question_title,
                question_Answer = n.question_Answer,
                question_totalComment = n.question_totalComment,
                question_view = n.question_view,
                question_totalRate = n.question_totalRate,
                question_medalCalculator = n.question_medalCalculator,
                question_recycleBin = n.question_recycleBin,
                question_userStatus = n.question_userStatus,
                question_popular = n.question_popular,
                question_admin_recycleBin = n.question_admin_recycleBin,
                question_keywordSearch = n.question_keywordSearch,
                user_avatar = n.User.user_avatar,
            }).ToList();
            return Json(listQuestions, JsonRequestBehavior.AllowGet);
        }
        // danh sách công nghệ
        public JsonResult ListTechnologyQuestion()
        {
            List<Teachnology_Question> teachnology_Questions = db.Teachnology_Question.Where(n => n.teachnologyQuestion_recycleBin == false).ToList();
            List<ListTechnologyQuestion> listTechnologyQuestions = teachnology_Questions.Select(n => new ListTechnologyQuestion
            {
                teachnologyQuestion_id = n.teachnologyQuestion_id,
                technology_id = n.technology_id,
                question_id = n.question_id,
                teachnologyQuestion_recycleBin = n.teachnologyQuestion_recycleBin,
                technology_name = n.Technology.technology_name,
            }).ToList();
            return Json(listTechnologyQuestions, JsonRequestBehavior.AllowGet);
        }
        //thống kê
        public JsonResult Statistical(IndexCemterStatistical indexCemterStatistical)
        {
            List<Question> questions = db.Questions.Where(n => (n.question_recycleBin == false && n.question_userStatus == true) || (n.question_activate == true && n.question_admin_recycleBin == false)).ToList();
            List<Answer> answers = db.Answers.Where(n => (n.answer_recycleBin == false && n.answer_userStatus == true) || (n.answer_activate == true && n.answer_admin_recycleBin == false)).ToList();
            List<Technology> technologies = db.Technologies.Where(n => n.technology_recycleBin == false && n.technology_activate == true).ToList();
            List<Post> posts = db.Posts.Where(n => n.post_activate == true && n.post_userStatus == true && n.post_recycleBin == false && n.post_admin_recycleBin == false).ToList();
            indexCemterStatistical.totalQuestion = questions.Count();
            indexCemterStatistical.totalAnswer = answers.Count();
            indexCemterStatistical.totalTechnology = technologies.Count();
            indexCemterStatistical.totalPost = posts.Count();
            return Json(indexCemterStatistical, JsonRequestBehavior.AllowGet);
        }
    }
}
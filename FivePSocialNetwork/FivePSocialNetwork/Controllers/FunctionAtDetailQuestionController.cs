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
        public ActionResult DetailQuestion(int? id)
        {
            Question question = db.Questions.SingleOrDefault(n => n.question_id == id && n.question_activate == true && n.question_userStatus == true && n.question_recycleBin == false && n.question_admin_recycleBin == false);
            return View(question);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;

namespace FivePSocialNetwork.Controllers
{
    public class QuestionController : Controller
    {
        String HomeCenter = "/Center/IndexCenter";
        FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        // GET: Question
        //Giao diện đăng câu hỏi.
        public ActionResult PostQuestion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult PostQuestion([Bind(Include = "question_id,question_content,question_dateCreate,question_dateEdit,user_id,question_activate,question_title,question_Answer,question_totalComment,question_view,question_totalRate,question_medalCalculator,question_recycleBin,question_userStatus,question_popular,question_admin_recycleBin,question_keywordSearch,question_totalTick")] Question question, string strTagsQuestion, int[] technologyQuestion)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());

            //tách chuỗi thẻ tags
            string[] tagsQuestion = strTagsQuestion.Split(',');

            if (question.question_dateCreate != null)
            {
                //công nghệ
                List<Teachnology_Question> technology_Posts = db.Teachnology_Question.Where(n => n.question_id == question.question_id).ToList();
                if (technology_Posts == null)
                {
                    foreach (var item in technologyQuestion)
                    {
                        Teachnology_Question tp = new Teachnology_Question()
                        {
                            question_id = question.question_id,
                            technology_id = item,
                            
                        };
                        db.Teachnology_Question.Add(tp);
                    }
                }
                else
                {
                    //Xóa
                    int variable = 0;
                    foreach (var item in technology_Posts)
                    {
                        foreach (var item2 in technologyQuestion)
                        {
                            if (item.technology_id == item2)
                            {
                                variable = 1;
                                break;
                            }
                        }
                        if (variable == 0)
                        {
                            db.Teachnology_Question.Remove(db.Teachnology_Question.Find(item.teachnologyQuestion_id));
                            db.SaveChanges();
                        }
                        variable = 0;
                    }

                    //Thêm
                    List<Teachnology_Question> technology_Posts1 = db.Teachnology_Question.Where(n => n.question_id == question.question_id).ToList();
                    variable = 0;
                    foreach (var item in technologyQuestion)
                    {
                        foreach (var item2 in technology_Posts1)
                        {
                            if (item == item2.technology_id)
                            {
                                variable = 1;
                                break;
                            }
                        }
                        if (variable == 0)
                        {
                            Teachnology_Question tp = new Teachnology_Question()
                            {
                                question_id = question.question_id,
                                technology_id = item,
                                teachnologyQuestion_recycleBin = false
                            };
                            db.Teachnology_Question.Add(tp);
                        }
                        variable = 0;
                    }
                }
                //tag 
                List<Tags_Question> tags = db.Tags_Question.Where(n => n.question_id == question.question_id).ToList();
                if (tags == null)
                {
                    foreach (var item in tagsQuestion)
                    {
                        Tags_Question tag = new Tags_Question()
                        {
                            tagsQuestion_name = item,
                            question_id = question.question_id,
                            tagsQuestion_dateCreate = DateTime.Now
                        };
                        db.Tags_Question.Add(tag);
                    }
                }
                else
                {
                    //Xóa
                    int variable = 0;
                    foreach (var item in tags)
                    {
                        foreach (var item2 in tagsQuestion)
                        {
                            if (item.tagsQuestion_name == item2)
                            {
                                variable = 1;
                                break;
                            }
                        }
                        if (variable == 0)
                        {
                            db.Tags_Question.Remove(db.Tags_Question.Find(item.tagsQuestion_id));
                            db.SaveChanges();
                        }
                        variable = 0;
                    }

                    //Thêm
                    List<Tags_Question> tags1 = db.Tags_Question.Where(n => n.question_id == question.question_id).ToList();
                    variable = 0;
                    foreach (var item in tagsQuestion)
                    {
                        foreach (var item2 in tags1)
                        {
                            if (item == item2.tagsQuestion_name)
                            {
                                variable = 1;
                                break;
                            }
                        }
                        if (variable == 0)
                        {
                            Tags_Question tag = new Tags_Question()
                            {
                                tagsQuestion_name = item,
                                question_id = question.question_id,
                                tagsQuestion_dateCreate = DateTime.Now
                            };
                            db.Tags_Question.Add(tag);
                        }
                        variable = 0;
                    }
                }
                question.question_dateCreate = DateTime.Now;
                question.question_dateEdit = DateTime.Now;
                question.user_id = user_id;
                question.question_totalTick = 0;
                question.question_activate = true;
                question.question_Answer = 0;
                question.question_totalComment = 0;
                question.question_view = 0;
                question.question_totalRate = 0;
                question.question_medalCalculator = 0;
                question.question_recycleBin = false;
                question.question_userStatus = true;
                question.question_popular = 0;
                question.question_admin_recycleBin = true;
                //lưu từ khóa tìm kiếm đang còn...
                question.question_keywordSearch = question.question_content + question.question_title;

                db.Questions.Add(question);
                db.SaveChanges();
                return View(question);
            }
            else if (question.question_dateCreate == null)
            {
                //lưu tỉm kiếm
                question.question_keywordSearch = question.question_content + question.question_title;
                foreach (var item in technologyQuestion)
                {
                    // lưu tên công nghệ
                    question.question_keywordSearch = question.question_keywordSearch + db.Technologies.Find(item).technology_name;
                    //lưu công nghệ câu hỏi
                    Teachnology_Question tp = new Teachnology_Question()
                    {
                        question_id = question.question_id,
                        technology_id = item,
                        teachnologyQuestion_recycleBin = false
                        
                    };
                    db.Teachnology_Question.Add(tp);
                }
                foreach (var item in tagsQuestion)
                {
                    // lưu từ khóa tìm kiếm vào bảng tìm kiếm
                    question.question_keywordSearch = question.question_keywordSearch + item;
                    // lưu thẻ tags
                    Tags_Question tag = new Tags_Question()
                    {
                        tagsQuestion_name = item,
                        question_id = question.question_id,
                        tagsQuestion_dateCreate = DateTime.Now
                    };
                    db.Tags_Question.Add(tag);
                }
                question.question_dateCreate = DateTime.Now;
                question.question_dateEdit = DateTime.Now;
                question.user_id = user_id;
                question.question_activate = true;
                question.question_totalTick = 0;
                question.question_Answer = 0;
                question.question_totalComment = 0;
                question.question_view = 0;
                question.question_totalRate = 0;
                question.question_medalCalculator = 0;
                question.question_recycleBin = false;
                question.question_userStatus = true;
                question.question_popular = 0;
                question.question_admin_recycleBin = false;
                db.Questions.Add(question);
                db.SaveChanges();
                return View(question);
            }
            else
            {
                Response.StatusCode = 404;
                return null;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;
using FivePSocialNetwork.Models.Json;

namespace FivePSocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        private FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();
        String HomeCenter = "/Center/IndexCenter";
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(FormCollection form)
        {
            String user_email = form["user_email"].ToString();
            String user_pass = form["user_pass"].ToString();
            //Mã hóa mật khẩu
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(user_pass));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            user_pass = strBuilder.ToString();
            //kiểm tra tài khoản có đang bị khóa không.
            User userActivate = db.Users.Where(n => n.user_activate == false).SingleOrDefault(n => n.user_email == user_email && n.user_pass == user_pass);
            if(userActivate != null)
            {
                ViewBag.checkLogin = "Tài khoản của bạn đã bị khóa, do vi phạm các điều lệ trong 5p!";
                return View(userActivate);
            }
            //kiểm tra admin
            User admin = db.Users.Where(n => n.user_recycleBin == false && n.role_id == 3).SingleOrDefault(n => n.user_email == user_email && n.user_pass == user_pass);
            if (admin != null)
            {
                admin.user_dateLogin = DateTime.Now;
                db.SaveChanges();
                HttpCookie cookie = new HttpCookie("admin_id", admin.user_id.ToString());
                cookie.Expires.AddDays(10);
                Response.Cookies.Set(cookie);
                return Redirect("/Admin/HomeAdmin/IndexAdmin");
            }
            //kiểm tra trong data người dùng bth và nhà văn
            User user = db.Users.Where(n => n.user_recycleBin == false).SingleOrDefault(n => n.user_email == user_email && n.user_pass == user_pass);
            if(user != null)
            {
                user.user_dateLogin = DateTime.Now;
                db.SaveChanges();
                HttpCookie cookie = new HttpCookie("user_id", user.user_id.ToString());
                cookie.Expires.AddDays(10);
                Response.Cookies.Set(cookie);
                return Redirect(HomeCenter);
            }
            
            ViewBag.checkLogin = "Email hoặc mật khẩu sai! Vui lòng nhập lại!";
            return View(user);
        }
        //Đăng ký
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register([Bind(Include = "user_id,user_pass,user_firstName,user_lastName,user_email,user_token,role_id,user_code,user_avatar,user_coverImage,user_activate,user_recycleBin,user_dateCreate,user_dateEdit,user_dateLogin,user_emailAuthentication,user_verifyPhoneNumber,user_loginAuthentication,provincial_id,district_id,commune_id,user_addressRemaining,sex_id,user_linkFacebook,user_linkGithub,user_anotherWeb,user_hobbyWork,user_hobby,user_birthday,user_popular,user_goldMedal,user_silverMedal,user_brozeMedal,user_vipMedal,user_phone")] User user)
        {
            //kiểm tra email đã được đăng ký chưa
            User checkEmail = db.Users.SingleOrDefault(n => n.user_email == user.user_email);
            if(checkEmail != null)
            {
                ViewBag.checkEmail = "Email đã được sử dụng, vui lòng nhập email mới!";
                return View(user);
            }
            //random ký tự
            Random random = new Random();
            string s1 = RandomString(9, false);
            user.user_code = "#" + s1 +"-"+ random.Next(100, 999).ToString();
            //Mã hóa mật khẩu
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(user.user_pass));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            // lưu mật khẩu đã mã hóa
            user.user_pass = strBuilder.ToString();
            //lưu các thông tin còn lại
            user.user_token = Guid.NewGuid().ToString();
            user.role_id = 1;
            user.user_coverImage = "coverImage.png";
            user.user_avatar = "user.png";
            user.user_activate = true;
            user.user_recycleBin = false;
            user.user_dateCreate = DateTime.Now;
            user.user_dateEdit = DateTime.Now;
            user.user_dateLogin = DateTime.Now;
            user.user_emailAuthentication = false;
            user.user_loginAuthentication = false;
            user.user_verifyPhoneNumber = false;
            user.user_popular = 0;
            user.user_vipMedal = 0;
            user.user_silverMedal = 0;
            user.user_goldMedal = 0;
            user.user_brozeMedal = 0;
            db.Users.Add(user);
            db.SaveChanges();
            User sUser = db.Users.SingleOrDefault(n => n.user_email == user.user_email);
            HttpCookie httpCookie = new HttpCookie("user_id", sUser.user_id.ToString());
            httpCookie.Expires.AddDays(10);
            Response.Cookies.Set(httpCookie);
            return Redirect(HomeCenter);
        }

        //random chuỗi ngẫu nhiên
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();

        }
        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("user_id");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return Redirect(HomeCenter);
        }
        // Cài đặt thông tin cá nhân
        public ActionResult IndexAccount()
        {
            return View();
        }
        public ActionResult SettingAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SettingAccount(User user, string user_firstName , string user_lastName)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);
            user.user_firstName = user_firstName;
            user.user_lastName = user_lastName;
            db.SaveChanges();
            return View(user);
        }
        //lưu giới tính user
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SexUser(User user, int user_sex)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // user_sex == null trả về trang đó.
            if(user_sex == 0)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);
            //lưu giới tính
            user.sex_id = user_sex;
            // lưu hình
            if(user_sex == 1 && user.user_avatar == null)
            {
                user.user_avatar = "Man.png";
            }
            else if(user_sex == 2 && user.user_avatar == null)
            {
                user.user_avatar = "Girl.png";
            }
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        //lưu ngày sinh
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult BrithDay(User user , DateTime user_birthday)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);

            user.user_birthday = user_birthday;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        //luu sở thích công việc
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult HobbyWork(User user, string user_hobbyWork)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);

            user.user_hobbyWork = user_hobbyWork;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        //luu sở thích cá nhân
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Hobby(User user, string user_hobby)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);

            user.user_hobby = user_hobby;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // lưu công nghệ user
        public ActionResult TechnologyUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult TechnologyUser(int[] technology_id)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());

            List<Teachnology_User> steachnology_User = db.Teachnology_User.Where(n => n.user_id == user_id).ToList();
            if(steachnology_User == null)
            {
                foreach (var item in technology_id)
                {
                    Teachnology_User teachnology_User = new Teachnology_User()
                    {
                        user_id = user_id,
                        technology_id = item,
                        technology_dateCreate = DateTime.Now,
                        technology_recycleBin = false
                    };
                    db.Teachnology_User.Add(teachnology_User);
                }
            }
            else
            {
                int variable = 0;
                foreach (var item in steachnology_User)
                {
                    foreach (var item2 in technology_id)
                    {
                        if (item.technology_id == item2)
                        {
                            variable = 1;
                            break;
                        }
                    }
                    if (variable == 0)
                    {
                        db.Teachnology_User.Remove(db.Teachnology_User.Find(item.technologyUser_id));
                    }
                    variable = 0;
                }
                List<Teachnology_User> Teachnology_User2 = db.Teachnology_User.Where(n => n.user_id == user_id).ToList();
                variable = 0;
                foreach (var item in technology_id)
                {
                    foreach (var item2 in Teachnology_User2)
                    {
                        if (item == item2.technology_id)
                        {
                            variable = 1;
                            break;
                        }
                    }
                    if (variable == 0)
                    {
                        Teachnology_User tag = new Teachnology_User()
                        {
                            technology_dateCreate = DateTime.Now,
                            technology_recycleBin = false,
                            technology_id = item,
                            user_id = user_id,
                        };
                        db.Teachnology_User.Add(tag);
                    }
                    variable = 0;
                }
            }
            db.SaveChanges();
            return View(user_id);
        }
        public ActionResult Security()
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            return View();
        }
        // đăng nhập 2 lớp
        public ActionResult ChangeLoginAuthentication()
        {
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            User user = db.Users.Find(user_id);
            user.user_loginAuthentication = !user.user_loginAuthentication;
            db.SaveChanges();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Email(User user, string user_email)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            db.Users.Find(user_id).user_email = user_email;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Numberphone(User user, string user_phone)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            db.Users.Find(user_id).user_phone = user_phone;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Address()
        {
            return View();
        }
        //danh sách tỉnh
        public JsonResult ListProvincial()
        {
            List<Provincial> provincial = db.Provincials.Where(n => n.provincial_activate == true && n.provincial_recycleBin == false).ToList();
            List<ListProvincial> listProvincials = provincial.Select(n => new ListProvincial
            {
                provincial_id = n.provincial_id,
                provincial_name = n.provincial_name
            }).ToList();
            return Json(listProvincials,JsonRequestBehavior.AllowGet);
        }
        //danh sách huyện theo tỉnh đã chọn
        public JsonResult ListDistrict(int? id)
        {
            List<District> districts = db.Districts.Where(n => n.district_activate == true && n.district_recycleBin == false && n.provincial_id == id).ToList();
            List<ListDistrict> ListDistrict = districts.Select(n => new ListDistrict
            {
                district_id = n.district_id,
                district_name = n.district_name
            }).ToList();
            return Json(ListDistrict, JsonRequestBehavior.AllowGet);
        }
        //linkweb khác
        public ActionResult LinkWebAnother()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult LinkWebAnother(User user, string linkWebAnother)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);
            user.user_anotherWeb = linkWebAnother;
            db.SaveChanges();
            return View(user);
        }
        // lưu kink facebook
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult LinkFacebook(User user, string linkFacebook)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);
            user.user_linkFacebook = linkFacebook;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        //luu link github
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult LinkGithub(User user, string linkGithub)
        {
            //nếu ko có cookies cho về trang tất cả câu hỏi.
            if (Request.Cookies["user_id"] == null)
            {
                return Redirect(HomeCenter);
            }
            // khi tồn tại cookies
            int user_id = int.Parse(Request.Cookies["user_id"].Value.ToString());
            user = db.Users.Find(user_id);
            user.user_linkGithub = linkGithub;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperHub.Models;
using System.Web.Security;
using System.Web.ApplicationServices;
using WebMatrix.WebData;
using DeveloperHub.Models.User;
using EntityMapping;
using DeveloperHub.Repositry;
namespace DeveloperHub.Controllers
{
    #region
    public class AccountController : Controller
    {
        private IAccountData iAccountData;
        public AccountController()
        {
             iAccountData = new AccountData();
        }
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
           
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            //SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
           

            Response.Redirect("~/Account/Login");
            return View();
        }
        //
        // GET: /Account/
        [HttpPost]
        public JsonResult FaceBookLogin(FaceBookAccessToken fb)
        {
            Session["uid"] = fb.uid;
            Session["accesstoken"] = fb.uid;

            return Json(new { success = true });
           
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Register register, string actionType)
        {
            if (actionType == "Save")
            {
                if (ModelState.IsValid)
                {
                    if (!WebSecurity.UserExists(register.username))
                    {
                        WebSecurity.CreateUserAndAccount(register.username,register.password,
                            new { FullName = register.FullName, Email = register.EmailID, AddedDate = DateTime.Now, ModifiedDate=DateTime.Now});
                        return View("Login");

                    }

                }
            }

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
         iAccountData.GetAllRegisterUsers();
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool validUser = WebSecurity.Login(login.UserName, login.Password);
                int userId = iAccountData.GetUserIdByUserName(login.UserName);
                string[] userRole = Roles.GetRolesForUser(login.UserName);
                string userInRole="";
                foreach (string getAdminRoles in userRole)
                {
                    if (getAdminRoles.Equals("Admin"))
                    {
                        userInRole = getAdminRoles;
                    }

                }
                if(string.IsNullOrEmpty(userInRole))
                {
                    ModelState.AddModelError("Error", "Rights to User are not Provide Contact to Admin");
                   
                        return View("Login");                    

                }
                else
                {
                    Session["Name"]=login.UserName;
                    Session["UserId"]=userId;
                    Session["LoginType"] = userInRole;
                    FormsAuthentication.SetAuthCookie(login.UserName, false);
                    if(userInRole.Equals("Admin"))
                    {
                        return RedirectToAction("AdminDashboard", "Dashboard");
                    }
                    else
                    {
                         return RedirectToAction("UserDashboard", "Dashboard");
                    }
                }


            }

            return View();
        }
       

            [HttpGet]
        [AllowAnonymous]
        public ActionResult CheckUserNameExists(string username)
        {
            try
            {
                
                
                bool userExist = false;
                IUserInfo userInfo = new UserInfo();
                userExist = userInfo.CheckUserExist(username);
                if (userExist)
                {
                    return Json(!userExist, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
            }
            return View();
        }
        public ActionResult GelAllRegisterUser()
            {
                return View("AllRegisterUserDetails", iAccountData.GetAllRegisterUsers());
            }

        public JsonResult GetUserProfileJson()
        {
            string userName = Session["Name"].ToString();
            int id =Convert.ToInt16(Session["UserId"]);
            UserProfileMapper userProfile = iAccountData.GetUserProfiles(userName,id);

            return Json(userProfile,JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmpList()
        {
            var allUsersList = iAccountData.GetAllRegisterUsers();
            return Json(allUsersList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUserProfile()
        {
            return View("UserProfile");
        }
        public ActionResult EmpListT()
        {
            return View("EmpList");
        }
    }

    #endregion
}

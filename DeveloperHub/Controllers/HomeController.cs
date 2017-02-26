﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperHub.DataBaseIntiliazer;

namespace DeveloperHub.Controllers
{
    //Comment Intialize
   // [InitializeSimpleMembershipAttribute]
    public class HomeController : Controller
    {
        //
        // GET: /Home/Command
        
        public ActionResult HomePage()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //Hello this just test
            return View();
        }
        public ActionResult LoginLayOut()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            return View("~/Views/Home/LoginLayOut.cshtml");
        }
        public ActionResult Test()
        {
            return View();
                
        }
    }
}

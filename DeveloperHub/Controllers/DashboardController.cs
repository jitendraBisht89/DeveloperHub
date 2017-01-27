using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GYMONE.Controllers
{
    
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        
        [Authorize(Roles = "Admin")]
        public ActionResult AdminDashboard()
        {
            return View();
        }

        
        [Authorize(Roles = "SystemUser")]
        public ActionResult UserDashboard()
        {
            return View();
        }

    }
}

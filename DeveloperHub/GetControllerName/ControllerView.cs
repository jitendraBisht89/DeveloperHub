using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperHub.GetControllerName
{
    public static class ControllerView
    {

        public static string GetViewName(string actionName, string controllerName)
        {
            return "~/Views/"+controllerName+"/"+actionName;
        }
    }
}
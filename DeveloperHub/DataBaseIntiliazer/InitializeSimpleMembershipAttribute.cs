﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using WebMatrix.WebData;
using WebMatrix.Data;
using EntityMapping;
using System.Data.Entity.Infrastructure;
namespace DeveloperHub.DataBaseIntiliazer
{
 [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
{
    private static SimpleMembershipInitializer _initializer;
    private static object _initializerLock = new object();
    private static bool _isInitialized;
        
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       
        // Ensure ASP.NET Simple Membership is initialized only once per app start
        LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
    }

    private class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {

            System.Data.Entity.Database.SetInitializer<UserDbContext>(null);

            try
            {
                using (var context = new UserDbContext())
                {
                    
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }

                WebSecurity.InitializeDatabaseConnection("Db", "Users", "Id", "UserName", autoCreateTables: true);
                int k = WebSecurity.GetUserId("jeet");

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
   
}

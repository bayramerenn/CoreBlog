using CoreBlog.DataAccess.Context;
using CoreBlog.DataAccess.Extensions;
using CoreBlog.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CoreBlog.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //var db = new CoreContext();

            //var data = await db.Blogs.AsNoTracking()
            //      .Where(a => a.BlogStatus == true)
            //      .ToListWithNoLockAsync();


            //using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            //{
            //    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            //}))
            //{
            //    using (var db = new CoreContext())
            //    {
            //        var data =  db.Blogs
            //                 .Where(a => a.BlogStatus == true)
            //                 .ToList();
            //        scope.Complete();
            //    }
            //}

            //return View(data);

            return View();
        }


    }
}

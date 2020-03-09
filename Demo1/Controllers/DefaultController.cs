using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo1.Controllers
{
    public class DefaultController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登入
        /// </summary>
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
    }
}
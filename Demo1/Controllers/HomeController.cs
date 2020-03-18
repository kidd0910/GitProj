using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Services.HomeService;

namespace Demo1.Controllers
{
    public class HomeController : BaseController
    {
        private HomeService srv;    

        public HomeController()
        {
            srv = new HomeService(base._baseInit);
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Menu Bar
        /// </summary>
        [HttpPost]        
        public ActionResult Menu()
        {
            ViewBag.Message = "Menu";

            //srv.GetMenu();

            return View();
        }

        /// <summary>
        /// 公佈欄
        /// </summary>
        [HttpPost]
        public ActionResult Bullitin()
        {
            ViewBag.Message = "Bulltin";
            
            return View();
        }
    }
}
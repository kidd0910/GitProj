using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models.Default;
using Acer.Util;

namespace Demo1.Controllers
{
    public class DefaultController : BaseController
    {
        private DefaultService srv;

        public DefaultController()
        {
            srv = new DefaultService(base._baseInit);
        }

       
        public ActionResult Index()
        {
            //PageModel model = new PageModel();
            //try
            //{
            //    model.formColumns = ModelUtil.GetModelKeys<QueryModel>(new QueryModel());
            //}
            //finally 
            //{ 
            //}
            //return Json(model);
            return View();
        }

        [HttpPost]
        public ActionResult Init()
        {
            PageModel model = new PageModel();
            try
            {
                model.formColumns = ModelUtil.GetModelKeys<QueryModel>(new QueryModel());
            }
            finally
            {
            }
            return Json(model);
        }

        /// <summary>
        /// 登入
        /// </summary>
        [HttpPost]
        public ActionResult Login(PageModel model)
        {
            try
            {
                model.formColumns = ModelUtil.GetModelKeys<QueryModel>(new QueryModel());
                model = srv.Login(model);
            }
            finally
            {
            }
            //return View();
            return Json(model);
        }
    }
}
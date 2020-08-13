using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models.Default;
using Acer.Util;
using Demo1.Model.Util;

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

        //[HttpPost]
        public ActionResult Init()
        {
            PageModel model = new PageModel();
            try
            {
                model.formColumns = ModelUtil.GetModelKeys<QueryModel>(new QueryModel() { 
                    ID="",
                    PW="",
                    MESSAGE = "",
                    ERROR_MESSAGE = ""
                });
                model.ID = "";
                model.PW = "";
                model.MESSAGE = "";
                model.ERROR_MESSAGE = "";               
            }
            finally
            {
            }
            //return View();
            return JsonUtil.ToJsonResult(model);
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
            //return Json(model);
            return JsonUtil.ToJsonResult(model);
        }

        /// <summary>
        /// Init
        /// 初始化參數
        /// 包括：env.conf
        /// </summary>
        //[HttpPost]
        public ActionResult DoInit()
        {
            try
            {
                srv.doInit();
            }
            finally
            {
            }

            return View();
        }
    }
}
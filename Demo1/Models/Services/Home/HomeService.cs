using Acer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sys.Business;
using System.Data;
using System.Reflection;
using Acer.Log;
using Acer.Util;
using Demo1.Models.Services;
using Demo1.Models.Base;

namespace Demo1.Services.HomeService
{
    public class HomeService : BaseService
    {
        public HomeService(IBaseInit _IBaseInit) : base(_IBaseInit)
        {

        }

        public void GetMenu()
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);

                WriteLog("testtesttesttesttesttesttesttesttest");

                //CtSysOperation ctrl = new CtSysOperation(DBManager, LogUtil); 
                //ctrl.SYS_KEY = "ORG_TYPE3";
                //ctrl.SYS_TYPE = "1";
                //ctrl.USE_STATE = "1";
                //ctrl.OrderBys = "SYS_ID";
                //DataTable dt =  ctrl.Get系統下拉資料();
            }
            finally
            {
                WriteLogMehtodEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

    }
}
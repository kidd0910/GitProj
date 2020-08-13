using Demo1.Models.Base;
using Demo1.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Demo1.Models.Default
{
    public class DefaultService : BaseService
    {
        public DefaultService(IBaseInit _IBaseInit) : base(_IBaseInit)
        {

        }

        public PageModel Login(PageModel model) 
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);
                
                string errmsg = "";
                model.ERROR_MESSAGE = errmsg;
                WriteLog("ID = " + model.ID);
                WriteLog("PW = " + model.PW);
                WriteLog("  ***  Do Login *** ");

                return model;

            }
            finally
            {
                WriteLogMehtodEnd(MethodBase.GetCurrentMethod().Name);
            }
        }


        public void doInit()
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);
                
                Init();
            }
            finally
            {
                WriteLogMehtodEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Init()
        {
            //Init APConfig
            Acer.Apps.APConfig.Init();
      
        }

    }
}
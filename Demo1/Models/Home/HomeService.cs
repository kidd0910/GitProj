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
using Demo1.Models.Home;
using Acer.Apps;

namespace Demo1.Services.HomeService
{
    public class HomeService : BaseService
    {
        public HomeService(IBaseInit _IBaseInit) : base(_IBaseInit)
        {

        }

        public List<MenuModel> GetMenu()
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);

                List<MenuModel> menuList = new List<MenuModel>();

                if (APConfig.GetProperty("TEST_CONF") == "Y")
                {
                    this.LogUtil.Logger.Append("env.conf TEST Success");
                }
                else {
                    this.LogUtil.Logger.Append("env.conf TEST Error");
                }


               if (APConfig.GetProperty("NO_DB") == "Y")
                {
                    this.LogUtil.Logger.Append("產生 測試Menu");
                     menuList = GetMenuList_TEST();                    
                }
                else {
                    this.LogUtil.Logger.Append("產生 DB Menu");
                    DataTable dt = GetMenuList();
                }

                return menuList;
            }
            finally
            {
                WriteLogMehtodEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        private List<MenuModel> GetMenuList_TEST()
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);

                List<MenuModel> menuList = new List<MenuModel>();
                MenuModel nodeOfMenu_01 = new MenuModel();
                nodeOfMenu_01.Text = "首頁";
                menuList.Add(nodeOfMenu_01);

                MenuModel nodeOfMenu_02 = new MenuModel();
                nodeOfMenu_02.Text = "單檔維護";
                menuList.Add(nodeOfMenu_02);

                return menuList;
            }
            finally
            {
                WriteLogMehtodEnd(MethodBase.GetCurrentMethod().Name);
            }
        }

        private DataTable GetMenuList() 
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);

                CtSysOperation ctrl = new CtSysOperation(DBManager, LogUtil);
                ctrl.SYS_KEY = "ORG_TYPE3";
                ctrl.SYS_TYPE = "1";
                ctrl.USE_STATE = "1";
                ctrl.OrderBys = "SYS_ID";
                DataTable dt = ctrl.Get系統下拉資料();

                WriteLog("dt.Rows.Count = " + dt.Rows.Count.ToString());

                return dt;

            }
            finally
            {
                WriteLogMehtodEnd(MethodBase.GetCurrentMethod().Name);
            }
        }


    }
}
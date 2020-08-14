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

        /// <summary>
        /// 產生測試Munu
        /// </summary>
        private List<MenuModel> GetMenuList_TEST()
        {
            try
            {
                WriteLogMehtodStart(MethodBase.GetCurrentMethod().Name);

                List<MenuModel> menuList = new List<MenuModel>();
                MenuModel mainMenu = new MenuModel();
                //mainMenu.LEVEL = "0";
                //mainMenu.TEXT = "首頁";
                //menuList.Add(mainMenu);

                List<MenuModel> childList = new List<MenuModel>();
                MenuModel childMenu = new MenuModel();

                mainMenu = new MenuModel();
                mainMenu.LEVEL = "0";
                mainMenu.TEXT = "基本功能";
                childList = new List<MenuModel>();
                childMenu = new MenuModel();
                childMenu.LEVEL = "1";
                childMenu.TEXT = "單檔維護";
                childList.Add(childMenu);
                childMenu = new MenuModel();
                childMenu.LEVEL = "1";
                childMenu.TEXT = "頁籤";
                childList.Add(childMenu);
                mainMenu.CHILD = childList;
                menuList.Add(mainMenu);

                mainMenu = new MenuModel();
                mainMenu.LEVEL = "0";
                mainMenu.TEXT = "Vue功能";
                childList = new List<MenuModel>();
                childMenu = new MenuModel();
                childMenu.LEVEL = "1";
                childMenu.TEXT = "...";
                childList.Add(childMenu);
                mainMenu.CHILD = childList;
                menuList.Add(mainMenu);

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
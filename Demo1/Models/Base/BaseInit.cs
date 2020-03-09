using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acer.Base;
using Acer.Log;

namespace Demo1.Models.Base
{
    public class BaseInit : IBaseInit
    {
        private LogUtil logUtil { get; set; }

        private PageBase pageUtil { get; set; }

        public BaseInit()
        {
            logUtil = new LogUtil("");          
        }
       
        public LogUtil GetLogUtil()
        {
            return logUtil;            
        }

        public PageBase GetPageUtil()
        {          
            return pageUtil;
        }
    }
   
}
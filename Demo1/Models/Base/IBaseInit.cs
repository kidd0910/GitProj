using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acer.Base;
using Acer.Log;

namespace Demo1.Models.Base
{
    public interface IBaseInit
    {

        LogUtil GetLogUtil();

        PageBase GetPageUtil();


        //T GetDbContext<T>() where T : BaseDbContext, new();

        //void Commit();

        //void Rollback();

        //void Close();

        //void Dispose();

    }   
}
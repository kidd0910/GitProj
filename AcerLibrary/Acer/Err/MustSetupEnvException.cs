using Acer.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
    /// <summary>
    /// 必須設定參數的自訂錯誤物件
    /// </summary>
    public class MustSetupEnvException : Exception
    {       
        public MustSetupEnvException()
            : base()
        {
        }

        public MustSetupEnvException(string message)
            : base(message)
        {           
        }
    }
}

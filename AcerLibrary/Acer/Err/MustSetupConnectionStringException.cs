using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
    /// <summary>
    /// 必須設定連線字串資訊的自訂錯誤物件
    /// </summary>
    class MustSetupConnectionStringException : Exception
    {
        public MustSetupConnectionStringException()
            : base()
        {
        }

        public MustSetupConnectionStringException(string message)
            : base(message)
        {
        }
    }
}

using Acer.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
    /// <summary>
    /// �����]�w�Ѽƪ��ۭq���~����
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

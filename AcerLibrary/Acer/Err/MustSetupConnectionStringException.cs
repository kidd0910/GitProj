using System;
using System.Collections.Generic;
using System.Text;

namespace Acer.Err
{
    /// <summary>
    /// �����]�w�s�u�r���T���ۭq���~����
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

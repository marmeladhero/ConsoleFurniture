using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWallDefender
{
    class MyException : Exception
    {
        public MyException()
       : base() { }

        public MyException(string message)
            : base(message)
        {
        }
    }
}

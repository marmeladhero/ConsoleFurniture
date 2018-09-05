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
        public override string Message { get; }
        
        public MyException(List<Point>lst)
        {
            Message = GetMessageFromList(lst);
        }
             
        private string GetMessageFromList(List<Point> lstPoint)
        {
            string strTemp = string.Empty;

            foreach (var item in lstPoint)
            {
                strTemp += $"{item._x}:{item._y}" + Environment.NewLine;
            }

            return strTemp;
        }
    }
}

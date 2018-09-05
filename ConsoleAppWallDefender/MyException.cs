namespace ConsoleAppWallDefender
{
    using System;
    using System.Collections.Generic;

    public class MyException : Exception
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

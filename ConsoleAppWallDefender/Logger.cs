using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWallDefender
{
    public static class Logger
    {      
        /// <summary>
        /// Запись в текстовый файл координат
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + '\\' + DateTime.Now.ToString("yyyy.MM.dd.hh")+ ".txt", true))
            {
                writer.Write("------------------- HISTORY ----------------------" + Environment.NewLine);
                writer.Write(text);
            }
        }
    }
}
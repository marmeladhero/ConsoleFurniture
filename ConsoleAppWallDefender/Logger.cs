namespace ConsoleAppWallDefender
{
    using System;
    using System.IO;

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
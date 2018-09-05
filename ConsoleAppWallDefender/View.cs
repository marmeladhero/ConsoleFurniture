

namespace ConsoleAppWallDefender
{
    using System;

    public class View : MyField
    {

        public View(int height, int width) : base(height, width)
        {  }


        /// <summary>
        /// Отрисовать поле
        /// </summary>
        public void Show()
        {
            Console.Clear();
            
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    Console.Write(DrawStringFromEnum((EnumFieldView)Field[i, j]));
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Запуск стрельбы
        /// </summary>
        public void Run()
        {
            do
            {
                try
                {
                    if (StartShooting())
                    {
                        Console.WriteLine("GAME OVER. Press any Key!");
                        Console.ReadKey();
                        return;
                    }
                }
                catch (MyException ex)
                {
                    Show();
                    Console.WriteLine("Attack finished! Press spacebar to try attack again! Press any key to exit");
                    
                    Logger.Write(ex.Message);

                    if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                    {
                        return;
                    }
                }
            }
            while (true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWallDefender
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View(5, 5);
            view.Show();
            view.Run();          
        }
    }
}

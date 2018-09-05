using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWallDefender
{
    /// <summary>
    /// Катапульта
    /// </summary>
    public class Katapulta
    {
        public static Random rand = new Random();

        public int _xPos { get; private set;  }

        public int _yPos { get; private set;  } 

        public void Shoot(int row, int col)
        {
            _xPos = rand.Next(row);
            _yPos = rand.Next(col);
        }
    }
}

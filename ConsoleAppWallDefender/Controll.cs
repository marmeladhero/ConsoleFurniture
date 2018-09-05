using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWallDefender
{
    public enum EnumFieldView
    {
        Empty = 0,
        Hit = 1,
        Wall = 2
    }
    
    public class Controll
    {
        protected int[,] Field = null;
        protected int _row = default(int);
        protected int _col = default(int);

        private Katapulta Katapulta = new Katapulta();
        private List<string> lstCoordinates = new List<string>();
        private int iCount = default(int);

        public Controll(int row, int col)
        {
            Field = new int[row, col];
            _row = row;
            _col = col;            
            SetWalls();
            iCount = (_row * 2 + _col * 2) - 4; 
        }

        private void SetWalls()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    if (i == 0 || i == _row - 1)
                    {
                        Field[i, j] = (int)EnumFieldView.Wall;
                    }
                    else if(j == 0 || j == _col - 1)
                    {
                        Field[i, j] = (int)EnumFieldView.Wall;
                    }
                }
            }
        }

        protected bool StartShooting()
        {
            while (iCount != 0)
            {
                Katapulta.Shoot(_row, _col);

                int iPos = Field[Katapulta._xPos, Katapulta._yPos];

                switch ((EnumFieldView)iPos)
                {
                    case EnumFieldView.Empty:
                        lstCoordinates.Add($"{DateTime.Now} -- Y:{Katapulta._xPos + 1}; X:{Katapulta._yPos + 1}"); // оценка по осевым координатам X Y
                        Field[Katapulta._xPos, Katapulta._yPos] = (int)EnumFieldView.Hit;
                        break;
                    case EnumFieldView.Hit:
                        break;
                    case EnumFieldView.Wall:
                        {
                            iCount--;
                            Field[Katapulta._xPos, Katapulta._yPos] = (int)EnumFieldView.Hit;
                            throw new MyException(GetMessageFromList(lstCoordinates));
                        }
                }

            }
            return true;
        }

        private string GetMessageFromList(List<string> lst)
        {
            string strTemp = string.Empty;

            foreach (var item in lst)
            {
                strTemp += item + Environment.NewLine;                
            }

            return strTemp;
        }
         
        protected string DrawStringFromEnum(EnumFieldView @enum)
        {
            switch (@enum)
            {
                case EnumFieldView.Empty:
                    return " . ";
                case EnumFieldView.Hit:
                    return " X ";
                case EnumFieldView.Wall:
                    return " # ";
            }

            return "";
        }
    }
}

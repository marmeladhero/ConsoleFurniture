namespace ConsoleAppWallDefender
{
    using System.Collections.Generic;

    public enum EnumFieldView
    {
        Empty = 0,
        Hit = 1,
        Wall = 2
    }
    
    public struct Point
    {
        public int _x { set; get; }
        public int _y { set; get; }    
    }

    public class MyField
    {
        protected int[,] Field = null;
        protected int _row = default(int);
        protected int _col = default(int);
        Katapulta Katapulta = new Katapulta();

        private List<Point> lstCoordinates = new List<Point>();
        private int iCount = default(int);

        public MyField(int row, int col)
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
                        lstCoordinates.Add(new Point(){ _x = Katapulta._xPos, _y = Katapulta._yPos });
                        Field[Katapulta._xPos, Katapulta._yPos] = (int)EnumFieldView.Hit;
                        break;
                    case EnumFieldView.Hit:
                        break;
                    case EnumFieldView.Wall:
                        {
                            lstCoordinates.Add(new Point() { _x = Katapulta._xPos, _y = Katapulta._yPos });
                            iCount--;
                            Field[Katapulta._xPos, Katapulta._yPos] = (int)EnumFieldView.Hit;
                            throw new MyException(lstCoordinates);
                        }
                }

            }
            return true;
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

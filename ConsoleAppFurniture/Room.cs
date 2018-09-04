namespace ConsoleAppFurniture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Controll
    /// </summary>
    class Room
    {
        protected List<Furniture> Lst { get; set; }

        protected int[,] Arr = null;

        public Room(int height, int width)
        {
            Lst = new List<Furniture>();
            Arr = new int[height, width];
        }

        protected virtual bool AddNewItem(Furniture furniture, EnumFurniture @enum)
        {
            if ((EnumFurniture)Enum.ToObject(typeof(EnumFurniture), Arr[furniture.XPos, furniture.YPos]) == EnumFurniture.Clear)
            {
                furniture._Id = Lst.Count;
                Lst.Add(furniture);
                Arr[furniture.XPos, furniture.YPos] = (int)@enum;
                return true;
            }

            return false;
        }

        protected virtual bool RemoveItem(Furniture furniture)
        {

            Arr[furniture.XPos, furniture.YPos] = (int)EnumFurniture.Clear;
            return Lst.Remove(furniture);
        }

        protected virtual int CheckCorrectAnswear(int min, int max)
        {
            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                Console.WriteLine("Input Error! Press any key");
                Console.ReadKey();
                return -1;
            }

            if (result >= min && result <= max)
            {
                return result;
            }
            else
            {
                Console.WriteLine($"Choose between range {min} - {max}. Press any key!");
                Console.ReadKey();
            }
            return -1;
        }

        protected virtual string GetTypeName(EnumFurniture @enum)
        {
            switch (@enum)
            {
                case EnumFurniture.Armchair:
                    return "AChair";
                case EnumFurniture.Chair:
                    return "Chair";
                case EnumFurniture.Table:
                    return "Table";
                case EnumFurniture.TV:
                    return "TV";
            }

            return "Unknown type";
        }

        protected virtual Furniture GetFurniture(int x, int y) => Lst.Where(i => i.XPos == x && i.YPos == y).FirstOrDefault();
        

        protected virtual bool MoveFurniture(Furniture furniture, int x, int y)

        {
            int xTemp = furniture.XPos, yTemp = furniture.YPos;
            if (furniture.Move(x, y))
            {
                Arr[xTemp, yTemp] = (int)EnumFurniture.Clear;
                Arr[x, y] = (int)furniture.Type;

                return true;
            }

            return false;

        }
    }
}

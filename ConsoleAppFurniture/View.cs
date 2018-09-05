namespace ConsoleAppFurniture
{
    using System;
    using System.Linq;

    class View : Room
    {
        private int _row { set; get; }
        private int _col { set; get; }

        public View(int height, int width) : base(height, width)
        {
            _col = width;
            _row = height;
        }

        private string DrowChar(EnumFurniture @enum)
        {
            switch (@enum)
            {
                case EnumFurniture.Clear:
                    return " . ";
                case EnumFurniture.Chair:
                    return " H ";
                case EnumFurniture.Armchair:
                    return " M ";
                case EnumFurniture.Table:
                    return " T ";
                case EnumFurniture.TV:
                    return " Y ";
                default:
                    return " X ";
            }
        }

        public void Show()
        {
            Console.Clear();

            Console.Write(" ");

            for(int i = 0; i < _row; i++)
            {
                Console.Write($" {i + 1} ");
            }

            Console.WriteLine();

            for (int i = 0; i < _row; i++)
            {
                Console.Write("{0}", i + 1);
                for (int j = 0; j < _col; j++)
                {
                    Console.Write(DrowChar((EnumFurniture)Arr[i, j]));
                }
                Console.WriteLine();
            }
        }                            

        public void ShowTable()
        {            
            Console.Clear();
            Console.Write("|\tId\t");
            Console.Write("|\tName\t");
            Console.Write("|\tRow\t");
            Console.Write("|\tCol\t");
            Console.Write("|\tType\t");
            Console.Write("|\tState\t|");

            Console.WriteLine();

            for (int i = 0; i < Lst.Count; i++)
            {
                Console.WriteLine($"|\t{Lst[i].Id}\t|\t{Lst[i].FurnitureName}\t|\t{Lst[i].XPos + 1}\t|\t{Lst[i].YPos + 1}\t|\t{GetTypeName(Lst[i].Type)}\t|\t{Lst[i].Progress}\t|");
            }
        }

        public int ShowMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Show your room");
                Console.WriteLine("2. Add Furniture");   
                Console.WriteLine("3. Remove furniture");
                Console.WriteLine("4. Clear room");
                Console.WriteLine("5. Activating item");
                Console.WriteLine("6. Move item");
                Console.WriteLine("8. exit");               

                int res = CheckCorrectAnswear(1, 8);
                if (res!=-1)
                {
                    return res;
                }

            } while(true);
        }

        public void ActivateItem()
        {
            int res = 0;

            do
            {
                ShowTable();
                Console.Write($"Choose ID to change state(Press {Lst.Count + 1} to exit): ");
                
                if (Lst.Count == 0)
                {
                    res = CheckCorrectAnswear(Lst.Count + 1, Lst.Count + 1);
                }
                else
                {
                    res = CheckCorrectAnswear(0, Lst.Count + 1);
                }

                if (res == Lst.Count + 1)
                    return;

                if (res != -1)
                {
                    Lst.Where(x => x.Id == res).FirstOrDefault().ChangeState();
                    Console.WriteLine("State changed! Press any key");
                    Console.ReadKey();                   
                }

            } while (res != Lst.Count + 1);
        }

        public void MoveItem()
        {
          
            do
            {
                Show();
                Console.WriteLine("Moving FROM");
                Console.Write($"Choose Row (LEFT): ");
                int xPos = CheckCorrectAnswear(1, _row);
                if (xPos == -1)
                    continue;
                Console.Write($"Choose Column (TOP): ");
                int yPos = CheckCorrectAnswear(1, _col);
                if (yPos == -1)
                    continue;

                Console.WriteLine("Moving TO");
                Console.Write($"Choose Row (LEFT): ");
                int xPosT = CheckCorrectAnswear(1, _row);
                if (xPosT == -1)
                    continue;
                Console.Write($"Choose Column (TOP): ");
                int yPosT = CheckCorrectAnswear(1, _col);
                if (yPosT == -1)
                    continue;

                var temp = GetFurniture(--xPos, --yPos);

                if (temp != null)
                {
                    if(MoveFurniture(temp, --xPosT, --yPosT))
                    {
                        Show();
                        Console.WriteLine($"Moving was sucessfull. {temp.FurnitureName}/{GetTypeName(temp.Type)} was moved to {xPosT + 1} {yPosT + 1}. Press escape to exit, any key to resume!");

                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Moving unvaliable. Check status of furniture. Exit - press escape");
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            return;
                        }                    
                    }
                }
                else
                {
                    Console.WriteLine("You choose empty field. Try again. Press any key");
                    Console.ReadKey();
                }

            } while (true);
        }

        #region RemoveFurniture

        public void ClearRoom()
        {
            bool success = true;
            
            foreach(var i in Lst.ToList())
            {
                success = RemoveItem(i);
            }

            if (success)
            {
                Console.WriteLine("Cleaning was successfull. Press any key");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cleaning failed. Press any key");
                Console.ReadKey();
            }
        }

        public void RemoveFurniture()
        {
            int res = 0;

            do
            {
                ShowTable();
                Console.Write($"Choose ID to remove(Press {Lst.Count + 1} to exit): ");
                if (Lst.Count == 0)
                {
                    res = CheckCorrectAnswear(Lst.Count + 1, Lst.Count + 1);
                }
                else
                {
                    res = CheckCorrectAnswear(0, Lst.Count + 1);
                }

                if (res == Lst.Count + 1)
                    return;

                if (res != -1)
                {
                    if (RemoveItem(Lst.Where(x => x.Id == res).FirstOrDefault()))
                    {
                        Console.WriteLine("Removing succesfull. Press any key");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Removing failed. Press any key");
                        Console.ReadKey();
                    }
                }

            } while (res != Lst.Count + 1);
        }

        #endregion

        #region AddingFurniture
        public void SelectPosition(int furniture)
        {
            do
            {
                if (furniture == 5)
                {
                    return;
                }

                Console.Clear();

                Console.WriteLine("Choose name: ");

                string strName = Console.ReadLine();

                Show();

                Console.WriteLine("Select Row (LEFT): ");
                int resX = CheckCorrectAnswear(1, _col);

                if (resX == -1)
                {
                    continue;
                }

                Console.WriteLine("Select Column (TOP): ");
                int resY = CheckCorrectAnswear(1, _row);

                if (resY == -1)
                {
                    continue; 
                }

                bool IsOk = true;
                resY--;
                resX--;
                switch (furniture)
                {
                    case 1:
                        IsOk = AddNewItem(new Chair(0, resX, resY, strName), EnumFurniture.Chair);
                        break;
                    case 2:
                        IsOk = AddNewItem(new Armchair(0, resX, resY, strName), EnumFurniture.Armchair);
                        break;
                    case 3:
                        IsOk = AddNewItem(new Table(0, resX, resY, strName), EnumFurniture.Table);
                        break;
                    case 4:
                        IsOk = AddNewItem(new TV(0, resX, resY, strName), EnumFurniture.TV);
                        break;   
                }

                if (IsOk)
                {
                    Show();
                    Console.WriteLine($"{strName} was placed into {resX + 1}, {resY + 1}. Press any key!");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine($"Placing {strName} into {resX + 1}, {resY + 1} was failed. Choose another place");
                    Console.ReadKey();

                }

            } while (true);
        }

        public int ResolveFurniture()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Chair");
                Console.WriteLine("2. Add Armchair");
                Console.WriteLine("3. Add Table");
                Console.WriteLine("4. Add TV");
                Console.WriteLine("5. Back to menu");

                int res = CheckCorrectAnswear(1, 5);
                if(res!=-1)
                {
                    return res;
                }

            } while (true);

        }
        #endregion
    }
}

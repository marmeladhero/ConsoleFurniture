namespace ConsoleAppFurniture
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            View view = new View(5, 5);
            bool bExit = true;

            do
            {

                switch (view.ShowMenu())
                {
                    case 1:
                        view.Show();
                        Console.WriteLine("Press any button to go back");
                        Console.ReadKey();
                        break;
                    case 2:
                        view.SelectPosition(view.ResolveFurniture());
                        break;
                    case 3:
                        view.RemoveFurniture();
                        break;
                    case 4:
                        view.ClearRoom();
                        break;
                    case 5:
                        view.ActivateItem();
                        break;
                    case 6:
                        view.MoveItem();
                        break;            
                    case 8:
                        bExit = false;
                        break;
                }

            } while (bExit);
            Console.WriteLine("Good bye");
            Console.ReadKey();
        }
    }
}
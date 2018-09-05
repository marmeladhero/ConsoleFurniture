namespace ConsoleAppWallDefender
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View(6, 6);
            view.Show();
            view.Run();          
        }
    }
}
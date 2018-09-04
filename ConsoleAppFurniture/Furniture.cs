namespace ConsoleAppFurniture
{
    using System;

    public enum EnumFurniture
    {
        Clear = 0,
        Chair = 1,        
        Armchair = 2,
        Table = 3,
        TV = 4
    }

    /// <summary>
    /// Model
    /// </summary>
    public abstract class Furniture
    {
        protected int _Id { get; set; }
        protected string Name { get; set; }
        protected int _XPos { get; set; }
        protected int _YPos { get; set; }
        protected bool InProgress { get; set; }
        public bool Progress { get { return InProgress; } }

        public int XPos { get { return _XPos; } }
        public int Id { get { return _Id; } }
        public int YPos { get { return _YPos; } }
        public string FurnitureName { get { return Name; } }


        /// <summary>
        /// chair, Tv etc
        /// </summary>
        protected EnumFurniture _Type { get; set; }
        public EnumFurniture Type { get { return _Type; } }

        public void ChangeState()
        {
            if (InProgress)
            {
                InProgress = false;
            }
            else
            {
                InProgress = true;
            }
        }

        public void SetId(int id) => _Id = id;        

        public Furniture(int id, int x, int y, string name, EnumFurniture furniture)
        {
            _Id = id;
            _XPos = x;
            _YPos = y;
            Name = name;
            _Type = furniture;
        }
        
        public virtual bool Move(int x, int y)
        {
            if (!this.InProgress)
            {                
                this._XPos = x;
                this._YPos = y;
                return true;
            }      
            return false;           
        }
    }

    public class Chair : Furniture
    {
        public Chair(int id, int x, int y, string name) : base(id, x, y, name, EnumFurniture.Chair)
        {

        }

        public override bool Move(int x, int y)
        {
            Console.WriteLine($"Chair is moving to {x};{y}");
            return base.Move(x, y);
        }
    }

    public class TV : Furniture
    {
        public TV(int id, int x, int y, string name) : base(id, x, y, name, EnumFurniture.TV)
        {

        }

        public override bool Move(int x, int y)
        {
            Console.WriteLine($"TV is moving to {x};{y}");
            return base.Move(x, y);
        }

        public void SwitchOnOff(bool turn)
        {
            this.InProgress = turn;
        }
    }

    public class Table : Furniture
    {
        public Table(int id, int x, int y, string name) : base(id, x, y, name, EnumFurniture.Table)
        {

        }

        public override bool Move(int x, int y)
        {
            Console.WriteLine($"Table is moving to {x};{y}");
            return base.Move(x, y);
        }
    }

    public class Armchair : Furniture
    {
        public Armchair(int id, int x, int y, string name) : base(id, x, y, name, EnumFurniture.Armchair)
        {

        }

        public override bool Move(int x, int y)
        {
            Console.WriteLine($"Armchair is moving to {x};{y}");
            return base.Move(x, y);
        }
    }
}

using System;

namespace NavalBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            WarShip ws = new WarShip(new Point(1, 1), 15, 10, Directions.Left);
            WarShip ws2 = new WarShip(new Point(2, 2), 3, 1, Directions.Top);
            WarShip ws3 = new WarShip(new Point(0, 0), 3, 1, Directions.Top);
            WarShip ws4 = new WarShip(new Point(0, 1), 3, 1, Directions.Top);
            WarShip ws5 = new WarShip(new Point(1, 0), 3, 1, Directions.Top);


            SupportShip ss5 = new SupportShip(new Point(10, 0), 3, 1, Directions.Right);
            SupportShip ss6 = new SupportShip(new Point(11, 0), 3, 1, Directions.Right);
            SupportShip ss7 = new SupportShip(new Point(12, 0), 3, 1, Directions.Right);

            GameBoard gb = new GameBoard();
            
            gb.AddShip(ws4);
            gb.AddShip(ws);
            gb.AddShip(ws2);
            gb.AddShip(ws3);
            gb.AddShip(ws5);
            gb.AddShip(ss5);
            gb.AddShip(ss6);
            gb.AddShip(ss7);
            
            

            Console.WriteLine(gb.ToString());
        }
    }
}

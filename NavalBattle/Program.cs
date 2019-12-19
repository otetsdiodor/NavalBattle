using NavalBattle.Game;
using NavalBattle.Ships;
using System;

namespace NavalBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            WarShip ws = new WarShip(15, 10, Directions.Left);
            WarShip ws2 = new WarShip(3, 1, Directions.Top);
            WarShip ws3 = new WarShip(3, 1, Directions.Top);
            WarShip ws4 = new WarShip(3, 1, Directions.Top);
            WarShip ws5 = new WarShip(3, 1, Directions.Top);


            SupportShip ss5 = new SupportShip(3, 1, Directions.Right);
            SupportShip ss6 = new SupportShip(3, 1, Directions.Right);
            SupportShip ss7 = new SupportShip(3, 1, Directions.Right);

            GameBoard gb = new GameBoard(10);
            
            gb[1,1,1] = ws4;
            //gb[1,2,2] = ws;
            //gb[1,0,0] = ws2;
            //gb[1,0,1] = ws3;
            //gb[1,1,0] = ws5;
            //gb[1,10,3] = ss5;
            //gb[1,11,3] = ss6;
            //gb[1, 12,3] = ss7;
            
            

            Console.WriteLine(gb.ToString());
        }
    }
}

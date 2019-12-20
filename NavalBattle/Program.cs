using NavalBattle.Game;
using NavalBattle.Ships;
using System;

namespace NavalBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            WarShip ws4 = new WarShip(3, 1, Directions.Top);

            GameBoard gb = new GameBoard(10);
            
            gb[1,1,1] = ws4;

            
            

            Console.WriteLine(gb.ToString());
        }
    }
}

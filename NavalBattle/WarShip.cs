using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle
{
    public class WarShip : BaseShip
    {
        public WarShip(Point headCoords, int lenght,int speed,Directions direction):base(headCoords,lenght, speed, direction)
        {   }
        public void Attack()
        {
            Console.WriteLine("ATTACK");
        }
    }
}

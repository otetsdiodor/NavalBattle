using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle
{
    public class MixShip: BaseShip
    {
        public MixShip(Point headCoords, int lenght, int speed, Directions direction) : base(headCoords, lenght, speed, direction)
        { }
        public void Attack()
        {
            Console.WriteLine("ATTACK");
        }
        public void Support()
        {
            Console.WriteLine("SUPPORT");
        }
    }
}

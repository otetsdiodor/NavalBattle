using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle
{
    public class SupportShip : BaseShip
    {
        public SupportShip(Point headCoords, int lenght, int speed, Directions direction) : base(headCoords, lenght, speed, direction)
        {  }
        public void Support()
        {
            Console.WriteLine("SUPPORT");
        }
    }
}

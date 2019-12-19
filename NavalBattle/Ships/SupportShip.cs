using System;
using System.Collections.Generic;
using System.Text;
using NavalBattle.Intefaces;

namespace NavalBattle.Ships
{
    public class SupportShip : BaseShip, IAssistable
    {
        public SupportShip(int lenght, int speed, Directions direction) : base(lenght, speed, direction)
        {  }

        public void Reapir()
        {
            Console.WriteLine("REPAIR");
        }
    }
}

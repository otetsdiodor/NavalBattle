using NavalBattle.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle.Ships
{
    public class WarShip : BaseShip, IAttackable
    {
        public WarShip(int lenght,int speed,Directions direction):base(lenght, speed, direction)
        {   }
        public void Attack()
        {
            Console.WriteLine("ATTACK");
        }
    }
}

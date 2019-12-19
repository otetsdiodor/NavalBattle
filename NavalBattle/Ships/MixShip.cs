using NavalBattle.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle.Ships
{
    public class MixShip: BaseShip, IAssistable, IAttackable
    {
        public MixShip(int lenght, int speed, Directions direction) : base(lenght, speed, direction)
        { }
        public void Attack()
        {
            Console.WriteLine("ATTACK");
        }

        public void Reapir()
        {
            Console.WriteLine("Repair");
        }
    }
}

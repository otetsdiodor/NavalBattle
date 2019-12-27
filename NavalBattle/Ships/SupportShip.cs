using System;
using System.Collections.Generic;
using System.Text;
using NavalBattle.Game;
using NavalBattle.Intefaces;
using ORM;

namespace NavalBattle.Ships
{
    [Table("Ship")]
    public class SupportShip : BaseShip, IAssistable
    {
        public SupportShip(string id, int gbId, GameBoard gb, int lenght, int range, int speed, int direction) : base(id, gbId, gb, lenght, range, speed, direction)
        {  }

        public void Reapir()
        {
            Console.WriteLine("REPAIR");
        }
    }
}

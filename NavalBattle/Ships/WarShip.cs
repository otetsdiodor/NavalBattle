﻿using NavalBattle.Game;
using NavalBattle.Intefaces;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle.Ships
{
    [Table("Ship")]
    public class WarShip : BaseShip, IAttackable
    {
        public WarShip(string id, int gbId, GameBoard gb, int lenght, int range , int speed, int direction ) : base(id,gbId,gb,lenght, range, speed, direction)
        {   }
        public void Attack()
        {
            Console.WriteLine("ATTACK");
        }
    }
}

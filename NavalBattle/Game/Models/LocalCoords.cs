using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle.Game.Models
{
    public struct LocalCoords
    {
        public int Q { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public LocalCoords(int q,int x,int y)
        {
            X = x;
            Y = y;
            Q = q;
        }
    }
}

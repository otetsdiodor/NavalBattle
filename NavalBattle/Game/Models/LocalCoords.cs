using NavalBattle.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle.Game.Models
{
    public class LocalCoords
    {
        public string Id { get; set; }
        public int GameBoardId { get; set; }
        public GameBoard GameBoard { get; set; }
        public int Q { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public LocalCoords(string id,int gbId,GameBoard gb, int q,int x,int y)
        {
            Id = id;
            GameBoardId = gbId;
            GameBoard = gb;
            X = x;
            Y = y;
            Q = q;
        }
    }
}

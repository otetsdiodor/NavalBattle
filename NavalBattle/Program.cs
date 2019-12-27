using NavalBattle.Game;
using NavalBattle.Game.Models;
using NavalBattle.Ships;
using ORM;
using System;
using System.Reflection;

namespace NavalBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new Repository<GameBoard>();
            GameBoard gb = new GameBoard(1, 10);
            var gb1 = rep.GetById("1");

            WarShip ws4 = new WarShip(Guid.NewGuid().ToString(),1,gb1, 3, 1, 90,15);
            WarShip ws5 = new WarShip(Guid.NewGuid().ToString(),1,gb1, 2, 1, 90,10);
            WarShip ws6 = new WarShip(Guid.NewGuid().ToString(),1,gb1, 2, 1, 90,11);
            var rep2 = new Repository<WarShip>();
            var tt = rep2.GetById("3c9290c0-7aad-4494-a2a4-2cf3b5aab852");
            //rep2.Add(ws4);
            //rep2.Add(ws5);
            //rep2.Add(ws6);
            var cor = new LocalCoords(Guid.NewGuid().ToString(), 1, gb1, 1, 1, 1);
            var cor1 = new LocalCoords(Guid.NewGuid().ToString(), 1, gb1, 2, 2, 2);
            var cor2 = new LocalCoords(Guid.NewGuid().ToString(), 1, gb1, 3, 2, 2);
            var repcor = new Repository<LocalCoords>();
            //repcor.Add(cor);
            //repcor.Add(cor1);
            //repcor.Add(cor2);
            var tttmp = repcor.GetById("d9f5f352-c034-4d7b-9803-9e35e79e9bfb");
            var www= repcor.GetTs();
            //gb[1,1,1] = ws4;
            //Console.WriteLine(gb1.ToString());
            //TODO: добавить в локал кордс ссылку на корабль, что бы связать корабли с координатами
        }
    }
}

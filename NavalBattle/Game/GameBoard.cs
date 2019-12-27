using NavalBattle.Game.Models;
using NavalBattle.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using ORM;

namespace NavalBattle.Game
{
    public class GameBoard
    {
        //Dictionary<LocalCoords, BaseShip> ships;
        public int Id { get; set; }
        public List<LocalCoords> coords { get; set; }
        public List<BaseShip> ships { get;set; }
        private int[,] gameField;
        private int length;
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value % 2 == 0)
                    length = value;
                else
                    throw new Exception("Number must be even");
            }
        }
        public GameBoard(int id,int len, List<LocalCoords> cords, List<BaseShip> ships)
        {
            Id = id;
            Length = len;
            gameField = new int[len, len];
            coords = cords;
            this.ships = ships;
        }
        public GameBoard(int id, int len)
        {
            Id = id;
            Length = len;
            gameField = new int[len, len];
        }
        [Skip]
        public BaseShip this [int q,int x, int y]
        {
            get
            {
                ValidateQuadrant(q);

                for (int i = 0; i < coords.Count; i++)
                    if (coords[i].X == x && coords[i].Y == y)
                        return ships[i];

                return null;
            }
            set
            {
                ValidateQuadrant(q);
                var coord = new LocalCoords(Guid.NewGuid().ToString(),Id,this,q, x, y);
                var globalCoord = ConvertToGlobal(coord);
                var Coordslist = new List<GlobalCoords>();
                for (int i = 0; i < value.Length; i++)
                {
                    switch (ReversDirection(value.Direction))
                    {
                        case 180:
                            globalCoord.X -= 1;    
                            break;
                        case 0:
                            globalCoord.X += 1;
                            break;
                        case 90:
                            globalCoord.Y += 1;
                            break;
                        case 270:
                            globalCoord.Y -= 1;
                            break;
                    }

                    if (CoordsIsValid(globalCoord))
                        Coordslist.Add(globalCoord);
                    else throw new Exception("Ship leavs borders or crosses another borad");
                }

                foreach (var item in Coordslist)
                {
                    gameField[item.X, item.Y] = 1;
                }

                coords.Add(coord);
                ships.Add(value);
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        Console.Write(gameField[j,i] + " ");
                    }
                    Console.WriteLine("");
                }
            }
        }
        private bool CoordsIsValid(GlobalCoords coords)
        {
            if (coords.X > Length -1 || coords.Y > Length -1)
                return false;

            if (gameField[coords.X,coords.Y] == 0)
                return true;

            return false;
        }
        private GlobalCoords ConvertToGlobal(LocalCoords p)
        {
            LocalCoords ptemp = p;
            switch (p.Q)
            {
                case 1: break;
                case 2:
                    ptemp.X *= -1;
                    break;
                case 3:
                    ptemp.X *= -1;
                    ptemp.Y *= -1;
                    break;
                case 4:
                    ptemp.Y *= -1;
                    break;
            }

            ptemp.X = Length / 2 + ptemp.X -1;
            ptemp.Y = Length / 2 + ptemp.Y -1;
            return new GlobalCoords(ptemp.X, ptemp.Y);
        }

        private int ReversDirection(int direction)
        {
            switch (direction)
            {
                case 180:
                    return 0;
                case 0:
                    return 180;
                case 90:
                    return 270;
                case 270:
                    return 90;
                default:
                    return 90; // ? 
            }
        }
        private bool ValidateQuadrant(int q)
        {
            if (q > 4 || q < 1)
                throw new Exception("q should be betwen 1 and 4");
            return true;
        }

        public override string ToString()
        {
            var resultString = "";
            var ShipsRangeToCenter = new Dictionary<int, double>();

            for (int i = 0; i < ships.Count; i++)
                ShipsRangeToCenter.Add(i, Math.Sqrt(Math.Pow(coords[i].X, 2) + Math.Pow(coords[i].Y, 2)));

            var ShipsRangesList = ShipsRangeToCenter.ToList();
            ShipsRangesList.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));

            for (int i = 0; i < ShipsRangesList.Count; i++)
                resultString += ships[ShipsRangesList[i].Key] + "\n" + new string('_',30) + "\n";

            return resultString;
        }
    }
}

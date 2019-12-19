using NavalBattle.Game.Models;
using NavalBattle.Ships;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavalBattle.Game
{
    public class GameBoard
    {
        Dictionary<LocalCoords, BaseShip> ships;
        private int[,] gameField;
        private int length;
        public int Lenght
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
        public GameBoard(int len)
        {
            Lenght = len;
            gameField = new int[len, len];
            ships = new Dictionary<LocalCoords, BaseShip>();
        }

        public BaseShip this [int q,int x, int y]
        {
            get
            {
                ValidateQuadrant(q);
                
                foreach (var ship in ships)
                    if (ship.Key.X == x && ship.Key.Y == y)
                
                        return ship.Value;

                return null;
            }
            set
            {
                ValidateQuadrant(q);
                var coord = new LocalCoords(q, x, y);
                var globalCoord = ConvertToGlobal(coord);
                var Coordslist = new List<GlobalCoords>();
                for (int i = 0; i < value.Length; i++)
                {
                    switch (ReversDirection(value.Direction))
                    {
                        case Directions.Left:
                            globalCoord.X -= i;
                            break;
                        case Directions.Right:
                            globalCoord.X += i;
                            break;
                        case Directions.Top:
                            globalCoord.Y += i;
                            break;
                        case Directions.Bottom:
                            globalCoord.Y -= i;
                            break;
                    }

                    if (CoordsIsValid(globalCoord))
                        Coordslist.Add(globalCoord);
                    else throw new Exception("Ship leavs borders or crosses another borad");

                    foreach (var item in Coordslist)
                    {
                        gameField[item.X, item.Y] = 1;
                    }

                }
                ships.Add(coord, value);
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        Console.Write(gameField[i,j] + " ");
                    }
                    Console.WriteLine("");
                }
            }
        }
        private bool CoordsIsValid(GlobalCoords coords)
        {
            if (coords.X > Lenght -1 || coords.Y > Lenght -1)
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

            ptemp.X = Lenght / 2 + ptemp.X;
            ptemp.Y = Lenght / 2 + ptemp.Y;
            return new GlobalCoords(ptemp.X, ptemp.Y);
        }

        private Directions ReversDirection(Directions direction)
        {
            switch (direction)
            {
                case Directions.Left:
                    return Directions.Right;
                case Directions.Right:
                    return Directions.Left;
                case Directions.Top:
                    return Directions.Bottom;
                case Directions.Bottom:
                    return Directions.Top;
                default:
                    return Directions.Top; // ? 
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
            var ShipsRangeToCenter = new Dictionary<LocalCoords, double>();

            foreach (var item in ships)
                ShipsRangeToCenter.Add(item.Key, Math.Sqrt(Math.Pow(item.Key.X, 2) + Math.Pow(item.Key.Y, 2)));

            var ShipsRangesList = ShipsRangeToCenter.ToList();
            ShipsRangesList.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));

            for (int i = 0; i < ShipsRangesList.Count; i++)
                resultString += ships[ShipsRangesList[i].Key] + "\n" + new string('_',30) + "\n";

            return resultString;
        }
    }
}

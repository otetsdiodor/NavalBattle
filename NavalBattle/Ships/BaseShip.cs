using NavalBattle.Game;
using NavalBattle.Game.Models;
using ORM;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NavalBattle.Ships
{
    //public enum Directions
    //{
    //    Left = 180,
    //    Right = 0,
    //    Top = 90,
    //    Bottom = 270
    //}
    [Table("Ship")]
    public abstract class BaseShip : IEquatable<BaseShip>
    {
        public string Id { get; set; }
        public int GameBoardId { get; set; }
        public GameBoard GameBoard { get; set; }
        public int Length { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public int Direction { get; set; }
        public void Move(LocalCoords coords)
        {
            coords.X += Speed * (int)Math.Round(Math.Cos((double)Direction / 180.0 * Math.PI));
            coords.Y += Speed * (int)Math.Round(Math.Sin((double)Direction / 180.0 * Math.PI));
        }

        public BaseShip(string id,int gbId, GameBoard gb,int lenght, int range, int speed,int direction)
        {
            Id = id;
            GameBoardId = gbId;
            GameBoard = gb;
            Length = lenght;
            Direction = direction;
            Speed = speed;
            Range = range;
        }
        public override string ToString()
        {
            return string.Format("Type: {0}\nLenght: {1}\nSpeed: {2}\nDirection: {3}",GetType().ToString(), Length, Speed, Direction);
        }
        public static bool operator ==(BaseShip first, BaseShip second)
        {
            return Equals(first, second);
        }
        public static bool operator !=(BaseShip first, BaseShip second)
        {
            return !Equals(first, second);
        }
        public bool Equals([AllowNull] BaseShip other)
        {
            if (GetType() == other.GetType() &&
                Length == other.Length &&
                Speed == other.Speed)
                return true;

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle
{
    public enum Directions
    {
        Left = 180,
        Right = 0,
        Top = 90,
        Bottom = 270
    }
    public abstract class BaseShip
    {
        public Point HeadCoords { get; private set; }        
        public int Length { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public Directions Direction { get; set; }
        public void Move()
        {
            HeadCoords.X += Speed * (int)Math.Round(Math.Cos((double)Direction/180.0*Math.PI));
            HeadCoords.Y += Speed * (int)Math.Round(Math.Sin((double)Direction/180.0*Math.PI));
        }

        public BaseShip(Point headCoords,int lenght,int speed,Directions direction)
        {
            HeadCoords = headCoords;
            Length = lenght;
            Direction = direction;
            Speed = speed;
        }
        public override string ToString()
        {
            return "Type: " + GetType().ToString() + "\n"+
                "Current coords: x " + HeadCoords.X + " y " + HeadCoords.Y + "\n" + 
                "Lenght: " + Length +"\n" + 
                "Speed: " + Speed + "\n" + 
                "Direction: " + Direction;
        }
        public static bool operator ==(BaseShip first, BaseShip second)
        {
            if (first.GetType() == second.GetType() &&
                first.Length == second.Length &&
                first.Speed == second.Speed)
                return true;

            return false;
        }
        public static bool operator !=(BaseShip first, BaseShip second)
        {
            if (first.GetType() == second.GetType() &&
                first.Length == second.Length &&
                first.Speed == second.Speed)
                return false;

            return true;
        }
    }
}

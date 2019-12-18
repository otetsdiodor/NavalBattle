using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle
{
    public abstract class BaseShip
    {
        public Point HeadCoords { get; private set; }

        private int lenght;
        
        public int Lenght
        {
            get
            {
                return lenght;
            }
            private set
            {
                if (value > 4 && value < 1)
                    throw new ArgumentOutOfRangeException("Should be betwen 0..4");

                lenght = value;
            }
        }
        public int Range { get; set; }
        public int Speed { get; set; }
        public Point Direction { get; set; }
        public void Move()
        {
            HeadCoords.X += Speed * Direction.X;
            HeadCoords.Y += Speed * Direction.Y;
        }

        public BaseShip(Point headCoords,int lenght)
        {
            this.lenght = lenght;
            HeadCoords = headCoords;
        }
    }
}

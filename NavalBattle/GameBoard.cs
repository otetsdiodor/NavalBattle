using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalBattle
{
    public class GameBoard
    {
        List<BaseShip> ships;
        public GameBoard()
        {
            ships = new List<BaseShip>();
        }

        public void AddShip(BaseShip ship)
        {
            foreach (var sp in ships)
                if (IsOnSimilarPoint(sp, ship))
                    throw new Exception("This coordinates have already exist ship");

            ships.Add(ship);
        }

        public BaseShip this [int q,int x, int y]
        {
            get
            {
                if (q > 4 || q < 1)
                    throw new Exception("q should be betwen 1 and 4");

                switch (q)
                {
                    case 1:
                        break;
                    case 2:
                        x *= -1;
                        break;
                    case 3:
                        x *= -1;
                        y *= -1;
                        break;
                    case 4:
                        y *= -1;
                        break;

                }
                
                foreach (var ship in ships)
                    if (ship.HeadCoords.X == x && ship.HeadCoords.Y == y)
                
                        return ship;

                return null;
            }
        }

        private bool IsOnSimilarPoint(BaseShip first, BaseShip second)
        {
            if (first.HeadCoords.X == second.HeadCoords.X &&
                first.HeadCoords.Y == second.HeadCoords.Y)
                return true;

            return false;
        }

        public override string ToString()
        {
            var resultString = "";
            var ShipsRangeToCenter = new Dictionary<int,double>();
            var counter = 0;

            foreach (var item in ships)
                ShipsRangeToCenter.Add(counter++, Math.Sqrt(Math.Pow(item.HeadCoords.X, 2) + Math.Pow(item.HeadCoords.Y, 2)));

            var ShipsRangesList = ShipsRangeToCenter.ToList();
            ShipsRangesList.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));

            for (int i = 0; i < ShipsRangesList.Count; i++)
                resultString += ships[ShipsRangesList[i].Key] + "\n" + new string('_',30) + "\n";

            return resultString;
        }
    }
}

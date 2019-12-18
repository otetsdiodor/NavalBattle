using System;
using System.Collections.Generic;
using System.Text;

namespace NavalBattle
{
    public class GameBoard
    {
        List<BaseShip> ships;

        public void AddShip(BaseShip ship)
        {
            foreach (var sp in ships)
                if (IsOnSimilarPoint(sp, ship))
                    throw new Exception("This coordinates have already exist ship");

            ships.Add(ship);
        }

        BaseShip this [int q,int x, int y]
        {
            get
            {
                foreach (var ship in ships)
                    if (ship.HeadCoords.X == x && ship.HeadCoords.Y == y)
                        return ship;

                return null;
            }
        }

        public bool IsOnSimilarPoint(BaseShip first, BaseShip second)
        {
            if (first.Direction.X == second.Direction.X &&
                first.Direction.Y == second.Direction.Y)
                return true;

            return false;
        }
    }
}

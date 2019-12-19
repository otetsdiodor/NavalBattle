namespace NavalBattle.Game.Models
{
    public struct GlobalCoords
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GlobalCoords(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
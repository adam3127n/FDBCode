namespace LandMines
{
    public class Square : ISquare
    {
        public bool ContainsLandMine { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    } 
}
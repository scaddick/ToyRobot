namespace ToyRobots.Models
{
    public class Coordinates
    {
        private int _xCoordinate;
        private int _yCoordinate;

        public Coordinates(int x, int y)
        {
            _xCoordinate = x;
            _yCoordinate = y;
        }

        public int X
        {
            get => _xCoordinate;
            set => _xCoordinate = value;
        }
        public int Y
        {
            get => _yCoordinate;
            set => _yCoordinate = value;
        }
    }
}
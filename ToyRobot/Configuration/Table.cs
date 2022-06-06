namespace ToyRobots.Configuration
{
    public class Table
    {
        public Table()
        {

        }
        public Table(int width, int depth)
        {
            Width = width;
            Depth = depth;
        }

        public int Width { get; set; }
        public int Depth { get; set; }
    }
}
namespace Assignment8
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return "\nX: " + X + ", Y: " + Y;
        }
    }
}
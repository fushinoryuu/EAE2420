namespace Assignment6
{
    class GraphNode
    {
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Connection[] Connections { get; set; }
        public float Heuristic { get; set; }
        public float Cost { get; set; }
        public float Distance { get; set; }
    }
}
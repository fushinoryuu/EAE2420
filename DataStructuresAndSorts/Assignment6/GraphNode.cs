namespace Assignment6
{
    class GraphNode
    {
        public string name { get; set; }
        public double xy { get; set; }
        public Connection[] connections { get; set; }
        public double Heuristic { get; set; }


        public GraphNode()
        {

        }
    }

    class Connection
    {
        public double distance { get; set; }
        public GraphNode target { get; set; }
        public double cost { get; set; }
    }
}

namespace Assignment6
{
    class GraphNode
    {
        public string Name { get; set; }
        public Connection[] Connections { get; set; }
        public GraphNode CameFrom { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Heuristic { get; set; }
        public double CostSoFar { get; set; }
        public double TotalEstimatedCost { get { return Heuristic + CostSoFar; } }
    }
}

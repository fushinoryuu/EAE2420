namespace Assignment6
{
    class NewGraphNode
    {
        public string Name { get; set; }
        public NewConnection[] Connections { get; set; }
        public NewGraphNode Parent { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; } // Heuristic
        public double G { get; set; } // Cost So Far
        public double F { get; set; } // Total Estimated Cost
    }
}

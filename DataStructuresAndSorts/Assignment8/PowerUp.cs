namespace Assignment8
{
    class PowerUp
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public Entity Container { get; set; }
        private int Turns { get; set; }

        public virtual void Update() { }
    }
}

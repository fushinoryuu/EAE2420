﻿namespace Assignment8
{
    class PowerUp
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool IsActive { get; set; }

        public virtual void Update() { }
    }
}

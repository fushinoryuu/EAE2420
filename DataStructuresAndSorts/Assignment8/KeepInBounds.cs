namespace Assignment8
{
    class KeepInBounds : Component
    {
        int bounds;

        public KeepInBounds(int bounds)
        {
            this.bounds = bounds;
        }

        public override void Update()
        {
            if (Container.Position.X > bounds)
                Container.Position.X = bounds;
            if (Container.Position.X < 0)
                Container.Position.X = 0;
            if (Container.Position.Y > bounds)
                Container.Position.Y = bounds;
            if (Container.Position.Y < 0)
                Container.Position.Y = 0;
        }
    }
}

﻿namespace Assignment8
{
    class WrapAround : Component
    {
        int bounds;

        public WrapAround(int bounds)
        {
            this.bounds = bounds;
        }

        public override void Update()
        {
            if (Container.Position.X > bounds - 1)
                Container.Position.X = 0;
            if (Container.Position.X < 0)
                Container.Position.X = bounds - 1;
            if (Container.Position.Y > bounds - 1)
                Container.Position.Y = 0;
            if (Container.Position.Y < 0)
                Container.Position.Y = bounds - 1;
        }
    }
}
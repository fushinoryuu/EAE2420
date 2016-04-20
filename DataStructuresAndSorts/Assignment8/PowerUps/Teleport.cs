using System;

namespace Assignment8
{
    class Teleport : PowerUp
    {
        Entity Player;
        int Bounds;

        public Teleport(Entity player, int bounds)
        {
            Random RandInt = new Random();
            Player = player;
            Bounds = bounds;

            Name = "T";
            Position.X = RandInt.Next(0, bounds - 1);
            Position.Y = RandInt.Next(0, bounds - 1);
        }

        public override void Update()
        {
            if (StepedOn())
            {
                Player.Position.X = new Random().Next(0, Bounds);
                Player.Position.Y = new Random().Next(0, Bounds);
            }
        }

        private bool StepedOn()
        {
            if (Player.Position.X == Container.Position.X && 
                Player.Position.Y == Container.Position.Y)
                return true;
            return false;
        }
    }
}

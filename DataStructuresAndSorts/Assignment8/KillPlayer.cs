using System;

namespace Assignment8
{
    class KillPlayer : Component
    {
        Entity player;

        public KillPlayer(Entity player)
        {
            this.player = player;
        }

        public override void Update()
        {
            if (player.Position.X == Container.Position.X && player.Position.Y == Container.Position.Y)
            {
                Console.WriteLine("You dead");
                Environment.Exit(1);
            }
        }
    }
}
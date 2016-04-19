using System;

namespace Assignment8
{
    class KillOnContact : Component
    {
        Entity player;

        public KillOnContact(Entity player)
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
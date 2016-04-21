using System;

namespace Assignment8
{
    class KillOnContact : Component
    {
        Entity Player;

        public KillOnContact(Entity player)
        {
            Player = player;
        }

        public override void Update()
        {
            if (Player.Position.X == Container.Position.X && 
                Player.Position.Y == Container.Position.Y && 
                Player.Invulnerable == false)
            {
                Console.WriteLine("\n\nYOU DIED!!!");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(1);
            }

            else if(Player.Position.X == Container.Position.X &&
                Player.Position.Y == Container.Position.Y &&
                Player.Invulnerable == true)
            {
                Player.Invulnerable = false;
                Console.WriteLine("YOU HAVE USED UP YOUR INVULNERABILITY POWER UP, NEXT TIME YOU WILL DIE!");
            }
        }
    }
}
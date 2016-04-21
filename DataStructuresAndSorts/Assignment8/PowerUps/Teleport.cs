using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Teleport : PowerUp
    {
        Entity Player;
        int Bounds;
        List<PowerUp> PowerUpList;

        public Teleport(Entity player, int bounds, List<PowerUp> powerup_list)
        {
            Position = new Point();
            PowerUpList = powerup_list;
            Player = player;
            Bounds = bounds;

            Name = "T";
            IsVisible = true;
            Position.X = new Random().Next(0, bounds);
            Position.Y = new Random().Next(0, bounds);
        }

        public override void Update()
        {
            if (StepedOn() && IsVisible)
            {
                Console.WriteLine("\nYOU GOT TELEPORTED!");

                Player.Position.X = new Random().Next(0, Bounds);
                Player.Position.Y = new Random().Next(0, Bounds);

                IsVisible = false;
            }
        }

        private bool StepedOn()
        {
            if (Player.Position.X == Position.X && 
                Player.Position.Y == Position.Y)
                return true;
            return false;
        }
    }
}
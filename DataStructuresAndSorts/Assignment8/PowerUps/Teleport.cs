using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Teleport : PowerUp
    {
        Entity Player;
        Random Randomizer;
        int Bounds;
        List<PowerUp> PowerUpList;

        public Teleport(Entity player, int bounds, List<PowerUp> powerup_list, Random randomizer)
        {
            Position = new Point();
            PowerUpList = powerup_list;
            Player = player;
            Bounds = bounds;
            Randomizer = randomizer;

            Name = "T";
            IsVisible = true;
            Position.X = Randomizer.Next(0, Bounds);
            Position.Y = Randomizer.Next(0, Bounds);
        }

        public override void Update()
        {
            if (StepedOn() && IsVisible)
            {
                Console.WriteLine("\nYOU GOT TELEPORTED!");

                Player.Position.X = Randomizer.Next(0, Bounds);
                Player.Position.Y = Randomizer.Next(0, Bounds);

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
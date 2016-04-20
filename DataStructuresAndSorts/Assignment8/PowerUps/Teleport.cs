using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Teleport : PowerUp
    {
        Entity Player;
        int Bounds;
        List<Teleport> TeleportList;

        public Teleport(Entity player, int bounds, List<Teleport> teleport_list)
        {
            Random RandInt = new Random();
            Position = new Point();
            TeleportList = teleport_list;
            Player = player;
            Bounds = bounds;

            Name = "T";
            IsActive = true;
            Position.X = RandInt.Next(0, bounds - 1);
            Position.Y = RandInt.Next(0, bounds - 1);
        }

        public override void Update()
        {
            if (StepedOn())
            {
                Player.Position.X = new Random().Next(0, Bounds);
                Player.Position.Y = new Random().Next(0, Bounds);

                IsActive = false;
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
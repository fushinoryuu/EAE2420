﻿using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Entity
    {
        public Point Position { get; set; }
        List<Component> Components = new List<Component>();

        public Entity(int start_x, int start_y)
        {
            Position = new Point();
            Position.X = start_x;
            Position.Y = start_y;
        }

        public void AddComponent(Component new_component)
        {
            Components.Add(new_component);
            new_component.Container = this;
        }

        public void RemoveComponent()
        {

        }

        public void Update()
        {
            foreach (Component component in Components)
                component.Update();
            Console.WriteLine(Position);
        }
    }
}
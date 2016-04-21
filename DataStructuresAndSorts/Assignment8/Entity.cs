using System;
using System.Collections.Generic;

namespace Assignment8
{
    class Entity
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool Invulnerable { get; set; }
        Stack<Component> Components = new Stack<Component>();

        public Entity(Random randomizer, int bounds)
        {
            Position = new Point();
            Position.X = randomizer.Next(0, bounds);
            Position.Y = randomizer.Next(0, bounds);
        }

        public void AddComponent(Component new_component)
        {
            Components.Push(new_component);
            new_component.Container = this;
        }

        public void RemoveComponent()
        {
            Components.Pop();
        }

        public void Update()
        {
            foreach (Component component in Components)
                component.Update();
        }
    }
}
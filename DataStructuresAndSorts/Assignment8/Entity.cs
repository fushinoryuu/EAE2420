using System.Collections.Generic;

namespace Assignment8
{
    class Entity
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool Invulnerable { get; set; }
        Stack<Component> Components = new Stack<Component>();

        public Entity(int start_x, int start_y)
        {
            Position = new Point();
            Position.X = start_x;
            Position.Y = start_y;
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
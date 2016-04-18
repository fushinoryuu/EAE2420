using System.Collections.Generic;

namespace Assignment8
{
    class Entity
    {
        public Point Position { get; set; }
        List<Component> Components = new List<Component>();

        public Entity()
        {
            Position = new Point();
        }

        public void AddComponent(Component new_component)
        {
            Components.Add(new_component);
            new_component.Container = this;
        }

        public void Update()
        {
            foreach (Component component in Components)
                component.Update();
        }
    }
}
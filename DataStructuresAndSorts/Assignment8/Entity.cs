﻿using System.Collections.Generic;

namespace Assignment8
{
    class Entity
    {
        public Point Position { get; set; }
        List<Component> Components = new List<Component>();

        public void AddComponent(Component new_component)
        {
            Components.Add(new_component);
        }

        public void Update()
        {
            foreach (Component component in Components)
                component.Update();
        }
    }
}
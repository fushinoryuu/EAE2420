using System;

namespace Assignment5
{
    class Hero : IComparable<Hero>
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public int CompareTo(Hero other)
        {
            int result = Attack - other.Attack;
            if (result != 0)
                return result;

            result = Health - other.Health;
            if (result != 0)
                return result;

            result = Defense - other.Defense;
            if (result != 0)
                return result;

            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
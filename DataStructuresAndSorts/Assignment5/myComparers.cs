using System;
using System.Collections.Generic;

namespace Assignment5
{
    class HeroComparer : IComparer<Hero>
    {
        public int Compare(Hero left, Hero right)
        {
            int result = left.Attack - right.Attack;
            if (result != 0)
                return result;

            result = left.Health - right.Health;
            if (result != 0)
                return result;

            result = right.Defense - right.Defense;
            if (result != 0)
                return result;

            return left.Name.CompareTo(right.Name);
        }
    }

    class numberComparer : IComparer<int>
    {
        public int Compare(int left, int right)
        {
            return left - right;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Class_03_08
    {
        class Person : IComparable<Person>
        {
            public string name { get; set; }
            public int age { get; set; }
            public int weight { get; set; }

            public int CompareTo(Person other)
            {
                int result = age - other.age;

                if (result != 0)
                    return result;

                result = this.weight - other.weight;
                if (result != 0)
                    return result;

                return name.CompareTo(other.name);
            }
        }

        static void Mains()
        {
            BinarySearchTree<Person> people = new BinarySearchTree<Person>();
            Person jamie = new Person { name = "Jamie", age = 36, weight = 800 };
            Person nathan = new Person { name = "Nathan", age = 55, weight = 750 };

            if (jamie.CompareTo(nathan) < 0)
            {

            }
        }
    }
}

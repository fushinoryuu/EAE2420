using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    class MaxHeapTest<T> : Heap<T> where T : IComparable
    {
        public MaxHeapTest()
        {
            UnderlyingArray = new T[5];
        }
        
        public MaxHeapTest(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
        }

        public override void Add(T new_value)
        {
            throw new NotImplementedException();
        }

        public override T PopTop()
        {
            throw new NotImplementedException();
        }

        public override void Sort()
        {
            throw new NotImplementedException();
        }
    }
}

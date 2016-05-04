using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    class MinHeap<T> : Heap<T> where T : IComparable
    {
        public MinHeap(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
        }

        public MinHeap()
        {
            UnderlyingArray = new T[5];
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

        private void Swim()
        {
            throw new NotImplementedException();
        }

        private void Sink()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Assignment9
{
    class MaxHeap<T> where T : IComparable<T>
    {
        public HeapNode<T> Root = null;

        public MaxHeap()
        {

        }

        public void Add(T value)
        {
            AddHelper(value, Root);
        }

        private void AddHelper(T value, HeapNode<T> current)
        {
            if (Root == null)
                Root = new HeapNode<T> { Data = value };

            else
            {

            }
        }
    }
}
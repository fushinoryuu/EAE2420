using System;
using System.Collections.Generic;

namespace Assignment6
{
    class Heap<T> where T : IComparable<T>
    {
        public HeapNode<T> root;
        IComparer<T> compare;

        public Heap()
        {

        }

        public void Add(T newItem, HeapNode<T> currentNode)
        {

        }
    }
}

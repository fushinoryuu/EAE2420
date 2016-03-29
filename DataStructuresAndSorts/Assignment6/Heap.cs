using System;
using System.Collections.Generic;

namespace Assignment6
{
    class Heap<T> where T : IComparable<T>
    {
        public HeapNode<T> root;
        IComparer<T> compare;
        private T[] array;

        public Heap(int startingSize)
        {
            root = null;
            array = new T[startingSize];
        }

        public void Add(T newItem, HeapNode<T> currentNode)
        {

        }

        public T HeapMaximum()
        {
            throw new NotImplementedException();
        }
    }
}

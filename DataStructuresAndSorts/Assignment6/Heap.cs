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
            if (root == null)
            {
                root = new HeapNode<T> { Value = newItem };
                currentNode = root;
            }
            else
            {
                if (newItem.CompareTo(currentNode.Value) < 0)
                {

                }
            }
        }

        public T HeapMaximum()
        {
            throw new NotImplementedException();
        }
    }
}

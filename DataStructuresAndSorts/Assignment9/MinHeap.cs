using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    class MinHeap<T> : IEnumerable<T> where T : IComparable
    {
        private T[] UnderlyingArray;
        private int ElementCount = 0;
        private int OldCount = 0;
        private bool IsHeap = true;

        public MinHeap(int starting_size)
        {
            UnderlyingArray = new T[starting_size];
        }

        public MinHeap()
        {
            UnderlyingArray = new T[5];
        }

        public int Count
        {
            get
            {
                return ElementCount;
            }
        }

        public void Clear()
        {
            UnderlyingArray = new T[UnderlyingArray.Length];
        }

        public T this[int index]
        {
            get
            {
                return UnderlyingArray[index];
            }
        }

        public void Add(T new_value)
        {
            throw new NotImplementedException();
        }

        public T PopTop()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public void BuildHeap()
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

        private void Swap(int first, int second)
        {
            throw new NotImplementedException();
        }

        private int FindParent()
        {
            throw new NotImplementedException();
        }

        private int FindLeft()
        {
            throw new NotImplementedException();
        }

        private int FindRight()
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            T[] new_array = new T[UnderlyingArray.Length * 2];

            for (int index = 0; index < UnderlyingArray.Length; index++)
                new_array[index] = UnderlyingArray[index];

            UnderlyingArray = new_array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

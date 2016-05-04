using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment9
{
    abstract class Heap<T> : IEnumerable<T>
    {
        protected T[] UnderlyingArray;
        protected int ElementCount = 0;
        protected int OldCount = 0;
        protected bool IsHeap = true;

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

        abstract public void Add(T new_value);

        abstract public T PopTop();

        abstract public void Sort();

        public void BuildHeap()
        {
            if (IsHeap)
                return;

            int last_item = OldCount - 1;

            for (int index = 0; index < OldCount / 2; index++)
            {
                Swap(index, last_item);
                last_item--;
            }

            ElementCount = OldCount;
            IsHeap = true;
        }

        protected void Swap(int first, int second)
        {
            T temp = UnderlyingArray[first];
            UnderlyingArray[first] = UnderlyingArray[second];
            UnderlyingArray[second] = temp;
        }

        protected int FindParent(int current_index)
        {
            return (current_index - 1) / 2;
        }

        protected int FindLeft(int current_index)
        {
            return (current_index * 2) + 1;
        }

        protected int FindRight(int current_index)
        {
            return (current_index * 2) + 2;
        }

        protected void Resize()
        {
            T[] new_array = new T[UnderlyingArray.Length * 2];

            for (int index = 0; index < UnderlyingArray.Length; index++)
                new_array[index] = UnderlyingArray[index];

            UnderlyingArray = new_array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < ElementCount; index++)
            {
                T temp = UnderlyingArray[index];
                yield return temp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

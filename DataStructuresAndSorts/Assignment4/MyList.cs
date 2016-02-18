using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4
{
    class MyList<T> : IList<T>
    {
        public T[] underlyingArray;
        private int element_count;

        public MyList(int initial_size)
        {
            underlyingArray = new T[initial_size];
            this.element_count = 0;
        }

        // TODO Implement: Indexer
        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                return element_count;
            }
        }

        // TODO Implement: Read Only
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        // TODO Implement: Array Resize
        public void Add(T item)
        {
            if (element_count < this.underlyingArray.Length)
            {
                underlyingArray[element_count] = item;
                element_count++;
            }

            else
                throw new IndexOutOfRangeException();
        }

        // TODO Implement: Clear
        public void Clear()
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Contains
        public bool Contains(T item)
        {
            throw new NotImplementedException();
            //for (int index = 0; index < underlyingArray.Length; index++)
            //    if (underlyingArray[index] == item)
            //        return true;
            //return false;
        }

        // TODO Implement: Copy
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Get Enumerator
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Index of
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Insert
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Remove
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Remove at
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        // TODO Implement: Get IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
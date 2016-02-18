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
            this.underlyingArray = new T[initial_size];
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
                return this.element_count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.underlyingArray.IsReadOnly;
            }
        }
        
        // TODO Handle Exception
        public void Add(T item)
        {
            if (element_count < this.underlyingArray.Length)
            {
                this.underlyingArray[element_count] = item;
                this.element_count++;
            }

            else
                throw new IndexOutOfRangeException();
        }

        public void Clear()
        {
            this.element_count = 0;
        }

        public bool Contains(T item)
        {
            for (int index = 0; index < Count; index++)
            {
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item));
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            T[] newArray = new T[underlyingArray.Length * 2];
            while (arrayIndex < underlyingArray.Length)
            {
                newArray[arrayIndex] = underlyingArray[arrayIndex];
                arrayIndex++;
            }
            underlyingArray = newArray;
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
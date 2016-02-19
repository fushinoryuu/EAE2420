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
        
        public void Add(T item)
        {
            try
            {
                this.underlyingArray[element_count] = item;
                this.element_count++;
            }
            catch (IndexOutOfRangeException)
            {
                this.CopyTo(this.underlyingArray, 0);
                this.Add(item);
            }
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

        // TODO Fix CopyTo
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count == array.Length)
            {
                T[] newArray = new T[array.Length * 2];
                for (int index = arrayIndex; index < array.Length; index++)
                {
                    newArray[index] = array[index];
                }
                this.underlyingArray = newArray;
            }
            else
            {
                T temp = array[arrayIndex + 1];
                for (int index = arrayIndex; index < array.Length - 1; index++)
                {
                    array[index + 1] = array[index];
                    temp = array[index + 1];
                }
            }
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
            if (index >= this.Count)
                this.Add(item);
            else
            {
                this.CopyTo(this.underlyingArray, index);
                this.underlyingArray[index] = item;
            }
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
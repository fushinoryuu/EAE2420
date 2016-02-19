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
            element_count = 0;
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
            private set
            {
                element_count++;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return underlyingArray.IsReadOnly;
            }
        }
        
        public void Add(T item)
        {
            try
            {
                underlyingArray[element_count] = item;
                Count++;
            }
            catch (IndexOutOfRangeException)
            {
                Resize(underlyingArray);
                Add(item);
            }
        }

        public void Clear()
        {
            element_count = 0;
        }

        public void Resize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];
            for (int index = 0; index < array.Length; index++)
            {
                newArray[index] = array[index];
            }
            underlyingArray = newArray;
        }

        public bool Contains(T item)
        {
            for (int index = 0; index < Count; index++)
            {
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item))
                    return true;
            }
            return false;
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count == array.Length)
            {
                Resize(array);
            }
            
            for (int index = Count; index > arrayIndex; index--)
            {
                array[index] = array[index - 1];
            }
            underlyingArray = array;
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
        
        public void Insert(int index, T item)
        {
            if (Count == underlyingArray.Length)
            {
                Resize(underlyingArray);
            }
            if (index >= Count)
                Add(item);
            else
            {
                CopyTo(underlyingArray, index);
                underlyingArray[index] = item;
                element_count++;
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
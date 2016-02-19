using System;
using System.Collections;
using System.Collections.Generic;

// TODO Comment code
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

        public T this[int index]
        {
            get
            {
                return underlyingArray[index];
            }

            set
            {
                underlyingArray[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return element_count;
            }
        }

        private void UpdateCount(int amount)
        {
            element_count += amount;
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
                underlyingArray[Count] = item;
                UpdateCount(1);
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
                newArray[index] = array[index];

            underlyingArray = newArray;
        }

        public bool Contains(T item)
        {
            for (int index = 0; index < Count; index++)
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item))
                    return true;

            return false;
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count == array.Length)
                Resize(array);
            
            for (int index = Count; index > arrayIndex; index--)
                array[index] = array[index - 1];

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
                Resize(underlyingArray);
            if (index >= Count)
                Add(item);
            else
            {
                CopyTo(underlyingArray, index);
                underlyingArray[index] = item;
                UpdateCount(1);
            }
        }

        public bool Remove(T item)
        {
            for (int index = 0; index < Count; index++)
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item))
                {
                    RemoveAt(index);
                    return true;
                }
            return false;
        }

        public void RemoveAt(int index)
        {
            while (index < Count - 1)
            {
                underlyingArray[index] = underlyingArray[index + 1];
                index++;
            }
            UpdateCount(-1);
            underlyingArray[Count] = default(T);
        }

        // TODO Implement: Get IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
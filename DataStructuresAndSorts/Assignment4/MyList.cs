using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4
{
    // TODO Comment code
    class MyList<T> : IList<T>
    {
        public T[] underlyingArray;
        private int element_count;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="initial_size"></param>
        public MyList(int initial_size)
        {
            underlyingArray = new T[initial_size];
            element_count = 0;
        }


        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to get or set.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the number of elements contained in the list.
        /// </summary>
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

        /// <summary>
        /// Gets a value indicating whether the list is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return underlyingArray.IsReadOnly;
            }
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">The object to add to the list.</param>
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

        /// <summary>
        /// Removes all items from the list.
        /// </summary>
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

        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the list.</param>
        /// <returns></returns>
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
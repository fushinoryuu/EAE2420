using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4
{
    class MyList<T> : IList<T>
    {
        /// <summary>
        /// Global variables for the class.
        /// </summary>
        public T[] underlyingArray;
        private int element_count;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="initial_size">Sets the initial size of the array.</param>
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

        /// <summary>
        /// You can update the total count on the list.
        /// </summary>
        /// <param name="amount">Number to add to the count.</param>
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
            for (int index = 0; index < Count; index++)
                underlyingArray[index] = default(T);

            UpdateCount(-Count);
        }

        /// <summary>
        /// Doubles the size of the array for the list.
        /// </summary>
        /// <param name="array">Array to resize.</param>
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
        /// <returns>true if item is found in the list; otherwise, false.</returns>
        public bool Contains(T item)
        {
            for (int index = 0; index < Count; index++)
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item))
                    return true;
            return false;
        }

        /// <summary>
        /// Copies the elements of the list to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from list.</param>
        /// <param name="arrayIndex">The index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count == array.Length)
                Resize(array);
            
            for (int index = Count; index > arrayIndex; index--)
                array[index] = array[index - 1];

            underlyingArray = array;
        }

        // TODO Implement: Get Enumerator
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines the index of a specific item in the list.
        /// </summary>
        /// <param name="item">The object to locate in the list.</param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public int IndexOf(T item)
        {
            for (int index = 0; index < Count; index++)
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item))
                    return index;
            return -1;
        }

        /// <summary>
        /// Inserts an item to the list at the specified index.
        /// </summary>
        /// <param name="index">The index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the list.</param>
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

        /// <summary>
        /// Removes the first occurrence of a specific object from the list.
        /// </summary>
        /// <param name="item">The object to remove from the list.</param>
        /// <returns>true if item was successfully removed from the list; otherwise, false. 
        /// This method also returns false if item is not found in the list</returns>
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

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
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
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the list.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
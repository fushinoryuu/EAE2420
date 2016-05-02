using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4
{
    class MyList<T> : IList<T>
    {
        private T[] underlyingArray;
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
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                return underlyingArray[index];
            }

            set
            {
                if (index >= Count)
                    Add(value);
                else
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
            if (Count == underlyingArray.Length)
                Resize(underlyingArray);

            underlyingArray[Count] = item;
            UpdateCount(1);
        }

        public void Clear()
        {
            for (int index = 0; index < Count; index++)
                underlyingArray[index] = default(T);

            UpdateCount(-Count);
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

        public IEnumerator<T> GetEnumerator()
        {
            // WITH YIELD
            //for (int i = 0; i < underlyingArray.Length; i++)
            //    yield return underlyingArray[i];

            // WITHOUT YIELD
            return new myEnumerator(this);
        }

        private class myEnumerator : IEnumerator<T>
        {
            private MyList<T> myList;
            private int index;

            public myEnumerator(MyList<T> myList)
            {
                this.myList = myList;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return (index < myList.Count);
            }

            public T Current
            {
                get
                {
                    return myList[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            // Not Needed
            public void Dispose()
            {
                //Not Needed
            }

            public void Reset()
            {
                index = -1;
            }
        }

        public int IndexOf(T item)
        {
            for (int index = 0; index < Count; index++)
                if (EqualityComparer<T>.Default.Equals(underlyingArray[index], item))
                    return index;
            return -1;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new myEnumerator(this);
        }
    }
}
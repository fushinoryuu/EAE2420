using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment7
{
    class MyHashTable<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] BaseArray;
        private int ElementCount;

        public MyHashTable(int initial_size)
        {
            BaseArray = new LinkedList<KeyValuePair<TKey, TValue>>[initial_size];
            ElementCount = 0;
        }

        public MyHashTable()
        {
            BaseArray = new LinkedList<KeyValuePair<TKey, TValue>>[10];
            ElementCount = 0;
        }

        public TValue this[TKey key]
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
                return ElementCount;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
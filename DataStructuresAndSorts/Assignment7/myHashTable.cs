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

        // TODO Indexer
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

        // TODO ICollection<TKey>
        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // TODO ICollection<TValue>
        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // TODO Add
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        // TODO Add
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        // TODO Clear
        public void Clear()
        {
            throw new NotImplementedException();
        }

        // TODO Contains
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        // TODO ContainsKey
        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        // TODO CopyTo
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        // TODO IEnumerator
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // TODO Remove
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        // TODO Remove
        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        // TODO TryGetValue
        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
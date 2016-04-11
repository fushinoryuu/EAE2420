﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment7
{
    class MyHashTable<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] UnderlyingArray;
        private int ElementCount = 0;

        public MyHashTable(int initial_size)
        {
            UnderlyingArray = new LinkedList<KeyValuePair<TKey, TValue>>[initial_size];
        }

        public MyHashTable()
        {
            UnderlyingArray = new LinkedList<KeyValuePair<TKey, TValue>>[7];
        }

        // TODO Indexer
        public TValue this[TKey key]
        {
            get
            {
                int bucket = Hash(key);

                if (UnderlyingArray[bucket] == null)
                {
                    throw new KeyNotFoundException();
                }

                foreach (KeyValuePair<TKey, TValue> pair in UnderlyingArray[bucket])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
                throw new KeyNotFoundException();
            }

            set
            {
                int bucket = Hash(key);

                if (UnderlyingArray[bucket] == null)
                    UnderlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();

                if (UnderlyingArray[bucket].Count == 0)
                    UnderlyingArray[bucket].AddFirst(new KeyValuePair<TKey, TValue>(key, value));

                else
                {
                    foreach (KeyValuePair<TKey, TValue> pair in UnderlyingArray[bucket])
                    {
                        
                    }
                }
            }
        }

        private int Hash(TKey key)
        {
            int hash = key.GetHashCode();
            return hash % UnderlyingArray.Length;
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

        public void Clear()
        {
            UnderlyingArray = new LinkedList<KeyValuePair<TKey, TValue>>[7];
            ElementCount = 0;
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
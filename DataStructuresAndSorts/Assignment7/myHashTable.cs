using System;
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
                int bucket = FindEntry(key);

                if (UnderlyingArray[bucket] == null)
                    throw new KeyNotFoundException();

                foreach (KeyValuePair<TKey, TValue> pair in UnderlyingArray[bucket])
                    if (pair.Key.Equals(key))
                        return pair.Value;

                throw new KeyNotFoundException();
            }

            set
            {
                int bucket = FindEntry(key);

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

        private bool InList(LinkedList<KeyValuePair<TKey, TValue>> list, TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> pair in list)
                if (pair.Key.Equals(key))
                    return true;
            return false;
        }

        private int FindEntry(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
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
            int bucket = FindEntry(item.Key);

            if (UnderlyingArray[bucket] == null)
                UnderlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();

            if (UnderlyingArray[bucket].Count == 0)
                UnderlyingArray[bucket].AddFirst(new KeyValuePair<TKey, TValue>(item.Key, item.Value));

            else
            {
                foreach (KeyValuePair<TKey, TValue> pair in UnderlyingArray[bucket])
                {

                }
            }
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

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            for (int index = 0; index < UnderlyingArray.Length; index++)
                if (UnderlyingArray[index] != null)
                {
                    LinkedList<KeyValuePair<TKey, TValue>> list = UnderlyingArray[index];
                    foreach (KeyValuePair<TKey, TValue> pair in list)
                        if (pair.Key.Equals(item.Key) && pair.Value.Equals(item.Value))
                            return true;
                }
            return false;
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

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int index = 0; index < UnderlyingArray.Length; index++)
                if (UnderlyingArray[index] != null)
                {
                    LinkedList<KeyValuePair<TKey, TValue>> list = UnderlyingArray[index];
                    foreach (KeyValuePair<TKey, TValue> pair in list)
                        yield return pair;
                }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            for ( int index = 0; index < UnderlyingArray.Length; index++)
                foreach (KeyValuePair<TKey, TValue> pair in UnderlyingArray[index])
                    if (pair.Value.Equals(item))
                    {
                        UnderlyingArray[index].Remove(item);
                        return true;
                    }
            return false;
        }

        // TODO Remove
        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int bucket = FindEntry(key);

            if (UnderlyingArray[bucket] == null)
            {
                value = default(TValue);
                return false;
            }

            foreach (KeyValuePair<TKey, TValue> pair in UnderlyingArray[bucket])
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }

            value = default(TValue);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
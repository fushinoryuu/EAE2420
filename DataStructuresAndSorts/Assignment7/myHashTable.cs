using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment7
{
    class MyHashTable<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] BaseArray;
        private int ElementCount = 0;

        public MyHashTable()
        {
            BaseArray = new LinkedList<KeyValuePair<TKey, TValue>>[5];
        }

        public TValue this[TKey key]
        {
            get
            {
                int bucket = GetHash(key);

                if (BaseArray[bucket] == null)
                    throw new KeyNotFoundException();

                foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
                    if (pair.Key.Equals(key))
                        return pair.Value;

                throw new KeyNotFoundException();
            }

            set
            {
                Insert(key, value, false);
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
                List<TKey> list = new List<TKey>(Count);
                for (int bucket = 0; bucket < BaseArray.Length; bucket++)
                    if (BaseArray[bucket] != null)
                        foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
                            list.Add(pair.Key);
                return list;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> list = new List<TValue>(Count);
                for (int bucket = 0; bucket < BaseArray.Length; bucket++)
                    if (BaseArray[bucket] != null)
                        foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
                            list.Add(pair.Value);
                return list;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Insert(item.Key, item.Value, true);
        }

        public void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }

        private void Insert(TKey key, TValue value, bool add)
        {
            if (GetRatio() > .75)
                Resize();

            int bucket = GetHash(key);

            if (BaseArray[bucket] == null)
            {
                BaseArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
                BaseArray[bucket].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
                ElementCount++;
                return;
            }

            LinkedList<KeyValuePair<TKey, TValue>> list = BaseArray[bucket];

            for (LinkedListNode<KeyValuePair<TKey, TValue>> pair = list.First; pair != null; pair = pair.Next)
            {
                if (pair.Value.Key.Equals(key) && add)
                {
                    throw new ArgumentException("An item with the same key has already been added.");
                }

                else if (pair.Value.Key.Equals(key) && !add)
                {
                    list.Remove(pair);
                    list.AddLast(new KeyValuePair<TKey, TValue>(key, value));
                    return;
                }
            }
            BaseArray[bucket].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            ElementCount++;
        }

        private int GetNextPrime()
        {
            bool skipped = false;

            for (int i = BaseArray.Length + 2; i < 1000; i += 2)
            {
                bool prime = IsPrime(i);
                if (prime == true && skipped == true)
                    return i;
                else if (prime && !skipped)
                    skipped = true;
            }
            return (2 * BaseArray.Length) + 1;
        }

        private bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
                if (candidate == 2)
                    return true;
                else
                    return false;
                
            for (int i = 3; (i * i) <= candidate; i += 2)
                if ((candidate % i) == 0)
                    return false;
            return candidate != 1;
        }
        
        private void Resize()
        {
            LinkedList<KeyValuePair<TKey, TValue>>[] old_array = BaseArray;
            LinkedList<KeyValuePair<TKey, TValue>>[] new_array = new LinkedList<KeyValuePair<TKey, TValue>>[GetNextPrime()];
            BaseArray = new_array;
            ElementCount = 0;

            for (int index = 0; index < old_array.Length; index++)
                if (old_array[index] != null)
                    foreach (KeyValuePair<TKey, TValue> pair in old_array[index])
                        Add(pair);
        }

        public void Clear()
        {
            BaseArray = new LinkedList<KeyValuePair<TKey, TValue>>[5];
            ElementCount = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            for (int index = 0; index < BaseArray.Length; index++)
                if (BaseArray[index] != null)
                {
                    LinkedList<KeyValuePair<TKey, TValue>> list = BaseArray[index];
                    foreach (KeyValuePair<TKey, TValue> pair in list)
                        if (pair.Key.Equals(item.Key) && pair.Value.Equals(item.Value))
                            return true;
                }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            var temp = Keys;

            foreach (TKey entry in temp)
                if (entry.Equals(key))
                    return true;
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            // Not needed.
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int index = 0; index < BaseArray.Length; index++)
                if (BaseArray[index] != null)
                {
                    LinkedList<KeyValuePair<TKey, TValue>> list = BaseArray[index];
                    foreach (KeyValuePair<TKey, TValue> pair in list)
                        yield return pair;
                }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            for (int index = 0; index < BaseArray.Length; index++)
                foreach (KeyValuePair<TKey, TValue> pair in BaseArray[index])
                    if (pair.Equals(item)) //(pair.Value.Equals(item))
                    {
                        BaseArray[index].Remove(item);
                        return true;
                    }
            return false;
        }

        public bool Remove(TKey key)
        {
            int index = GetHash(key);

            if (BaseArray[index] == null)
                return false;

            foreach (KeyValuePair<TKey, TValue> pair in BaseArray[index])
                if (pair.Key.Equals(key))
                {
                    BaseArray[index].Remove(pair);
                    return true;
                }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int bucket = GetHash(key);

            if (BaseArray[bucket] == null)
            {
                value = default(TValue);
                return false;
            }

            foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
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

        private bool InList(LinkedList<KeyValuePair<TKey, TValue>> list, TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> pair in list)
                if (pair.Key.Equals(key))
                    return true;
            return false;
        }

        private int GetHash(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return hash % BaseArray.Length;
        }

        private double GetRatio()
        {
            double ratio = (double)ElementCount / (double)BaseArray.Length;
            return ratio;
        }
    }
}
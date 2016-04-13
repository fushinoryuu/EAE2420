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

        // TODO Indexer
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
                int bucket = GetHash(key);

                if (BaseArray[bucket] == null)
                    BaseArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();

                if (BaseArray[bucket].Count == 0)
                {
                    BaseArray[bucket].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
                    ElementCount++;
                }

                else
                {
                    foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
                    {
                        if (pair.Value.Equals(value))
                        {
                            Console.WriteLine("They are equal");
                            return;
                        }
                    }
                    BaseArray[bucket].AddLast(new KeyValuePair<TKey, TValue>(key, value));
                    ElementCount++;
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

        private int GetHash(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return hash % BaseArray.Length;
        }

        private double GetRatio()
        {
            return ElementCount / BaseArray.Length;
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
                List<TKey> ret = new List<TKey>(Count);
                for (int bucket = 0; bucket < BaseArray.Length; bucket++)
                    if (BaseArray[bucket] != null)
                        foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
                            ret.Add(pair.Key);
                return ret;
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

        // TO DO Fix
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (GetRatio() > .75)
                Resize();

            int bucket = GetHash(item.Key);

            if (BaseArray[bucket] == null)
                BaseArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();

            if (BaseArray[bucket].Count == 0)
                BaseArray[bucket].AddFirst(new KeyValuePair<TKey, TValue>(item.Key, item.Value));

            else
            {
                foreach (KeyValuePair<TKey, TValue> pair in BaseArray[bucket])
                {
                    if (pair.Equals(item) == true)
                    {
                        Console.WriteLine("This item is alread in the dictionary. Key: {0} - Value: {0}\n", item.Key, item.Value);
                        return;
                    }
                }
                BaseArray[bucket].AddLast(item);
                ElementCount++;
            }
        }

        // TODO Add
        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public int GetNextPrime()
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

        public bool IsPrime(int candidate)
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
            BaseArray = new LinkedList<KeyValuePair<TKey, TValue>>[7];
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

        // TODO ContainsKey
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
                    if (pair.Value.Equals(item))
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
    }
}
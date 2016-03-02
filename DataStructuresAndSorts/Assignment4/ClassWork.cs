using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment4
{
    class Node<T>
    {
        public Node<T> Next { get; set; }

        public T value { get; set; }

        public static implicit operator Node<T>(Node<int> v)
        {
            throw new NotImplementedException();
        }
    }

    class LinkedList : IEnumerable<int>
    {
        Node<int> head;

        public LinkedList()
        {
            head = new Node<int> { value = 5 };
            head.Next = new Node<int> { value = 7 };
            head.Next.Next = new Node<int> { value = 2 };
        }

        // No Yield
        private class myEnumerator : IEnumerator<int>
        {
            Node<int> runner;
            bool started = false;

            public myEnumerator(LinkedList theList)
            {
                runner = theList.head;
            }

            public bool MoveNext()
            {
                if (started && runner != null)
                    runner = runner.Next;
                started = true;
                return runner != null;
            }

            public int Current
            {
                get
                {
                    return runner.value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                //Nothing
            }
            
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new myEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class MainClass
    {
        static void Mains()
        {
            LinkedList meList = new LinkedList();

            foreach (int value in meList)
                Console.WriteLine(value);
        }
    }


    //// Old fashion way
    //class ClassWork : IEnumerable<int>
    //{
    //    public IEnumerator<int> GetEnumerator()
    //    {
    //        Console.WriteLine("Getting enumerator");
    //        yield return 5;
    //        Console.WriteLine("Rate 1");
    //        yield return 7;
    //        Console.WriteLine("Rate 2");
    //        yield return 2;
    //        Console.WriteLine("Rate 3");
    //    }

    //    //public IEnumerator<int> GiveEnumerator()
    //    //{
    //    //    yield return 5;
    //    //    yield return 7;
    //    //    yield return 2;
    //    //}

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}

    //class MainClass
    //{
    //    static void Main()
    //    {
    //        //ClassWork meList = new ClassWork();
    //        //IEnumerator<int> rator = meList.GetEnumerator();
    //        //while (rator.MoveNext())
    //        //    Console.WriteLine(rator.Current);

    //        //foreach (int value in meList)
    //        //    Console.WriteLine(value);

    //        ClassWork meList = new ClassWork();
    //        IEnumerator<int> rator1 = meList.GetEnumerator();
    //        IEnumerator<int> rator2 = meList.GetEnumerator();

    //        rator1.MoveNext();
    //        rator1.MoveNext();

    //        rator2.MoveNext();

    //        Console.WriteLine(rator1.Current);
    //        Console.WriteLine(rator2.Current);
    //    }
    //}
}

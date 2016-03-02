using System;
using System.Diagnostics;
using System.IO;

namespace Assignment4
{
    class RunningTimes
    {
        public static void SortPlot(ISorter sorter, int elements, string name)
        {
            Random randint = new Random();
            Stopwatch watch = new Stopwatch();
            StreamWriter file = new StreamWriter(@"ChristianMunoz_RunningTimes.txt", true);
            long time = watch.ElapsedMilliseconds;
            int[] list;

            while(elements > 0)
            {
                list = new int[elements];

                for (int i = 0; i < list.Length; i++)
                    list[i] = randint.Next(1, 200);

                if (name == "Merge Sort")
                {
                    watch.Reset();
                    watch.Start();
                    sorter.sort(list, 0, list.Length - 1);
                    watch.Stop();
                    time = watch.ElapsedMilliseconds;
                    Console.WriteLine("Sort: {0}, Element count: {1}, Time in Milliseconds: {2}", name, elements, time);
                }

                else
                {
                    watch.Reset();
                    watch.Start();
                    sorter.sort(list, 0, list.Length);
                    watch.Stop();
                    time = watch.ElapsedMilliseconds;
                    Console.WriteLine("Sort: {0}, Element count: {1}, Time in Milliseconds: {2}", name, elements, time);
                }

                file.WriteLine("Sort: {0}, Element count: {1}, Time in Milliseconds: {2}", name, elements, time);

                elements -= 10000;
            }
            Console.WriteLine(" ");
            file.WriteLine(" ");
            file.Close();
        }
    }
}
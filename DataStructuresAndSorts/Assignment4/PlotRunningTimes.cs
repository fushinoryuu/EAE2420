using System;
using System.Diagnostics;

namespace Assignment4
{
    class RunningTimes
    {
        public static void SortPlot(ISorter sorter, int elements)
        {
            Random randint = new Random();
            Stopwatch watch = new Stopwatch();

            int[] list;

            while(elements > 0)
            {
                list = new int[elements];

                for (int i = 0; i < list.Length; i++)
                    list[i] = randint.Next(1, 100);

                watch.Reset();
                watch.Start();
                sorter.sort(list, 0, list.Length);
                watch.Stop();
                double time = watch.ElapsedMilliseconds;
                Console.WriteLine(time);

                elements = elements - 10000;
            }
        }
    }
}

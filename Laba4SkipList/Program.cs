using SkipListLibrary;
using System.Diagnostics;

namespace Laba4SkipList
{

    class SpeedTester
    {
        private const int n = 1000000;
        private const int firstDeleteIndex = 5000;
        private const int lastDeleteIndex = 7000;
        private readonly int[] randomNumsArray = new int[n];
        public SpeedTester()
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                randomNumsArray[i] = rnd.Next();
            }
        }

        private long GetSkipListTime()
        {
            SkipList<int, int> skipList = new SkipList<int, int>();
            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            for (int i = 0; i < n; i++)
            {
                skipList.Add(i, i);
            }
            for (int i = firstDeleteIndex; i < lastDeleteIndex; i++)
            {
                skipList.Remove(i);
            }
            for (int i = 0; i < n; i++)
            {
                skipList.Contains(i);
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        private long GetSortedListTime()
        {
            SortedList<int, int> sortedList = new SortedList<int, int>();
            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
            for (int i = 0; i < n; i++)
            {
                sortedList.Add(i, i);
            }
            for (int i = firstDeleteIndex; i < lastDeleteIndex; i++)
            {
                sortedList.Remove(i);
            }
            for (int i = 0; i < n; i++)
            {
                sortedList.TryGetValue(i, out int temp);
            }
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        public void PrintTest()
        {
            Console.WriteLine("SkipList Time: " + GetSkipListTime());
            Console.WriteLine("SortedList Time: " + GetSortedListTime());
            //Console.WriteLine("SkipList Time: " + GetSkipListTime());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SpeedTester speedTester = new SpeedTester();
            speedTester.PrintTest();

        }
    }
}
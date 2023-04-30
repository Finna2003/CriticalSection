using System;
using System.Threading;
using System.Diagnostics;

namespace CriticalSection
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int t = Convert.ToInt32(Console.ReadLine());
            Thread[] threads = new Thread [t];

            Stopwatch sw = new Stopwatch();//--------------------время- доделать
            sw.Start();
            for (int i=0; i< t; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(IterL));
            }

            for (int i = 0; i < t; i++)
            {
                threads[i].Start(x);
            }
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

        }

        public static void IterL(object X)
        {
            int x = (Int32)X;

            lock (locker)
            {
                for(int i=0; i< 10; i++)
                {
                    ++x;
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  " + x);
                }
            }
        }

        public static void IterWL(object X)
        {
            int x = (Int32)X;
            
                for (int i = 0; i < 10; i++)
                {
                    ++x;
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  " + x);
                }
            

        }

    }
}

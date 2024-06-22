using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemApp_5
{
    internal class Program
    {
        static Mutex mutex = new Mutex(false);
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            Console.WriteLine("Start Threads");
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Calculate);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(Calculate);
            //}


            Console.WriteLine($"Result X = {SharedResource.X}, Y = {SharedResource.Y}");

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        static object objLocker = new object();
        static void Calculate(object state = null)
        {
            mutex.WaitOne();
            Console.WriteLine($"Start Thread #{Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 1000000; i++)
            {
                // 1. Interlocked
                //Interlocked.Increment(ref SharedResource.X);
                //if(SharedResource.X % 4 == 0)
                //{
                //    Interlocked.Increment(ref SharedResource.Y);
                //}

                // 2. Monitor
                // Monitor.Enter(this);
                // Monitor.Enter(typeof(StaticClass));
                // Monitor.Enter(objLocker);

                //Monitor.Enter(objLocker);
                //try
                //{
                //    SharedResource.X++;
                //    if (SharedResource.X % 4 == 0)
                //        SharedResource.Y++;
                //}
                //finally
                //{
                //    Monitor.Exit(objLocker);
                //}

                // 3. lock(objLocker)
                //lock (objLocker)
                //{
                //    SharedResource.X++;
                //    if (SharedResource.X % 4 == 0)
                //        SharedResource.Y++;
                //}

                // 4. Mutex

                SharedResource.X++;
                if (SharedResource.X % 4 == 0)
                    SharedResource.Y++;

               
            }
            mutex.ReleaseMutex();
            Console.WriteLine($"End Thread #{Thread.CurrentThread.ManagedThreadId}");
        }
    }


    

    static public class SharedResource
    {
        public static int X = 0;
        public static int Y = 0;
    }
}

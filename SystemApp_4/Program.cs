using System;
using System.Text;

namespace SystemApp_4
{
    internal class Program
    {
        static Random random = new Random();

        static byte[] buffer = new byte[500];
        static void Main(string[] args)
        {
            //ShowThredPool();

            //Test1();

            //TestAsync();

            TestAsync2();

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        static void TestAsync2()
        {
            Action<object> action = Factorial;

            for (int i = 0; i < 10; i++)
            {
                action.BeginInvoke(random.Next(5, 10), FactorialCallback, null);
            }
        }

        private static void FactorialCallback(IAsyncResult ar)
        {
            Console.WriteLine($"End Callback Thread #{Thread.CurrentThread.ManagedThreadId}");
        }


        static void TestAsync()
        {
            FileStream fs = new FileStream(@"..//..//..//Program.cs", FileMode.Open, FileAccess.Read, FileShare.Read, 500, FileOptions.Asynchronous);
            
            IAsyncResult ar = fs.BeginRead(buffer,0, buffer.Length, ReadIsComplete, fs);
            //

        }


        static void ReadIsComplete(IAsyncResult ar)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            FileStream fs = ar.AsyncState as FileStream;
            fs.EndRead(ar);
            fs.Close();
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
        }

        static void Test1()
        {
            Console.WriteLine("Test Pool");
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(Factorial, random.Next(5, 10));
            }
        }

        static void Factorial(object x)
        {
            Console.WriteLine($"Start Thread #{Thread.CurrentThread.ManagedThreadId}");
            int n = (int)x;
            int f = 1;
            for (int i = 1; i < n; i++)
            {
                f *= i;
            }
            Console.WriteLine($"End Thread #{Thread.CurrentThread.ManagedThreadId} - {n}! = {f}");
        }


        static void ShowThredPool()
        {
            ThreadPool.GetMaxThreads(out int wt, out int ct);
            Console.WriteLine($"Max Worker Threads {wt}, Completion PortThreads {ct}");

            ThreadPool.GetMinThreads(out wt, out ct);
            Console.WriteLine($"Min Worker Threads {wt}, Completion PortThreads {ct}");

            ThreadPool.GetAvailableThreads(out wt, out ct);
            Console.WriteLine($"Available Worker Threads {wt}, Completion PortThreads {ct}");
        }
    }

        
    }

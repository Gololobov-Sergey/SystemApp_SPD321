namespace SystemApp_4
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            //ShowThredPool();

            Console.WriteLine("Test Pool");
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Factorial, random.Next(5, 10));
            }

        }

        static void Test1()
        {
            Console.WriteLine("Test Pool");
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Factorial, random.Next(5, 10));
            }
        }

        static void Factorial(object x)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Start Thread #{Thread.CurrentThread.ManagedThreadId}");
            int n = (int)x;
            int f = 1;
            for (int i = 1; i < n; i++)
            {
                f *= i;
                Thread.Sleep(100);
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

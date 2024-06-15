namespace SystemApp_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread t = Thread.CurrentThread;
            //Console.WriteLine(t.ManagedThreadId);
            //Console.WriteLine(t.Name);
            //Console.WriteLine(t.Priority);
            //Console.WriteLine(t.ThreadState);
            //Console.WriteLine(Thread.GetDomain().FriendlyName);


            //Thread thread = new Thread(new ThreadStart(Count)); 
            //thread.Start();
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine($"Main thread - {i * i}");
            //    Thread.Sleep(300);
            //}



            //Thread thread = new Thread(new ParameterizedThreadStart(Factorial));
            //thread.Start(20);
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine($"Main thread - {i * i}");
            //    //Thread.Sleep(200);
            //}


            //Random random = new Random();

            //Console.WriteLine("Created Threads");
            //Thread[] threads = new Thread[10];
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(Summ);
            //    threads[i].Name = $"Thread {i + 1}";
            //    threads[i].IsBackground = true;
            //}

            //Console.WriteLine("Start Threads");
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start(10);
            //}

            //Console.WriteLine("Main Thread");

            //Console.WriteLine(sum);

            Timer timer = new Timer(getTime);
            timer.Change(0, 1000);

            while(true)
            {
                var c = Console.ReadKey();
                Console.WriteLine(c);
            }
            //Console.ReadKey();

        }

        static void getTime(object obj)
        {
            Console.SetCursorPosition(80, 0);
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        static int sum = 0;


        static void Factorial(object x) 
        {
            int n = (int)x;
            int f = 1;
            for (int i = 1; i < n; i++)
            {
                f *= i;
            }
            Console.WriteLine($"\t\t\tSecond thread - {n}! = {f}");
        }

        static void Count()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"\t\t\tSecond thread - {i*i}");
                Thread.Sleep(500);
            }
        }

        static void Summ(object x)
        {
            int n = (int)x;
            int s = 0;
            for (int i = 1; i <= n; i++)
            {
                s += i;
            }

            sum += s;
        }
    }


    public class Generetor
    {
        public int MinValue { get; set; } = 0;
        public int MaxValue { get; set; } = 9;

        public void Generete()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            //TestAsync2();

            TestAsync3();


            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }


        #region AsyncTest2
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
        #endregion

        #region AsyncTest3

        public delegate int FactorialDelegate(int n);

        static int FactorialInt(int n)
        {
            Thread.CurrentThread.Name = n.ToString();
            Console.WriteLine($"Start Thread #{Thread.CurrentThread.ManagedThreadId}");
            int f = 1;
            for (int i = 1; i < n; i++)
            {
                f *= i;
            }
            //Console.WriteLine($"End Thread #{Thread.CurrentThread.ManagedThreadId} - {n}! = {f}");
            return f;
        }

        private static void FactorialIntCallback(IAsyncResult ar)
        {
            FactorialDelegate fact =  ar.AsyncState as FactorialDelegate;
            if(fact == null)
            {
                Console.WriteLine("End Callback, result = null");
            }
            else
            {
                int res = fact.EndInvoke(ar);
                Console.WriteLine($"End Callback Thread #{Thread.CurrentThread.ManagedThreadId} {Thread.CurrentThread.Name}! = {res}");
            }
            
        }


        private static void TestAsync3()
        {
            FactorialDelegate factorial = FactorialInt;
            for (int i = 0; i < 10; i++)
            {
                factorial.BeginInvoke(random.Next(5, 10), FactorialIntCallback, factorial);
            }
        }

        #endregion
    }
}

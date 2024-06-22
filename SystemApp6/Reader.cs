using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemApp6
{
    public class Reader
    {
        static Semaphore semaphore = new Semaphore(3, 3);

        Thread thread;

        int count = 3;

        public Reader(int i, bool starInitial = true)
        {
            thread = new Thread(Read);
            thread.IsBackground = true;
            thread.Name = "Reader " + i.ToString();
            if (starInitial)
            {
                thread.Start();
            }
        }

        private void Read()
        {
            while (count > 0)
            {
                semaphore.WaitOne();
                Console.WriteLine($"{thread.Name} enter library");
                Console.WriteLine($"{thread.Name} read book");
                Thread.Sleep(2000);
                Console.WriteLine($"{thread.Name} exit library");
                semaphore.Release();
                count--;
                Thread.Sleep(1000);
            }
        }
    }
}

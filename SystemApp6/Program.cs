using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 6; i++)
            {
                new Reader(i + 1);
            }

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}

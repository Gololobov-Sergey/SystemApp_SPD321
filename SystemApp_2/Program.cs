using System.Diagnostics;
using System.Reflection;
using Student;
using ConsoleMenu;

namespace SystemApp_2
{
    internal class Program
    {

        static void PrintAllProcess()
        {
            var process = Process.GetProcesses();

            Process pCalc = null;

            foreach (var p in process)
            {
                try
                {
                    if (p.ProcessName == "CalculatorApp")
                    {
                        pCalc = p;
                    }
                    Console.WriteLine($"{p.Handle}\t{p.Id}\t{p.ProcessName}\t{p.Threads.Count}");
                }
                catch (Exception)
                {
                    Console.WriteLine($"{p.ProcessName}");
                }

            }

            //foreach (var p in process)
            //{
            //    if(p.ProcessName == "CalculatorApp")
            //    {
            //        Console.WriteLine("Press any key for kill Calc...");
            //        Console.ReadKey();
            //        p.Kill();
            //    }
            //}

            pCalc.WaitForExit();
            Console.WriteLine("Calc exit");


        }

        static void Main(string[] args)
        {
            //PrintAllProcess();

            //Process pCalc = Process.Start("calc.exe");

            //ProcessStartInfo pInfo = new ProcessStartInfo();
            //pInfo.FileName = "notepad.exe";
            //pInfo.Arguments = "ddd.txt";
            //Process.Start(pInfo);

            

            Assembly assembly = Assembly.LoadFrom("Student.dll");
            Module module = assembly.GetModule("Student.dll");
            Console.WriteLine("Types:");
            List<string> types = new List<string>(); 
            foreach (Type t in module.GetTypes())
            {
                Console.WriteLine(t.FullName);
                types.Add(t.FullName);  
            }
            int indType = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, types.ToArray());

            Type st = module.GetType(types[indType]) as Type;
            object s = Activator.CreateInstance(st, new object[] {"Name1", "Name2", DateTime.Now});
            List<string> metod = new List<string>();
            foreach (MethodInfo item in st.GetMethods())
            {
                metod.Add(item.Name);
            }
            int indMethod = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, metod.ToArray());
            st.GetMethod(metod[indMethod]).Invoke(s, null);


        }
    }
}

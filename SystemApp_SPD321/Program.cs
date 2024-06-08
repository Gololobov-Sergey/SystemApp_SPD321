using SystemApp_SPD321_1;

namespace SystemApp_SPD321
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int res = ExtFunc.MessageBox(IntPtr.Zero, "Hello C#", "C# System", ExtFunc.MB_OKCANCEL | ExtFunc.MB_ICONQUESTION);
            Console.WriteLine("You press: " + res.ToString());

            string title = Console.ReadLine();
            IntPtr hwnd = ExtFunc.FindWindowByCaption(IntPtr.Zero, title);
            if (hwnd != IntPtr.Zero)
            {
                ExtFunc.ShowWindow(hwnd, 3);
                Console.ReadKey();
                ExtFunc.ShowWindow(hwnd, 6);
                Console.ReadKey();
                ExtFunc.ShowWindow(hwnd, 1);
                Console.ReadKey();
                ExtFunc.ShowWindow(hwnd, 5);
                Console.ReadKey();

            }
            
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace MoveWindowsTerminal
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
            var x = -8;
            var y = 0;
            var w = 1936;
            var h = 1087;

            if (args.Length == 4)
            {
                x = int.Parse(args[0]);
                y = int.Parse(args[1]);
                w = int.Parse(args[2]);
                h = int.Parse(args[3]);
            }

            var processes = Process.GetProcessesByName("WindowsTerminal"); // Windows Terminal のプロセス名
            var proc = processes.FirstOrDefault();
            if (proc == null)
            {
                return;
            }

            IntPtr handle = proc.MainWindowHandle;
            MoveWindow(handle, x, y, w, h, true);
            SetForegroundWindow(handle);
        }
    }
}
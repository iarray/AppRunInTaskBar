using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;

namespace 程序嵌于任务栏
{
    class TaskbarApp:IDisposable
    {
        private IntPtr hBar;
        private IntPtr hMin;
        private IntPtr hWnd;
        private Rect rBar, rMin;
        private Timer timer=new Timer();
        private System.Windows.Window w;
        public TaskbarApp(System.Windows.Window wnd)
        {
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 1;
            this.w = wnd;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            w.Dispatcher.BeginInvoke(new System.Threading.ThreadStart(() =>
            {
                MoveWindow(hMin, (int)w.Width + 16, 0, rMin.Right - rMin.Left - (int)w.Width, rMin.Bottom - rMin.Top, true);
            }), null);
        
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //获取窗口句柄传递键盘消息
        [DllImport("USER32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //查找子窗体
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public void EmbedTaskbar()
        {
            IntPtr taskbar = FindWindow("Shell_TrayWnd", null);
            hBar = FindWindowEx(taskbar, IntPtr.Zero, "ReBarWindow32", null);
            hMin = FindWindowEx(hBar, IntPtr.Zero, "MSTaskSwWClass", null);
            hWnd = new System.Windows.Interop.WindowInteropHelper(w).Handle;

            GetWindowRect(hBar, out rBar);
            GetWindowRect(hMin, out rMin);
            w.Height = rMin.Bottom - rMin.Top;
            MoveWindow(hMin, (int)w.Width + 16, 0, rMin.Right - rMin.Left - (int)w.Width, rMin.Bottom - rMin.Top, true);
            MoveWindow(hWnd, 5, 0, (int)w.Width, (int)w.Height, true);
            SetParent(hWnd, hBar);
            if (timer.Enabled == false)
                timer.Start();
        }

        public void Reduction()
        {
            MoveWindow(hMin, 0, 0, rMin.Right - rMin.Left, rMin.Bottom - rMin.Top, true);
        }

        public void Dispose()
        {
            if (timer.Enabled == true)
                timer.Stop();
            timer.Dispose();
            Reduction();
        }
    }
}

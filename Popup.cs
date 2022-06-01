using System;
using System.Runtime.InteropServices;

namespace BSS_WindowsUtilities
{
    /// <summary>
    /// A class for creating a Windows Popup Dialog |
    /// For more info see: <see>https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox</see>
    /// </summary>
    public static class Popup
    {
        /// <summary>
        /// Dialog Icons
        /// </summary>
        public struct Icons
        {
            public static long ERROR = 0x00000010L;
            public static long QUERY = 0x00000020L;
            public static long WARN = 0x00000030L;
            public static long INFO = 0x00000040L;
        }

        /// <summary>
        /// Interupt Process
        /// </summary>
        public struct Interupt
        {
            public static long APP = 0x00000000L;
            public static long SYS = 0x00001000L;
            public static long TASK = 0x00002000L;
            public static long HELP = 0x00004000L;
        }

        /// <summary>
        /// Dialog Options
        /// </summary>
        public struct Options
        {
            public static long OK = 0x00000000L;
            public static long OK_CANCEL = 0x00000001L;
            public static long ABORT_RETRY_IGNORE = 0x00000002L;
            public static long YES_NO_CANCEL = 0x00000003L;
            public static long YES_NO = 0x00000004L;
            public static long RETRY_CANCEL = 0x00000005L;
            public static long CANCEL_RETRY_CONTINUE = 0x00000006L;
        }

        /// <summary>
        /// Dialog Responses
        /// </summary>
        public struct Responses
        {
            public static int OK = 1;
            public static int CANCEL = 2;
            public static int ABORT = 3;
            public static int RETRY = 4;
            public static int IGNORE = 5;
            public static int YES = 6;
            public static int NO = 7;
            public static int TRY_AGAIN = 10;
            public static int CONTINUE = 11;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        /// <summary>
        /// Get the memory pointer of the active window handle
        /// </summary>
        /// <returns>A 32-bit memory pointer to the active window handle</returns>
        public static IntPtr GetWindowHandle() { return GetActiveWindow(); }


        [DllImport("user32.dll", SetLastError = true)]
        static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);

        /// <summary>
        /// Create a Windows Dialog Box popup window. WARNING: This code is blocking and may temperarily suspend execution
        /// </summary>
        /// <param name="title">The text that is displayed in the title bar of the popup window</param>
        /// <param name="text">The text that is displayed within the popup window</param>
        /// <param name="options">The options that are availible in the options bar (long code, see docs)</param>
        /// <param name="icon">The icon shown to the left of the text in the popup window (long code, see docs)</param>
        /// <returns>An integer representing the option the user has chosen</returns>
        public static int CreatePopup(string title, string text, long options, long icon)
        {
            try
            {
                return MessageBox(GetWindowHandle(), text, title, (uint)(options | icon));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}

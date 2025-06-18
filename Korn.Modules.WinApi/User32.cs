using System.Runtime.InteropServices;

namespace Korn.Utils
{
    public static unsafe class User32
    {
        const string user = "user32";

        [DllImport(user)] public static extern int MessageBox(int hwnd, string text, string caption, uint type);

        public static void MessageBox(string text, string caption) => MessageBox(0, text, caption, 0);
        public static void MessageBox(string text) => MessageBox(text, string.Empty);
        public static void MessageBox(object obj) => MessageBox(obj.ToString());
    }
}
using System;
using System.Runtime.InteropServices;

namespace Korn.Modules.WinApi
{
    public unsafe static class Gdi32
    {
        const string gdi = "gdi32";

        [DllImport(gdi)] public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int cornerWidth, int cornerHeight);
    }
}
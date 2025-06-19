using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Korn.Modules.WinApi
{
    public unsafe static class Psapi
    {
        const string psapi = "psapi";

        [DllImport(psapi)] public static extern bool EnumProcessModules(IntPtr process, IntPtr* module, int size, int* need);
        [DllImport(psapi)] public static extern uint GetModuleFileNameEx(IntPtr process, IntPtr module, StringBuilder name, int size);

        public static string GetModuleFileNameEx(IntPtr process, IntPtr module)
        {
            const int MAX_PATH = 512;

            var stringBuilder = new StringBuilder(MAX_PATH);
            GetModuleFileNameEx(process, module, stringBuilder, MAX_PATH);
            return stringBuilder.ToString();
        }

        public static string GetBaseModuleFileNameEx(IntPtr process) => GetModuleFileNameEx(process, IntPtr.Zero);
    }
}

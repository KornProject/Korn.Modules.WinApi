using System;
using System.Runtime.InteropServices;

namespace Korn.Utils
{
    public unsafe struct ModuleEntry32
    {
        public int Size;
        public uint ModuleID;
        public uint ProcessID;
        public uint GlobalCountUsage;
        public uint ProcessCountUsage;
        public byte* ModuleBaseAddress;
        public uint ModuleBaseSize;
        public IntPtr ModuleHandle;
        public fixed byte ModuleName[256];
        public fixed byte ExePath[260];

        public string ModuleNameString
        {
            get
            {
                fixed (ModuleEntry32* self = &this)
                    return Marshal.PtrToStringAnsi((IntPtr)self->ModuleName);
            }
        }


        public string ExePathString
        {
            get
            {
                fixed (ModuleEntry32* self = &this)
                    return Marshal.PtrToStringAnsi((IntPtr)self->ExePath);
            }
        }
    }
}
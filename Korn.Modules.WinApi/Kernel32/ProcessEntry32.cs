using System;
using System.Runtime.InteropServices;

namespace Korn.Utils
{
    public unsafe struct ProcessEntry32
    {
        public int Size;
        public int Usage;
        public int ProcessID;
        public IntPtr DefaultHeapID;
        public int ModuleID;
        public int Threads;
        public int ParentProcessID;
        public int PriClassBase;
        public int Flags;
        public fixed byte ExeFile[260];

        public string ExeFileString
        {
            get
            {
                fixed (ProcessEntry32* self = &this)
                    return Marshal.PtrToStringAnsi((IntPtr)self->ExeFile);
            }
        }
    }
}
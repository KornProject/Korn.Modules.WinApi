using System;

namespace Korn.Modules.WinApi.Kernel
{
    public unsafe struct MemoryBaseInfo
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public long RegionSize;
        public MemoryState State;
        public MemoryProtect Protect;
        public MemoryType Type;

        public bool IsValid => BaseAddress != default;

        public bool SetProtection(MemoryProtect protection)
        {
            var result = Kernel32.VirtualProtect(BaseAddress, RegionSize, protection);
            if (result)
                Protect = protection;

            return result;
        }
    }
}
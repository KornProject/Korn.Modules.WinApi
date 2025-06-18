namespace Korn.Utils
{
    public unsafe struct MemoryBaseInfo
    {
        public byte* BaseAddress;
        public byte* AllocationBase;
        public uint AllocationProtect;
        public long RegionSize;
        public MemoryState State;
        public MemoryProtect Protect;
        public MemoryType Type;

        public bool IsValid => BaseAddress != null;

        public bool SetProtection(MemoryProtect protection)
        {
            var result = Kernel32.VirtualProtect(BaseAddress, RegionSize, protection);
            if (result)
                Protect = protection;

            return result;
        }
    }
}
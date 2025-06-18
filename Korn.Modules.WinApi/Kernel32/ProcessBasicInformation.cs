using System.Runtime.InteropServices;

namespace Korn.Utils
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ProcessBasicInformation
    {
        public int ExitStatus;
        public byte* PebBaseAddress;
        public ulong AffinityMask;
        public long BasePriority;
        public long UniqueProcessID;
        public long InheritedFromUniqueProcessID;
    }
}
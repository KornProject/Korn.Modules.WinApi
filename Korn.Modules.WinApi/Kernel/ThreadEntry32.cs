namespace Korn.Modules.WinApi.Kernel
{
    public struct ThreadEntry32
    {
        public int Size;
        public int CountUsage;
        public int ThreadID;
        public int OwnerProcessID;
        public int BasePriority;
        public int DeltaPriority;
        public int Flags;
    }
}
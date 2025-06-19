using System.Runtime.InteropServices;

namespace Korn.Modules.WinApi.Ole
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public unsafe struct OleVariant
    {
        [FieldOffset(0x00)] public ushort VariantType;
        [FieldOffset(0x02)] fixed byte reserved[6];
        [FieldOffset(0x08)] public void* Unknown;
        [FieldOffset(0x08)] public char* Bstr;
        [FieldOffset(0x08)] public int Int32;
        [FieldOffset(0x08)] public uint UInt32;
        [FieldOffset(0x08)] public long Int64;
        [FieldOffset(0x08)] public ulong UInt64;
    }
}
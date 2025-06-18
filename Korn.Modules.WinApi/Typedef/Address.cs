using System;

#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()

public unsafe struct Address
{
    public Address(IntPtr value) => Value = value;

    public IntPtr Value;
    public ulong Unsigned => (ulong)Value;
    public long Signed => unchecked((long)Value);
    public byte* Pointer => (byte*)Value;

    public static readonly Address Zero = new Address(IntPtr.Zero);

    public static implicit operator Address(IntPtr value) => new Address(value);
    public static implicit operator Address(long value) => new Address((IntPtr)value);
    public static implicit operator Address(void* value) => new Address((IntPtr)value);
    public static implicit operator void*(Address self) => self.Pointer;
    public static implicit operator IntPtr(Address self) => self.Value;

    public static bool operator ==(Address left, Address right) => left.Unsigned == right.Unsigned;
    public static bool operator !=(Address left, Address right) => left.Unsigned != right.Unsigned;
    public static bool operator >(Address left, Address right) => left.Unsigned > right.Unsigned;
    public static bool operator <(Address left, Address right) => left.Unsigned < right.Unsigned;
    public static Address operator +(Address left, Address right) => (IntPtr)(left.Unsigned + right.Unsigned);
    public static Address operator -(Address left, Address right) => (IntPtr)(left.Unsigned - right.Unsigned);
}
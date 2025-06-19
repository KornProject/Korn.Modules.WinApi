namespace Korn.Modules.WinApi.Ole
{
    public enum SecurityDescriptorControl : ushort
    {
        DaclAutoInheritReq = 0x0100,
        DaclAutoInherited = 0x0400,
        DaclDefaulted = 0x0008,
        DaclPresent = 0x0004,
        DaclProtected = 0x1000,
        GroupDefaulted = 0x0002,
        OwnerDefaulted = 0x0001,
        RmControlValid = 0x4000,
        ScalAutoInheritReq = 0x0200,
        ScalAutoInherited = 0x0800,
        ScalDefaulted = 0x0020,
        ScalPresent = 0x0010,
        ScalProtected = 0x2000,
        SelfRelative = 0x8000
    }
}
namespace Korn.Modules.WinApi.Ole
{
    public enum OleAuthenticationCapabilities : uint
    {
        None = 0,
        MutualAuth = 0x1,
        StaticCloaking = 0x20,
        DynamicCloaking = 0x40,
        AnyAuthority = 0x80,
        MakeFullsic = 0x100,
        Default = 0x800,
        SecureRefs = 0x2,
        AccessControl = 0x4,
        AppID = 0x8,
        Dynamic = 0x10,
        RequireFullsic = 0x200,
        AutoImpersonate = 0x400,
        DisableAAA = 0x1000,
        NoCustomMarshal = 0x2000,
        Reserved1 = 0x4000
    }
}
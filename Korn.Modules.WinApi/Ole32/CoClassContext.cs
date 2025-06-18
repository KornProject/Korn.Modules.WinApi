namespace Korn.Utils
{
    public enum CoClassContext : uint
    {
        InProcessServer = 0x1,
        InProcessHandler = 0x2,
        LocalServer = 0x4,
        InProcessServer16 = 0x8,
        RemoteServer = 0x10,
        InProcessHandlers16 = 0x20,
        Reserved1 = 0x40,
        Reserved2 = 0x80,
        Reserved3 = 0x100,
        Reserved4 = 0x200,
        NoCodeDownload = 0x400,
        Reserved5 = 0x800,
        NocustomMarshal = 0x1000,
        EnableCodeDownload = 0x2000,
        NoFailureLog = 0x4000,
        DisableAAA = 0x8000,
        EnableAAA = 0x10000,
        FromDefaultContext = 0x20000,
        ActiveX86Server = 0x40000,
        Active32BitServer,
        Active64BitServer = 0x80000,
        EnableCloaking = 0x100000,
        AppContainer = 0x400000,
        ActiveAAAAsIU = 0x800000,
        Reserved6 = 0x1000000,
        ActiveArm32Server = 0x2000000,
        AllowLowerTrustRegistration,
        PsDll = 0x80000000
    }
}
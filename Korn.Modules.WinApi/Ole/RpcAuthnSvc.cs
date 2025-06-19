namespace Korn.Modules.WinApi.Ole
{
    public enum RpcAuthnSvc : uint
    {
        None = 0,
        DcePrivate = 1,
        DcePublic = 2,
        DecPublic = 4,
        GssNegotiate = 9,
        WinNT = 10,
        GssSchannel = 14,
        GssKerberos = 16,
        Dpa = 17,
        Msn = 18,
        Kernel = 20,
        Digest = 21,
        NegoExtender = 30,
        Pku2u = 31,
        Mq = 10,
        Default = 0xFFFFFFFF
    }
}
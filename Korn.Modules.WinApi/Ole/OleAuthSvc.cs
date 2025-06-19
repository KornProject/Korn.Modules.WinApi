using System.Runtime.InteropServices;

namespace Korn.Modules.WinApi.Ole
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct OleAuthSvc
    {
        public RpcAuthnSvc AuthnSvc;
        public RpcAuthzSvc AuthzSvc;
        public char* PrincipalName;
        public int Result;
    }
}
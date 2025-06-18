using System.Runtime.InteropServices;

namespace Korn.Utils
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SoleAuthSvc
    {
        public RpcAuthnSvc AuthnSvc;
        public RpcAuthzSvc AuthzSvc;
        public char* PrincipalName;
        public int Result;
    }
}
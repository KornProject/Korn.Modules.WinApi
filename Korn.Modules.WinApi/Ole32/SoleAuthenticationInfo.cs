
namespace Korn.Utils
{
    public unsafe struct SoleAuthenticationInfo
    {
        public RpcAuthnSvc AuthnSvc;
        public RpcAuthzSvc AuthzSvc;
        public void* AuthInfo;
    }
}
namespace Korn.Modules.WinApi.Ole
{
    public unsafe struct OleAuthenticationInfo
    {
        public RpcAuthnSvc AuthnSvc;
        public RpcAuthzSvc AuthzSvc;
        public void* AuthInfo;
    }
}
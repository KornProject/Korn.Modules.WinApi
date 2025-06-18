using System;
using System.Runtime.InteropServices;

namespace Korn.Utils
{
    public static unsafe class Ole32
    {
        const string ole = "ole32";

        [DllImport(ole)] static extern int CoInitializeEx(IntPtr reserved, CoInit coInit);

        public static int CoInitializeEx(CoInit coInit) => CoInitializeEx(IntPtr.Zero, coInit);

        [DllImport(ole)] static extern int CoInitializeSecurity(
            SecurityDescriptor* securityDescriptor, 
            CoAuthSvc authConstants, 
            SoleAuthSvc* asAuth, 
            IntPtr reserved, 
            RpcAuthnLevel authLevel, 
            RpcImplLevel implLevel, 
            SoleAuthenticationList* authList, 
            EoleAuthenticationCapabilities capabilities, 
            IntPtr reserved2
        );

        public static int CoInitializeSecurity(
            SecurityDescriptor* securityDescriptor,
            CoAuthSvc authConstants,
            SoleAuthSvc* asAuth,
            RpcAuthnLevel authLevel,
            RpcImplLevel implLevel,
            SoleAuthenticationList* authList,
            EoleAuthenticationCapabilities capabilities
        ) => CoInitializeSecurity(securityDescriptor, authConstants, asAuth, IntPtr.Zero, authLevel, implLevel, authList, capabilities, IntPtr.Zero);

        [DllImport(ole)] static extern int CoCreateInstance(Guid* clsid, void* unknownOuter, CoClassContext classContext, Guid* iid, void* ppv);

        public static int CoCreateInstance(Guid clsid, void* unknownOuter, CoClassContext classContext, Guid iid, void* ppv) => CoCreateInstance(&clsid, unknownOuter, classContext, &iid, ppv);

        [DllImport(ole)]
        public static extern int CoSetProxyBlanket(
            void* proxy,
            RpcAuthnSvc authnSvc, 
            RpcAuthzSvc authzSvc,
            char* serverPrincipleName,
            RpcAuthnLevel authnLevel, 
            RpcImplLevel impLevel,
            IntPtr authInfoHandle, 
            EoleAuthenticationCapabilities capabilities
        );

        [DllImport(ole, EntryPoint = "PropSysAllocString")]
        public static extern char* SysAllocString(char* chars);

#if NET8_0
        public static char* SysAllocString(ReadOnlySpan<char> chars)
        {
            fixed (char* pointer = chars)
                return SysAllocString(pointer);
        }
#endif

        [DllImport(ole, EntryPoint = "PropVariantClear")]
        public static extern int VariantClear(OleVariant* variant);
    }
}
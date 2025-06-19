namespace Korn.Modules.WinApi.Ole
{
    public unsafe struct OleAuthenticationList
    {
        public int Count;
        public OleAuthenticationInfo* Elements;
    }
}
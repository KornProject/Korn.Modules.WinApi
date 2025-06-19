namespace Korn.Modules.WinApi.Ole
{
    public unsafe struct SecurityDescriptor
    {
        public byte Revision;
        public byte Sbz1;
        public SecurityDescriptorControl Control;
        public void* Owner;
        public void* Group;
        public void* Sacl;
        public void* Dacl;
    }
}
using System.Runtime.InteropServices;
using System;

namespace Korn.Utils
{
    public unsafe static class Ntdll
    {
        const string ntdll = "ntdll";
        const int ProcessBasicInformationClass = 0;

        [DllImport(ntdll)] public static extern uint NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, Address information, int informationLength, IntPtr* length);
        [DllImport(ntdll)] public static extern IntPtr NtSuspendProcess(IntPtr processHandle);
        [DllImport(ntdll)] public static extern IntPtr NtResumeProcess(IntPtr processHandle);

        public static uint NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, Address information, int informationLength)
        {
            IntPtr length;
            return NtQueryInformationProcess(processHandle, processInformationClass, information, informationLength, &length);
        }

        public static uint NtQueryBasicInformationProcess(IntPtr processHandle, ProcessBasicInformation* information)
        {
            return NtQueryInformationProcess(processHandle, ProcessBasicInformationClass, information, sizeof(ProcessBasicInformation));
        }

        public static ProcessBasicInformation NtQueryBasicInformationProcess(IntPtr processHandle)
        {
            ProcessBasicInformation information;
            NtQueryBasicInformationProcess(processHandle, &information);
            return information;
        }
    }
}
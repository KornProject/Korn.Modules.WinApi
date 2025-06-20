﻿using Korn.Modules.WinApi.Kernel;
using System;
using System.Runtime.InteropServices;

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
namespace Korn.Modules.WinApi
{
    public unsafe static class Kernel32
    {
        const string kernel = "kernel32";

        [DllImport(kernel)] public static extern void GetSystemTimeAsFileTime(ulong* ticks);
        [DllImport(kernel)] public static extern int GetCurrentProcessId();
        [DllImport(kernel)] public static extern IntPtr OpenProcess(int access, bool inheritHandle, int process);
        [DllImport(kernel)] public static extern bool CloseHandle(IntPtr handle);        
        [DllImport(kernel)] public static extern IntPtr VirtualAllocEx(IntPtr process, IntPtr address, long size, MemoryState allocationType, MemoryProtect protect);
        [DllImport(kernel)] public static extern bool VirtualFreeEx(IntPtr process, IntPtr address, long size, MemoryFreeType dwFreeType);
        [DllImport(kernel)] public static extern bool WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer, long size, out int written);
        [DllImport(kernel)] public static extern bool WriteProcessMemory(IntPtr process, IntPtr address, void* buffer, long size, out int written);
        [DllImport(kernel)] public static extern bool ReadProcessMemory(IntPtr process, IntPtr address, byte[] buffer, long size, out int written);
        [DllImport(kernel)] public static extern bool ReadProcessMemory(IntPtr process, IntPtr address, void* buffer, long size, out int written);
        [DllImport(kernel)] public static extern IntPtr GetProcAddress(IntPtr module, string name);
        [DllImport(kernel)] public static extern IntPtr GetModuleHandle(string name);
        [DllImport(kernel)] public static extern IntPtr CreateRemoteThread(IntPtr process, long threadAttribute, long stackSize, IntPtr startAddress, IntPtr parameter, uint creationFlags, IntPtr* threadId);
        [DllImport(kernel)] public static extern uint WaitForSingleObject(IntPtr handle, uint milliseconds);
        [DllImport(kernel)] public static extern void RtlZeroMemory(IntPtr address, long size);
        [DllImport(kernel)] public static extern int GetLastError();
        [DllImport(kernel)] public static extern bool VirtualQuery(IntPtr address, MemoryBaseInfo* buffer, int length);
        [DllImport(kernel)] public static extern bool VirtualProtect(IntPtr address, long size, MemoryProtect newProtect, MemoryProtect* oldProtect);
        [DllImport(kernel)] public static extern IntPtr VirtualAlloc(IntPtr address, long size, MemoryState allocationType, MemoryProtect protect);
        [DllImport(kernel)] public static extern bool VirtualFree(IntPtr address, long size, MemoryFreeType freeType);
        [DllImport(kernel)] public static extern IntPtr OpenThread(int access, bool inheritHandle, int threadID);
        [DllImport(kernel)] public static extern bool SuspendThread(IntPtr thread);
        [DllImport(kernel)] public static extern int ResumeThread(IntPtr thread);
        [DllImport(kernel)] public static extern bool TerminateProcess(IntPtr process, uint exitCode);
        [DllImport(kernel)] public static extern bool GetExitCodeProcess(IntPtr handle, out uint exitCode);
        [DllImport(kernel)] public static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags flags, int processId);
        [DllImport(kernel)] public static extern bool Module32First(IntPtr snapshot, ModuleEntry32* entry);
        [DllImport(kernel)] public static extern bool Module32Next(IntPtr snapshot, ModuleEntry32* entry);
        [DllImport(kernel)] public static extern bool Thread32First(IntPtr snapshot, ThreadEntry32* entry);
        [DllImport(kernel)] public static extern bool Thread32Next(IntPtr snapshot, ThreadEntry32* entry);
        [DllImport(kernel)] public static extern bool Process32First(IntPtr snapshot, ProcessEntry32* entry);
        [DllImport(kernel)] public static extern bool Process32Next(IntPtr snapshot, ProcessEntry32* entry);

        public static ulong GetSystemTime()
        {
            ulong* tick = stackalloc ulong[1];
            GetSystemTimeAsFileTime(tick);
            return *tick;
        }

        public static bool VirtualQuery(IntPtr baseAddress, MemoryBaseInfo* mbi) => VirtualQuery(baseAddress, mbi, sizeof(MemoryBaseInfo));

        public static MemoryBaseInfo VirtualQuery(IntPtr baseAddress)
        {
            MemoryBaseInfo mbi;
            if (!VirtualQuery(baseAddress, &mbi, sizeof(MemoryBaseInfo)))
                return default;
            return mbi;
        }

        public static bool VirtualProtect(IntPtr address, long size, MemoryProtect newProtect)
        {
            MemoryProtect oldProtection;
            return VirtualProtect(address, size, newProtect, &oldProtection);
        }

        public static void WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer) => WriteProcessMemory(process, address, buffer, buffer.Length, out int _);
        public static void WriteProcessMemory(IntPtr process, IntPtr address, byte* buffer, int size) => WriteProcessMemory(process, address, buffer, size, out int _);
        public static void WriteProcessMemory<T>(IntPtr process, IntPtr address, T value) where T : unmanaged => WriteProcessMemory(process, address, &value, sizeof(T), out int _);
        public static void WriteProcessMemory<T>(IntPtr process, IntPtr address, T* value) where T : unmanaged => WriteProcessMemory(process, address, value, sizeof(T), out int _);

        public static byte[] ReadProcessMemory(IntPtr process, IntPtr address, int length)
        {
            var buffer = new byte[length];
            ReadProcessMemory(process, address, buffer, buffer.Length, out int _);

            return buffer;
        }

        public static void ReadProcessMemory(IntPtr process, IntPtr source, void* destination, int length) => ReadProcessMemory(process, source, destination, length, out int _);

        public static T ReadProcessMemory<T>(IntPtr process, IntPtr address) where T : unmanaged
        {
            var buffer = ReadProcessMemory(process, address, sizeof(T));
            fixed (byte* pointer = buffer)
                return *(T*)pointer;
        }
    }
}

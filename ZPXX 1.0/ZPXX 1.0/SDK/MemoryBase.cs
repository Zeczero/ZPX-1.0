using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using System.Runtime.InteropServices;
using System.Diagnostics;
using static ZPXX_1._0.SDK.Useful;

namespace ZPXX_1._0.SDK
{
    public static class MemoryBase
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesWritten);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public static Process g_pProcess;
        public static IntPtr g_pProcessHandle;
        public static IntPtr g_pClient;
        public static IntPtr g_pEngine;
        public static int m_iBytesRead = 0;
        public static int m_iBytesWrite = 0;

        public static T ReadMemory<T>(int Adress) where T : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[ByteSize];
            ReadProcessMemory((int)g_pProcessHandle, Adress, buffer, buffer.Length, ref m_iBytesRead);

            return Useful.ByteArrayToStructure<T>(buffer);
        }

        public static void WriteMemory<T>(int Adress, object Value)
        {
            byte[] buffer = Useful.StructureToByteArray(Value);

            WriteProcessMemory((int)g_pProcessHandle, Adress, buffer, buffer.Length, out m_iBytesWrite);
        }

    }
}

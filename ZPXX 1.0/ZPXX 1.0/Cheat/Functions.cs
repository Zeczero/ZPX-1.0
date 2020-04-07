using System.Threading;
using ZPXX_1._0.SDK;
using static ZPXX_1._0.SDK.MemoryBase;
using ZPXX_1._0.Offsets;

namespace ZPXX_1._0.Cheat
{
    public static class Functions
    {
        public static bool isHoldingKey(int keyid)
        {
            if ((GetAsyncKeyState(keyid) & 0x8000) > 0)
                return true;
            else
                return false;
        }

        public static void Shoot()
        {
            WriteMemory<int>((int)g_pClient + Signatures.dwForceAttack, 6);
            Thread.Sleep(GlobalOptionVariables.bTriggerDelay);
            WriteMemory<int>((int)g_pClient + Signatures.dwForceAttack, 4);
        }

        public static bool SpotAPlayerIfVisible(int local, int entity)
        {
            int mask = MemoryBase.ReadMemory<int>(entity + Netvars.m_bSpottedByMask);
            int PBASE = MemoryBase.ReadMemory<int>(local + 0x64) - 1;
            return (mask & (1 << PBASE)) > 0;
        }
    }
}

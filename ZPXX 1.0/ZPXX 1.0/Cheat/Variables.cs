using static ZPXX_1._0.SDK.MemoryBase;
using ZPXX_1._0.Offsets;
using static ZPXX_1._0.Cheat.Functions;
namespace ZPXX_1._0.Cheat
{
    public static class Variables
    {
        public static int GlowBase = ReadMemory<int>((int)g_pClient + Signatures.dwGlowObjectManager);
        public static int Local = ReadMemory<int>((int)g_pClient + Signatures.dwLocalPlayer);
        public static int LocalTeam = ReadMemory<int>(Local + Netvars.m_iTeamNum);
        public static int LocalFlash = ReadMemory<int>(Local + Netvars.m_flFlashMaxAlpha);
        public static int LocalFov = ReadMemory<int>(Local + (Netvars.m_iFOVStart - 4));
        public static int LocalScope = ReadMemory<int>(Local + Netvars.m_bIsScoped);
    }
}

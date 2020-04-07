using System.Threading;
using ZPXX_1._0.Structs;
using ZPXX_1._0.SDK;
using static ZPXX_1._0.SDK.MemoryBase;
using ZPXX_1._0.Offsets;
using System.Windows.Forms;
using static ZPXX_1._0.Cheat.Functions;
using static ZPXX_1._0.Cheat.Variables;
using static ZPXX_1._0.Offsets.SelfUpdating;

namespace ZPXX_1._0.Cheat
{
    public static class Main
    {
        public static RootObject RootObject;
        public static void MainFunction()
        {
            while (true)
            {
                GlowObject GlowObject = new GlowObject();
                for (var i = 0; i <= 64; i++)
                {
                    int EntBase = ReadMemory<int>((int)g_pClient + Signatures.dwEntityList + i * 0x10);
                    int Dormant = ReadMemory<int>(EntBase + Signatures.m_bDormant);
                    int Team = ReadMemory<int>(EntBase + Netvars.m_iTeamNum);
                    int GlowIndex = ReadMemory<int>(EntBase + Netvars.m_iGlowIndex);
                    int Spotted = ReadMemory<int>(EntBase + Netvars.m_bSpotted);
                    bool Visible = SpotAPlayerIfVisible(Local, EntBase);
                    int Flags = ReadMemory<int>(EntBase + Netvars.m_fFlags);

                    if (EntBase == 0) continue;
                    if (Dormant == 1) continue;
                    var M8 = (Team == LocalTeam);
                    if (GlobalOptionVariables.bRadar)
                        if (Spotted == 0 && !M8) WriteMemory<int>(EntBase + Netvars.m_bSpotted, 1);

                        if (GlobalOptionVariables.bGlow)
                        {
                            GlowObject = ReadMemory<GlowObject>(GlowBase + GlowIndex * 0x38);
                            /*
                            if (GlobalOptionVariables.iGlowMode == 1 && M8) continue;
                            if (GlobalOptionVariables.iGlowMode == 2 && !Visible) continue;
                            */
                            GlowObject.r = M8 ? 0.0f : 1.0f;
                            GlowObject.g = M8 ? 1.0f : 0.0f;
                            GlowObject.b = 0.3f;
                            GlowObject.a = 0.7f;
                            GlowObject.m_bRenderWhenOccluded = true;
                            GlowObject.m_bRenderWhenUnoccluded = false;
                            GlowObject.m_bFullBloom = false;
                            WriteMemory<GlowObject>(GlowBase + GlowIndex * 0x38, GlowObject);
                        }

                    if (GlobalOptionVariables.bTriggerBot)
                    {
                        if (!M8 && Spotted == 1)
                        {
                            Shoot();
                        }
                    }
                    if (GlobalOptionVariables.bBunny)
                    {
                        if (isHoldingKey(0x20))
                        {
                            if (Flags == 257 || Flags == 263)
                            {
                                WriteMemory<int>((int)g_pClient + Signatures.dwForceJump, 6);
                            }
                        }
                    }
                }
                Thread.Sleep(5); // to avoid spikes of CPU
            }
        }
    }
}

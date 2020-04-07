using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Diagnostics;
using ZPXX_1._0.SDK;
using static ZPXX_1._0.SDK.MemoryBase;
using static ZPXX_1._0.Cheat.Main;


namespace ZPXX_1._0.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitializeProcess();
        }

        public bool InitializeProcess()
        {
            var csgo = Process.GetProcessesByName("csgo");

            if (csgo.Length == 0)
            {
                return false;
            }
            else
            {
                g_pProcess = csgo[0];
                g_pProcessHandle = ZPXX_1._0.SDK.MemoryBase.OpenProcess(0x0008 | 0x0010 | 0x0020, false, ZPXX_1._0.SDK.MemoryBase.g_pProcess.Id);
                foreach (ProcessModule Module in g_pProcess.Modules)
                {
                    if ((Module.ModuleName == "client_panorama.dll"))
                        ZPXX_1._0.SDK.MemoryBase.g_pClient = Module.BaseAddress;

                    if ((Module.ModuleName == "engine.dll"))
                        ZPXX_1._0.SDK.MemoryBase.g_pEngine = Module.BaseAddress;
                }
                Thread Updater = new Thread(MainFunction);
                Updater.Start();
            }
            return true;
        }

        private void GlowESP_Checked(object sender, RoutedEventArgs e)
        {
            GlobalOptionVariables.bGlow = !GlobalOptionVariables.bGlow;
        }

        private void Radar_Checked(object sender, RoutedEventArgs e)
        {
            GlobalOptionVariables.bRadar = !GlobalOptionVariables.bRadar;
        }

        private void TriggerBot_Checked(object sender, RoutedEventArgs e)
        {
            GlobalOptionVariables.bTriggerBot = !GlobalOptionVariables.bTriggerBot;
        }

        private void TriggerDelay_TextChanged(object sender, TextChangedEventArgs e)
        {
            GlobalOptionVariables.bTriggerDelay *= 1000;
        }

        private void Bunnyhop_Checked(object sender, RoutedEventArgs e)
        {
            GlobalOptionVariables.bBunny = !GlobalOptionVariables.bBunny;
        }
    }
}

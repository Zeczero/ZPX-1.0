using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Security.Cryptography;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ZPXX_1._0.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Github_Click(object sender, RoutedEventArgs e)
        {

        }
     
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {  
            System.Diagnostics.Process.Start("https://github.com/Zeczero");
        }
        // main.Show();
        //this.Close();
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            var getCsGoProc = Process.GetProcessesByName("csgo");

            if (getCsGoProc.Length != 0)
            {
                main.Show();
                this.Close();
            }
            else
            {
               var result = MessageBox.Show("Error: Please run cs go process", "Error", MessageBoxButton.OKCancel);
               
                if (result == MessageBoxResult.Cancel)
                {
                    Process.GetCurrentProcess().Kill();
                }
            }

        }
    }
}

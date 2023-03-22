using Gomoku_wpf.core;
using Gomoku_wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gomoku_wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

/*        /// <summary>
        /// Allocates a new console for current process.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        /// <summary>
        /// Frees the console.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("Kernel32.dll", EntryPoint = "AttachConsole", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void AttachConsole(int dwProcessId);*/

        public MainWindow()
        {

            InitializeComponent();

            ConsoleManager.Show();
            Console.WriteLine("starwing 2023.3.21");

            board.GameOver = (c) => { gameOver(c); };
            board.Init();

            btn_start.Click += (sender, e) => { startSetting(); };
            btn_exit.Click += (sender, e) => { App.Current.Shutdown(); };


        }
        private void startSetting()
        {
            SettingView settingView = new SettingView();
            settingView.ShowInTaskbar = false;
            settingView.Owner = this;
            settingView.Ok = (bln) => { board.CreateNew(bln); };
            settingView.ShowDialog();
        }
        private void gameOver(PColor c)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(() => { gameOver(c); });
            }
            else
            {
                //MessageBox.Show(this, c.ToString() + " win !");
                MessageBox.Show(this, "Game Over !");
            }
        }

    }
}

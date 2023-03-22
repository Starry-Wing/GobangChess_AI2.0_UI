using Gomoku_wpf.core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gomoku_wpf.Views
{
    /// <summary>
    /// PieceView.xaml 的交互逻辑
    /// </summary>
    public partial class PieceView : UserControl
    {
        public PieceView(PColor pcolor)
        {
            InitializeComponent();

            gsColor1.Color = pcolor == PColor.Black ? Colors.LightGray : Colors.White;
            gsColor2.Color = pcolor == PColor.Black ? Colors.Black : Colors.LightGray;
        }
    }
}

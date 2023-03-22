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
    /// GomokuBoardView.xaml 的交互逻辑
    /// </summary>
    public partial class GomokuBoardView : UserControl
    {
        GameTree gameTree;

        public GomokuBoardView()
        {
            InitializeComponent();
            gameTree = new GameTree();
        }
        Border lastPieceFlag = new Border();
        PieceView lastPiece = null;
        private void addPiece(PieceInfo p)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(() => { addPiece(p); });
                return;
            }
            foreach (UIElement e in GridBoard.Children)
            {
                if (Grid.GetColumn(e).Equals(p.I) && Grid.GetRow(e).Equals(p.J))
                    return;
            }

            if (GridBoard.Children.Contains(lastPieceFlag))
                GridBoard.Children.Remove(lastPieceFlag);

            lastPiece = new PieceView(p.C==Convert.ToInt32(PColor.Black) ? PColor.Black : PColor.White);
            GridBoard.Children.Add(lastPiece);
            Grid.SetColumn(lastPiece, p.I);
            Grid.SetRow(lastPiece, p.J);

            GridBoard.Children.Add(lastPieceFlag);
            Grid.SetColumn(lastPieceFlag, p.I);
            Grid.SetRow(lastPieceFlag, p.J);

            Console.WriteLine("({0}, {1})",p.I, p.J);

            curClr = curClr == PColor.White ? PColor.Black : PColor.White;
        }
        private void clearPieces()
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(clearPieces);
                return;
            }
            List<UIElement> ps = new List<UIElement>();
            foreach (UIElement e in GridBoard.Children)
            {
                if (e is PieceView)
                    ps.Add(e);
            }
            foreach (UIElement e in ps)
                GridBoard.Children.Remove(e);
            if (GridBoard.Children.Contains(lastPieceFlag))
                GridBoard.Children.Remove(lastPieceFlag);
        }

        private void GridBoard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(GridBoard);
            int c = (int)p.X / 32;
            int r = (int)p.Y  / 32;
            addPiece(new PieceInfo(c, r,curClr));

            gameTree.MakeNextMove(new Tuple<int, int>(c, r), false);
            Tuple<int, int> nextStep = gameTree.AlphaBetaSearch();
            gameTree.MakeNextMove(nextStep, true);
            addPiece(new PieceInfo(nextStep.Item1, nextStep.Item2, curClr));
        }


        public Action<PColor> GameOver { get; set; }
        private PColor curClr = PColor.White;
        public void Init()
        {
            lastPieceFlag.Width = 20; lastPieceFlag.Height = 20;
            lastPieceFlag.CornerRadius = new CornerRadius(10);
            lastPieceFlag.BorderThickness = new Thickness(2);
            lastPieceFlag.BorderBrush = new SolidColorBrush(Colors.Yellow);
        }
        public void CreateNew(bool blackFirst)
        {
            clearPieces();
            lastPiece = null;
            curClr = blackFirst ? PColor.Black : PColor.White;
        }

    }
}

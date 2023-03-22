using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku_wpf.core
{
    public class PieceInfo
    {
        public PieceInfo(int i, int j, PColor c)
        {
            I = i;
            J = j;
            C = Convert.ToInt32(c);
        }
        public int C { get; private set; }
        public int I { get; private set; }
        public int J { get; private set; }
    }
}

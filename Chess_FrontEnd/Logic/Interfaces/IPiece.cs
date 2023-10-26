using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_clases.Interfaces
{
    internal interface IPiece
    {
        List<Tuple<int, int>> ShowValidMovements();
        bool IsValidMove(int newx, int newy);

    }
}

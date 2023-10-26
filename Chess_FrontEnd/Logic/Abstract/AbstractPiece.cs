using Sah_clases.Clases;
using Sah_clases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_clases.Abstract
{
    internal abstract class AbstractPiece : IPiece
    {
        public int x;
        public int y;
        public bool IsWhite = true;
        internal readonly Board board;
        public AbstractPiece(int x, int y, Board bord, bool isWhite)
        {
            this.x = x;
            this.y = y;
            this.IsWhite = isWhite;
            this.board = bord;
        }
        public abstract bool IsValidMove(int newx, int newy);

        public abstract List<Tuple<int, int>> ShowValidMovements();
    }
}

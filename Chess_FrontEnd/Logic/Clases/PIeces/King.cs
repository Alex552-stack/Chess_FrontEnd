using Sah_clases.Abstract;
using Sah_clases.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FrontEnd.Logic.Clases.PIeces
{
    internal class King : AbstractPiece
    {
        public King(int x, int y, Board bord, bool isWhite) : base(x, y, bord, isWhite)
        {
        }

        public override bool IsValidMove(int newx, int newy)
        {
            return true;
        }

        public override List<Tuple<int, int>> ShowValidMovements()
        {
            return Movement.KingMovement(x, y, board, IsWhite);
        }
    }
}

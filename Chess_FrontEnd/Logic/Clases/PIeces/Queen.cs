using Sah_clases.Abstract;
using Sah_clases.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FrontEnd.Logic.Clases.PIeces
{
    internal class Queen : AbstractPiece
    {
        public Queen(int x, int y, Board bord, bool isWhite) : base(x, y, bord, isWhite)
        {
        }

        public override bool IsValidMove(int newx, int newy)
        {
            return true;
        }

        public override List<Tuple<int, int>> ShowAllMovement()
        {
            var moves = Movement.DiagonalMovement(x, y, board, IsWhite);
            moves = moves.Concat(Movement.StraightMovement(x, y, board, IsWhite)).ToList();
            return moves;
        }

    }
}

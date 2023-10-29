using Sah_clases.Abstract;
using Sah_clases.Clases;
using System;
using System.Collections.Generic;

namespace Chess_FrontEnd.Logic.Clases.PIeces
{
    internal class Rook : AbstractPiece
    {
        public Rook(int x, int y, Board bord, bool isWhite) : base(x, y, bord, isWhite)
        {
        }

        public override bool IsValidMove(int newx, int newy)
        {
            //if (newx == x)
            //{
            //    for (int i = 0; i < 8; i++)
            //    {
            //        if (board.chessboard.containskey(tuple.create(x, i)))
            //            break;
            //        if (newy == y)
            //            return true;
            //    }
            //}
            //else if (newy == y)
            //{
            //    for (int i = 0; i < 8; i++)
            //        if (board.chessboard.containskey(tuple.create(i, y)))
            //            break;
            //    if (newx == x)
            //        return true;
            //}
            //return false;
            return true;
        }

        public override List<Tuple<int, int>> ShowValidMovements()
        {
            return Movement.StraightMovement(x, y, board, IsWhite);
        }
    }
}

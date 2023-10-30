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


        public bool IsInCheck()
        {
            foreach (var piece in board.ChessBoard.Values)
            {
                if (piece != null && piece.IsWhite != IsWhite) // Check opponent's pieces
                {
                    var moves = piece.ShowValidMovements();
                    foreach (var move in moves)
                    {
                        if (move.Item1 == x && move.Item2 == y)
                        {
                            // The king is in check if an opponent's piece can move to its position
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override List<Tuple<int, int>> ShowAllMovement()
        {
            return Movement.KingMovement(x, y, board, IsWhite);
        }
    }
}

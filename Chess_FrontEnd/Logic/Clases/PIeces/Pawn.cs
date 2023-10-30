using Sah_clases.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_clases.Clases.PIeces
{
    internal class Pawn : AbstractPiece
    {

        public bool isFirstMove = true;

        public Pawn(int x, int y, Board board, bool isWhite) : base(x, y, board, isWhite)
        {
        }

        public override bool IsValidMove(int newx, int newy)
        {
            int deltaX = IsWhite ? x - newx : newx - x;
            int offset = IsWhite ? -1 : 1;
            int deltaY = Math.Abs(newy - y);
            

            if (deltaY == 1 && deltaX == 0 && !board.ChessBoard.ContainsKey(Tuple.Create(newx, newy)))
            {
                // Forward move
                return true;
            }

            if (isFirstMove && deltaY == 2 && deltaX == 0 && !board.ChessBoard.ContainsKey(Tuple.Create(newx, newy)) && !board.ChessBoard.ContainsKey(Tuple.Create(newx,newy - offset)))
            {
                // Two-square forward move on first move
                return true;
            }

            if (deltaX == 1 && deltaY == 1 && IsValidDiagonalCapture(newx,newy))
                return true;
            if (deltaX == -1 && deltaY == 1 && IsValidDiagonalCapture(newx, newy))
                return true;
            return false;
        }
        
        private bool IsValidDiagonalCapture(int newx, int newy)
        {
            var pos = Tuple.Create(newx, newy);
            if (newx >= 0 && newx < 8 && newy >= 0 && newy < 8 && board.ChessBoard.ContainsKey(pos))
            {
                var pieceAtPosition = board.ChessBoard[pos];
                return (pieceAtPosition != null && pieceAtPosition.IsWhite != IsWhite);
            }
            return false;
        }

        public override List<Tuple<int, int>> ShowAllMovement()
        {
            List<Tuple<int, int>> validMoves = new List<Tuple<int, int>>();

            int offset = IsWhite ? -1 : 1; //Daca este alb scade, daca e negru creste

            // Single square forward move
            if (IsValidMove(x, y + offset))
            {
                validMoves.Add(Tuple.Create(x, y + offset));
            }

            // Two-square forward move on first move
            if (isFirstMove && IsValidMove(x, y + 2 * offset))
            {
                validMoves.Add(Tuple.Create(x, y + 2 * offset));
            }

            // Diagonal captures
            //if (IsValidMove(x + 1, y + 1))
            //{
            //    validMoves.Add(Tuple.Create(x + 1, y + 1));
            //}
            //if (IsValidMove(x + 1, y - 1))
            //{
            //    validMoves.Add(Tuple.Create(x + 1, y - 1));
            //}
            //if (IsValidMove(x - 1, y + 1))
            //{
            //    validMoves.Add(Tuple.Create(x - 1, y + 1));
            //}
            //if (IsValidMove(x - 1, y - 1))
            //{
            //    validMoves.Add(Tuple.Create(x - 1, y - 1));
            //}
            if (IsValidDiagonalCapture(x + 1, y + offset))
                validMoves.Add(Tuple.Create(x + 1, y + offset));
            if (IsValidDiagonalCapture(x - 1, y + offset))
                validMoves.Add(Tuple.Create(x - 1, y + offset));

            return validMoves;
        }
    }
}

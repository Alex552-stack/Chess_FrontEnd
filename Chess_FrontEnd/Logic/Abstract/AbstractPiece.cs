using Chess_FrontEnd.Logic.Clases;
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
        public abstract List<Tuple<int, int>> ShowAllMovement();

        internal List<Tuple<int, int>> ShowValidMovements()
        {
            List<Tuple<int, int>> allMoves = ShowAllMovement();
            List<Tuple<int, int>> validMoves = new List<Tuple<int, int>>();

            for (int i = allMoves.Count - 1; i >= 0; i--)
            {
                var move = allMoves[i];
                if (!IsMoveLeavingKingInCheck(move.Item1, move.Item2, IsWhite))
                {
                    validMoves.Add(move);
                }
            }

            return validMoves;
        }

        private bool IsMoveLeavingKingInCheck (int newX, int newY, bool isWhite)
        {
            //// Simulate the move temporarily
            //AbstractPiece capturedPiece = board.ChessBoard[Tuple.Create(newX, newY)];
            //board.ChessBoard.Remove(Tuple.Create(newX, newY));
            //board.ChessBoard.Add(Tuple.Create(currentX, currentY), null);
            var poz = Tuple.Create(newX, newY);
            int CapturedX = -1;
            int CapturedY = -1;
            Type CapturedType = null;
            bool CapturedIsWhite = true;
            AbstractPiece capturedPiece = null;
            int initX = x, initY = y;
            if(board.ChessBoard.ContainsKey(poz))
            {
                capturedPiece = board.ChessBoard[poz];
                CapturedX = capturedPiece.x;
                CapturedY = capturedPiece.y;
                CapturedType = capturedPiece.GetType();
                CapturedIsWhite = capturedPiece.IsWhite;
            }
            board.MovePiece(Tuple.Create(x, y), poz);

            //// Check if the own king is in check after the move
            bool isLeavingKingInCheck = OwnKingIsInCheck(isWhite);

            //// Undo the temporary move
            board.ChessBoard.Remove(poz);
            if(capturedPiece != null)
            {
                AbstractPiece recreatedPiece = Activator.CreateInstance(CapturedType, CapturedX, CapturedY, board, CapturedIsWhite) as AbstractPiece;
                board.ChessBoard.Add(poz, recreatedPiece);
            }
            this.x = initX;
            this.y = initY;
            board.ChessBoard.Add(Tuple.Create(this.x, this.y), this);
            
            return isLeavingKingInCheck;

            //return isLeavingKingInCheck;
        }
        private bool OwnKingIsInCheck(bool isWhite)
        {
            // Check if the white king is in check
            if (isWhite)
            {
                return board.WhiteKing.IsInCheck();
            }
            // Check if the black king is in check
            else
            {
                return board.BlackKing.IsInCheck();
            }
        }
    }
    struct Copy
    {

    }
}

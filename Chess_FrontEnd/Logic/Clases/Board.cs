using Chess_FrontEnd.Logic.Clases.PIeces;
using Sah_clases.Abstract;
using Sah_clases.Clases.PIeces;
using Sah_clases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_clases.Clases
{
    public class Board
    {
        internal Dictionary<Tuple<int, int>, AbstractPiece> ChessBoard;

        public Board()
        {
            InitBoard();
            
        }

        public void MovePiece(Tuple<int, int> currentPosition, Tuple<int, int> newPosition)
        {
            

            if (ChessBoard.ContainsKey(currentPosition))
            {
                var pawn = ChessBoard[currentPosition];
                if (pawn.IsValidMove(newPosition.Item1, newPosition.Item2))
                {
                    ChessBoard.Remove(currentPosition);
                    ChessBoard[newPosition] = pawn;
                    pawn.x = newPosition.Item1;
                    pawn.y = newPosition.Item2;
                    if(pawn is Pawn)
                    {
                        var paw = pawn as Pawn;
                        paw.isFirstMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move for the selected piece.");
                }
            }
            else
            {
                Console.WriteLine("No piece found at the selected position.");
            }
        }

        private void InitBoard()
        {
            ChessBoard = new Dictionary<Tuple<int, int>, AbstractPiece>();

            var wQueen = new Queen(3, 7, this, true);
            var bQueen = new Queen(4, 0, this, false);
            ChessBoard.Add(Tuple.Create(3, 7), wQueen);
            ChessBoard.Add(Tuple.Create(4, 0), bQueen);

            var wKing = new King(4, 7, this, true);
            var bKing = new King(3,0,this, false);
            ChessBoard.Add(Tuple.Create(4, 7), wKing);
            ChessBoard.Add(Tuple.Create(3,0), bKing);

            for (int i = 0; i < 8; i++)
            {
                if (i == 0 || i == 7)
                {
                    var rook = new Rook(i, 0, this, false);
                    var rook1 = new Rook(i, 7, this, true);
                    ChessBoard.Add(Tuple.Create(i, 0), rook);
                    ChessBoard.Add(Tuple.Create(i, 7), rook1);
                }
                else if (i == 1 || i == 6)
                {
                    var bishop = new Bishop(i, 0, this, false);
                    var bishop1 = new Bishop(i, 7, this, true);
                    ChessBoard.Add(Tuple.Create(i, 0), bishop);
                    ChessBoard.Add(Tuple.Create(i, 7), bishop1);
                }
                else if(i == 2 || i == 5)
                {
                    var knight = new Knight(i, 0, this, false);
                    var knight1 = new Knight(i, 7, this, true);
                    ChessBoard.Add(Tuple.Create(i, 0), knight);
                    ChessBoard.Add(Tuple.Create(i, 7), knight1);
                }
                
                var pawn = new Pawn(i, 1, this, false);
                ChessBoard.Add(Tuple.Create(i, 1), pawn);
                var pawn1 = new Pawn(i, 6, this, true);
                ChessBoard.Add(Tuple.Create(i, 6), pawn1);
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var position = Tuple.Create(i, j);
                    if (ChessBoard.ContainsKey(position))
                        Console.Write("1 "); // Print 1 for occupied squares
                    else
                        Console.Write("0 "); // Print 0 for empty squares
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

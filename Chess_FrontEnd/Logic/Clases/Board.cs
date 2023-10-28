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
            ChessBoard = new Dictionary<Tuple<int, int>, AbstractPiece>();
            for (int i = 0; i < 8; i++)
            {
                var pawn = new Pawn(i, 1, this, false);
                ChessBoard.Add(Tuple.Create(i, 1), pawn);
                var pawn1 = new Pawn(i, 6, this, true);
                ChessBoard.Add(Tuple.Create(i, 6), pawn1);
            }
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

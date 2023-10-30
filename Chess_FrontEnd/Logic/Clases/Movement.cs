using Sah_clases.Clases;
using System;
using System.Collections.Generic;

namespace Chess_FrontEnd.Logic.Clases
{
    internal static class Movement
    {
        public static List<Tuple<int, int>> StraightMovement(int x, int y, Board board, bool IsWhite)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();
            for (int i = x + 1; i < 8; i++)
            {
                var poz = Tuple.Create(i, y);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;
                }
                moves.Add(poz);
            }
            for (int i = x - 1; i >= 0; i--)
            {
                var poz = Tuple.Create(i, y);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;
                }
                moves.Add(poz);
            }
            for (int i = y + 1; i < 8; i++)
            {
                var poz = Tuple.Create(x, i);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;
                }
                moves.Add(poz);
            }
            for (int i = y - 1; i >= 0; i--)
            {
                var poz = Tuple.Create(x, i);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;
                }
                moves.Add(poz);
            }

            return moves;
        }

        public static List<Tuple<int, int>> DiagonalMovement(int x, int y, Board board, bool IsWhite)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            for (int i = 1; x + i < 8 && y + i < 8; i++)
            {
                var poz = Tuple.Create(x + i, y + i);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;

                }
                moves.Add(poz);
            }
            for (int i = 1; x - i >= 0 && y + i < 8; i++)
            {
                var poz = Tuple.Create(x - i, y + i);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;

                }
                moves.Add(poz);
            }

            for (int i = 1; x + i < 8 && y - i >= 0; i++)
            {
                var poz = Tuple.Create(x + i, y - i);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;

                }
                moves.Add(poz);
            }

            for (int i = 1; x - i >= 0 && y - i >= 0; i++)
            {
                var poz = Tuple.Create(x - i, y - i);
                if (board.ChessBoard.ContainsKey(poz))
                {
                    if (board.ChessBoard[poz].IsWhite != IsWhite)
                        moves.Add(poz);
                    break;

                }
                moves.Add(poz);
            }

            return moves;
        }

        public static List<Tuple<int, int>> LMovement(int x, int y, Board board, bool IsWhite)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            int[] xOffset = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] yOffset = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = x + xOffset[i];
                int newY = y + yOffset[i];

                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    var poz = Tuple.Create(newX, newY);
                    if (board.ChessBoard.ContainsKey(poz))
                    {
                        if (board.ChessBoard[poz].IsWhite != IsWhite)
                        {
                            moves.Add(poz);
                        }
                    }
                    else { moves.Add(poz); }
                }
            }

            return moves;
        }

        public static List<Tuple<int, int>> KingMovement(int x, int y, Board board, bool IsWhite)
        {
            var moves = new List<Tuple<int, int>>();
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i <= 8 && j <= 8 && j >= 0)
                    {
                        var poz = Tuple.Create(i, j);
                        if (board.ChessBoard.ContainsKey(poz))
                        {
                            if (board.ChessBoard[poz].IsWhite == IsWhite)
                                continue;
                            moves.Add(poz);
                        }
                        else moves.Add(poz);
                    }
                }
            }
            return moves;
        }
    
        
    }
}

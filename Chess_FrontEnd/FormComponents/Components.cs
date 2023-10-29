using Chess_FrontEnd.Logic.Clases.PIeces;
using Sah_clases.Abstract;
using Sah_clases.Clases;
using Sah_clases.Clases.PIeces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_FrontEnd.FormComponents
{
    internal class OnClickController
    {
        Board board;
        PictureBox pictureBox1;
        public OnClickController(Board board, PictureBox pictureBox1)
        {
            this.board = board;
            this.pictureBox1 = pictureBox1;
        }

        public Tuple<int,int> SelectPiece(object sender)
        {
            ResetHints();
            PictureBox pictureBox = sender as PictureBox;
            var initPoz = pictureBox.Tag as Tuple<int, int>;
            var moves = board.ChessBoard[initPoz].ShowValidMovements();
            foreach (var move in moves)
            {
                foreach (Control control in pictureBox1.Controls)
                {
                    if (control is PictureBox)
                    {
                        PictureBox movePictureBox = control as PictureBox;
                        var movePos = movePictureBox.Tag as Tuple<int, int>;
                        if (movePos.Item1 == move.Item1 && movePos.Item2 == move.Item2)
                        {
                            //movepicturebox.imagelocation = "../../images/hint.png";
                            //set the imagelocation to hint.png
                            //hints.add(movepos);
                            var hintPictureBox = movePictureBox.Controls[0] as PictureBox;
                            hintPictureBox.Visible = true;
                            hintPictureBox.BringToFront();
                        }
                    }
                }
            }
            return initPoz;
            
        }
        public void ResetHints()
        {
            foreach(Control control in pictureBox1.Controls)
            {
                if(control is PictureBox)
                {
                    PictureBox pictureBox = control as PictureBox;
                    PictureBox hintBox = pictureBox.Controls[0] as PictureBox;
                    hintBox.Visible = false;
                }
            }
            //hints.Clear();
        }

        public static string ParseImageString(AbstractPiece ChessPiece)
        {
            string imgStr = "../../Images/";
            char? piece = null;
            if (ChessPiece is Pawn)
                piece = 'p';
            else if (ChessPiece is Rook)
                piece = 'r';
            else if (ChessPiece is Bishop)
                piece = 'b';
            else if (ChessPiece is Queen)
                piece = 'q';
            else if (ChessPiece is Knight)
                piece = 'n';
            else if (ChessPiece is King)
                piece = 'k';

            if (ChessPiece.IsWhite)
                return imgStr + 'w' + piece + ".png";
            else
                return imgStr + 'b' + piece + ".png";
        }
    }
}

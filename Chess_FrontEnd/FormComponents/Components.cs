using Sah_clases.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_FrontEnd.FormComponents
{
    internal class VizComponents
    {
        Board board;
        PictureBox pictureBox1;
        List<Tuple<int, int>> hints;
        public VizComponents(Board board, PictureBox pictureBox1, List<Tuple<int, int>> hints)
        {
            this.board = board;
            this.pictureBox1 = pictureBox1;
            this.hints = hints;
        }

        public Tuple<int,int> SelectPiece(object sender)
        {
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
                            // Set the ImageLocation to hint.png
                            hints.Add(movePos);
                            movePictureBox.ImageLocation = "../../Images/Hint.png";
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
                    if (pictureBox.ImageLocation == "../../Images/Hint.png")
                        pictureBox.ImageLocation = "";
                }
            }
            hints.Clear();
        }
    }
}

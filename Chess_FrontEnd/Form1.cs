using Chess_FrontEnd.FormComponents;
using Sah_clases.Clases;
using Sah_clases.Clases.PIeces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Visual
{
    public partial class Form1 : Form
    {
        private const int gridSize = 8;
        private const int squareSize = 100; // Size of each square in pixels
        Board board;
        Tuple<int, int> SelectedPiece = new Tuple<int,int>(-1,-1);
        OnClickController comp;
        
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            comp = new OnClickController(board, pictureBox1);
        }

        private void InitializeGrid()
        {
            int totalSize = gridSize * squareSize;
            this.ClientSize = new Size(totalSize, totalSize);
            this.board = new Board();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Size = new Size(squareSize, squareSize),
                        Location = new Point(i * squareSize, j * squareSize),
                        BorderStyle = BorderStyle.FixedSingle, // Add border to visualize the grid
                        BackColor = (i + j) % 2 == 0 ? Color.White : Color.Black, // Alternate colors
                        Tag = new Tuple<int, int>(i, j)
                    };
                    PictureBox hintPictureBox = new PictureBox
                    {
                        Size = new Size(squareSize, squareSize),
                        Location = new Point(i * squareSize - pictureBox.Left, j * squareSize - pictureBox.Top),
                        ImageLocation = "../../Images/Hint.png",
                        Tag = new Tuple<int, int>(i, j),
                        BackColor = Color.Transparent,
                        Visible = false,
                    };
                    hintPictureBox.Click += hint_Click;
                    pictureBox.Controls.Add(hintPictureBox);


                    var poz = Tuple.Create(i, j);
                    if (board.ChessBoard.ContainsKey(poz) && board.ChessBoard[poz] is Pawn)
                    {
                        pictureBox.Click += new EventHandler(pictureBox_Click);
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        if (board.ChessBoard[poz].IsWhite)
                        pictureBox.ImageLocation = "../../Images/wp.png";
                        else if(!board.ChessBoard[poz].IsWhite)
                            pictureBox.ImageLocation = "../../Images/bp.png";
                    }
                    
                    pictureBox1.Controls.Add(pictureBox);
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            //if(SelectedPiece.Item1 == -1)
                SelectedPiece = comp.SelectPiece(sender);
            //else
            //{
            //    if(sender is PictureBox)
            //    {
            //        var pictureBox = sender as PictureBox;
            //        var dest = pictureBox.Tag as Tuple<int, int>;
            //        board.MovePiece(SelectedPiece,dest);
            //        RefreshBoard();
            //        pictureBox1.Invalidate();
            //    }

            //    SelectedPiece = Tuple.Create(-1, -1);
            //}
            
        }

        private void hint_Click(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            var dest = pictureBox.Tag as Tuple<int, int>;
            board.MovePiece(SelectedPiece, dest);
            comp.ResetHints();
            RefreshBoard();
        }

        /*private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            var initPoz = pictureBox.Tag as Tuple<int, int>;
            dest = Tuple.Create(initPoz.Item1, initPoz.Item2 - 1);
            board.MovePiece(initPoz, dest);
            RefreshBoard();
        }*/

        /*private void pictureBox_Click(object sender, EventArgs e)
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
                            movePictureBox.ImageLocation = "../../Images/Hint.png";
                        }
                    }
                }
            }
        }*/

        private void RefreshBoard()
        {
            foreach (Control control in pictureBox1.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = control as PictureBox;
                    Tuple<int, int> poz = pictureBox.Tag as Tuple<int, int>;

                    if (board.ChessBoard.ContainsKey(poz) && board.ChessBoard[poz] is Pawn)
                    {
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        pictureBox.Click += pictureBox_Click;
                        if (board.ChessBoard[poz].IsWhite)
                            pictureBox.ImageLocation = "../../Images/wp.png";
                        else
                            pictureBox.ImageLocation = "../../Images/bp.png";
                    }
                    else
                    {
                        pictureBox.ImageLocation = ""; // Clear the image if there's no piece on this square
                        pictureBox.Click -= pictureBox_Click;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
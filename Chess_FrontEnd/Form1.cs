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
        Tuple<int, int> dest = new Tuple<int,int>(0,0);
        
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
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

                    var poz = Tuple.Create(i, j);
                    if (board.ChessBoard.ContainsKey(poz) && board.ChessBoard[poz] is Pawn)
                    {
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        if (board.ChessBoard[poz].IsWhite)
                        pictureBox.ImageLocation = "../../Images/wp.png";
                        else
                            pictureBox.ImageLocation = "../../Images/bp.png";
                    }
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    pictureBox1.Controls.Add(pictureBox);
                }
            }
        }

         private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            var initPoz = pictureBox.Tag as Tuple<int,int>;
            dest = Tuple.Create(initPoz.Item1, initPoz.Item2 + 2);
            board.MovePiece(initPoz, dest);
            RefreshBoard();
        }

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
                        if (board.ChessBoard[poz].IsWhite)
                            pictureBox.ImageLocation = "../../Images/wp.png";
                        else
                            pictureBox.ImageLocation = "../../Images/bp.png";
                    }
                    else
                    {
                        pictureBox.ImageLocation = null; // Clear the image if there's no piece on this square
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
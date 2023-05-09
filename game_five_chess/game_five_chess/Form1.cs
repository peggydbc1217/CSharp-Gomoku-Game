using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_five_chess
{



    public partial class d : Form

    {
      private Game game = new Game();

        public d()
        {
            InitializeComponent();


            //this.Controls.Add(new BlackPiece(10, 20));
           // this.Controls.Add(new WhitePiece1(200, 200));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void d_MouseDown(object sender, MouseEventArgs e)
        {

            Piece piece = game.PlaceAPiece(e.X, e.Y);

            if (piece != null)
            {
                this.Controls.Add(piece);

                //檢查是否有人獲勝
                if (game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑色獲勝");

                    this.Controls.Clear();
                    

                }
                else if (game.Winner == PieceType.WHITE)
                {

                    MessageBox.Show("白色獲勝");

                    this.Controls.Clear();

                }

            }

        }

        private void d_MouseMove(object sender, MouseEventArgs e)
        {

            if(game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
                

  
            }
            else
            {
                this.Cursor = Cursors.Default;


            }


        }
    }
}

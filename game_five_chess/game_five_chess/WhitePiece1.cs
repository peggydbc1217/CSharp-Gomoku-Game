using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_five_chess
{
    class WhitePiece1:Piece
    {
        public WhitePiece1(int x, int y): base(x,y)
        {
            this.Image = Properties.Resources.white;


        }

        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;

        }


    }
}

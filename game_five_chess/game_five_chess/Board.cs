using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace game_five_chess
{
    class Board
    {

        public static readonly int NODE_COUNT = 9;

        private static readonly Point NO_NATCH_NODE = new Point(-1, -1);


        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        public Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];



        private Point lastPlacedNode = NO_NATCH_NODE;

        public Point LastPlacedNode { get { return lastPlacedNode; } }
        //  外面的人只能看 不能寫

        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {

            if (pieces[nodeIdX, nodeIdY] == null)
            {

                return PieceType.NONE;

            }

            else
            {
                return pieces[nodeIdX, nodeIdY].GetPieceType();

            }

        }


        public bool CanBePlaced(int x, int y)
        {

            //TO DO: 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y);

            //TO DO: 如果沒有 -->回傳false

            if (nodeId == NO_NATCH_NODE)
                return false;

            //TO DO :如果有 --> 檢查是否已經有旗子存在

            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return false;    //有的話 一樣回傳false

            }


            return true;


        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 找出最近的節點(Node)
            Point nodeId = FindTheClosetNode(x, y);

            //如果沒有 -->回傳false

            if (nodeId == NO_NATCH_NODE)
                return null;

            //如果有 --> 檢查是否已經有旗子存在

            if (pieces[nodeId.X, nodeId.Y] != null)
            {
                return null;    //如果有的話 回傳false

            }



            // 根據TYPE產生對應的棋子

            Point formPos = convertToFormPosition(nodeId);

            if (type == PieceType.BLACK)
            {

                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);

            }

            else if (type == PieceType.WHITE)
            {

                pieces[nodeId.X, nodeId.Y] = new WhitePiece1(formPos.X, formPos.Y);


            }

            //最後一次下的位置 存進去
            lastPlacedNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];


        }



        private Point convertToFormPosition(Point nodeID)
        {
            Point formPosition = new Point();

            formPosition.X = nodeID.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeID.Y * NODE_DISTANCE + OFFSET;

            return formPosition;

        }


        private Point FindTheClosetNode(int x, int y)
        {

            int nodelIdX = FindTheClosetNode(x);//對x做一次

            if (nodelIdX == -1 || nodelIdX >= NODE_COUNT)
            {
                return NO_NATCH_NODE;
            }

            int nodeIdY = FindTheClosetNode(y); //對y做一次

            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT)
            {
                return NO_NATCH_NODE;

            }

            return new Point(nodelIdX, nodeIdY);

        }

        private int FindTheClosetNode(int pos)
        {

            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;


            if (remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
            {
                return quotient + 1;
            }

            else
            {
                return -1;
            }
        }

        public void ResetPiece()
        {
            Array.Clear(pieces, 0, pieces.Length );

        }
        
    }



}


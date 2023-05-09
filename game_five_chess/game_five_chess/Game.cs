using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_five_chess
{
    class Game
    {

        private Board board = new Board();
        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winner = PieceType.NONE;
        public PieceType Winner { get { return winner; } }


        public bool CanBePlaced(int x, int y)

        {
            return board.CanBePlaced(x, y);

        }


        public Piece PlaceAPiece(int x, int y)

        {

            Piece piece = board.PlaceAPiece(x, y, currentPlayer);

            if (piece != null)
            {

                CheckWinner(); //每次要下棋時都檢查有沒有人勝利了

                //交換選手下棋
                if (currentPlayer == PieceType.BLACK)
                {
                    currentPlayer = PieceType.WHITE;
                }

                else if (currentPlayer == PieceType.WHITE)
                {
                    currentPlayer = PieceType.BLACK;

                }

                return piece;

            }

            return null;

        }


        private void CheckWinner()
        {
            int centerX = board.LastPlacedNode.X;
            int centerY = board.LastPlacedNode.Y;

            //檢查八個方位
            for (int xDIR = -1; xDIR <= 1; xDIR++)
            {
                for (int yDIR = -1; yDIR <= 1; yDIR++)
                {
                    //排除x=0,y=0的情況
                    if (xDIR == 0 && yDIR == 0)
                    {
                        continue;
                        //代表會略過這次回圈 直接跳到下次迴圈
                    }

                    //紀錄此方向  看到幾顆相同的棋子
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDIR;
                        int targetY = centerY + count * yDIR;

                        //檢查顏色是否相同 
                        //檢查是否放的棋子有超出邊界
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                        {
                            break;
                        }
                        count++;
                    }


                    int opposite_count = 1;
                    // 計算對邊有幾個棋子
                    while (opposite_count < 5)
                    {
                        int targetX = centerX - opposite_count * xDIR;
                        int targetY = centerY - opposite_count * yDIR;

                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                        targetY < 0 || targetY >= Board.NODE_COUNT ||
                        board.GetPieceType(targetX, targetY) != currentPlayer)
                        {
                            break;
                        }
                        opposite_count++;
                    }




                    //檢查是否看到五顆棋子,如果有,就判斷是誰贏
                    if (count == 5 || count + opposite_count > 5)
                    {
                        winner = currentPlayer;


                       // Console.WriteLine("count = " + count + " opposite = " + opposite_count);

                        board.ResetPiece();

                      


                    }
                }

            }


        }

    }

 }




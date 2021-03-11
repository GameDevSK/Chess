using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];
        Chessman currentChessman, c2;

        //for white
        if (isWhite)
        {
            if (CurrentX != 0 && CurrentY != 7)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX-1, CurrentY+1];
                if(currentChessman != null && !currentChessman.isWhite)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
            }

            if(CurrentX != 7 && CurrentY != 7)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX + 1, CurrentY + 1];
                if (currentChessman != null && !currentChessman.isWhite)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
            }
            if(CurrentY != 7)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX, CurrentY + 1];
                if (currentChessman == null)
                {
                    r[CurrentX, CurrentY + 1] = true;
                }
            }

            if(CurrentY == 1)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.chessmans[CurrentX, CurrentY + 2];
                if (currentChessman == null && c2 == null)
                {
                    r[CurrentX, CurrentY + 1] = true;
                    r[CurrentX, CurrentY + 2] = true;
                }
            }
        }
        else
        {
            //left diagonal
            if (CurrentX != 0 && CurrentY != 0)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX - 1, CurrentY - 1];
                if (currentChessman != null && currentChessman.isWhite)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
            }
            //right diagonal
            if (CurrentX != 7 && CurrentY != 7)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX + 1, CurrentY - 1];
                if (currentChessman != null && currentChessman.isWhite)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
            }

            //middle any where
            if (CurrentY != 0)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX, CurrentY - 1];
                if (currentChessman == null)
                {
                    r[CurrentX, CurrentY - 1] = true;
                }
            }
            //at starting
            if (CurrentY == 6)
            {
                currentChessman = BoardManager.Instance.chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.chessmans[CurrentX, CurrentY - 2];
                if (currentChessman == null && c2 == null)
                {
                    r[CurrentX, CurrentY - 1] = true;
                    r[CurrentX, CurrentY - 2] = true;
                }
            }
        }
        return r;
    }
}

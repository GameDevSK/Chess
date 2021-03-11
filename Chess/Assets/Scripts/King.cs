using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Chessman
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		Chessman c;

		//Top Side
		int tempX = CurrentX - 1;
		int tempY = CurrentY + 1;
		if(CurrentY != 7)
		{
			int i = 0;
			while(i < 3)
			{
				if(tempX>=0 || tempX < 8)
				{
					c = BoardManager.Instance.chessmans[tempX, tempY];
					if (c == null)
						r[tempX, tempY] = true;
					else if (c.isWhite != isWhite)
						r[tempX, tempY] = true;
				}
				i++;
				tempX++;
			}
		}

		//DownSide
		tempX = CurrentX - 1;
		tempY = CurrentY - 1;
		if(CurrentY != 0)
		{
			int i = 0;
			while (i < 3)
			{
				if (tempX >= 0 || tempX < 8)
				{
					c = BoardManager.Instance.chessmans[tempX, tempY];
					if (c == null)
						r[tempX, tempY] = true;
					else if (c.isWhite != isWhite)
						r[tempX, tempY] = true;
				}
				i++;
				tempX++;
			}
		}

		//Left
		if(CurrentX != 0)
		{
			c = BoardManager.Instance.chessmans[CurrentX - 1, CurrentY];
			if (c == null)
				r[CurrentX - 1, CurrentY] = true;
			else if(c.isWhite != isWhite)
				r[CurrentX - 1, CurrentY] = true;
		}
		//Right
		if(CurrentX != 7)
		{
			c = BoardManager.Instance.chessmans[CurrentX + 1, CurrentY];
			if (c == null)
				r[CurrentX + 1, CurrentY] = true;
			else if (c.isWhite != isWhite)
				r[CurrentX + 1, CurrentY] = true;
		}
		return r;
	}
}

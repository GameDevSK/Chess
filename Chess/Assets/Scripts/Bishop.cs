using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chessman
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		Chessman c;

		//diagonal up right
		int tempX = CurrentX;
		int tempY = CurrentY;
		while (true)
		{
			tempX++;tempY++;
			if (tempX > 7 || tempY > 7)
				break;

			c = BoardManager.Instance.chessmans[tempX, tempY];
			if (c == null)
				r[tempX, tempY] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[tempX, tempY] = true;
				break;
			}
		}

		//diagonal up left
		tempX = CurrentX;
		tempY = CurrentY;
		while (true)
		{
			tempX--; tempY++;
			if (tempX < 0 || tempY > 7)
				break;

			c = BoardManager.Instance.chessmans[tempX, tempY];
			if (c == null)
				r[tempX, tempY] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[tempX, tempY] = true;
				break;
			}
		}

		//diagonal down left
		tempX = CurrentX;
		tempY = CurrentY;
		while (true)
		{
			tempX--; tempY--;
			if (tempX < 0 || tempY < 0)
				break;

			c = BoardManager.Instance.chessmans[tempX, tempY];
			if (c == null)
				r[tempX, tempY] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[tempX, tempY] = true;
				break;
			}
		}

		//diagonal down right
		tempX = CurrentX;
		tempY = CurrentY;
		while (true)
		{
			tempX++; tempY--;
			if (tempX > 7 || tempY < 0)
				break;

			c = BoardManager.Instance.chessmans[tempX, tempY];
			if (c == null)
				r[tempX, tempY] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[tempX, tempY] = true;
				break;
			}
		}


		return r;
	}
}

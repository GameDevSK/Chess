using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Chessman
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		Chessman c;

		#region RookLikeMovement
		//right
		int temp = CurrentX;
		while (true)
		{
			temp++;
			if (temp > 7)
				break;

			c = BoardManager.Instance.chessmans[temp, CurrentY];
			if (c == null)
				r[temp, CurrentY] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[temp, CurrentY] = true;
				break;
			}
		}

		//left
		temp = CurrentX;
		while (true)
		{
			temp--;
			if (temp < 0)
				break;

			c = BoardManager.Instance.chessmans[temp, CurrentY];
			if (c == null)
				r[temp, CurrentY] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[temp, CurrentY] = true;
				break;
			}
		}
		//up
		temp = CurrentY;
		while (true)
		{
			temp++;
			if (temp > 7)
				break;

			c = BoardManager.Instance.chessmans[CurrentX, temp];
			if (c == null)
				r[CurrentX, temp] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[CurrentX, temp] = true;
				break;
			}
		}
		//down
		temp = CurrentY;
		while (true)
		{
			temp--;
			if (temp < 0)
				break;

			c = BoardManager.Instance.chessmans[CurrentX, temp];
			if (c == null)
				r[CurrentX, temp] = true;
			else
			{
				if (c.isWhite != isWhite)
					r[CurrentX, temp] = true;
				break;
			}
		}
		#endregion

		#region BishopLikeMovement
		//diagonal up right
		int tempX = CurrentX;
		int tempY = CurrentY;
		while (true)
		{
			tempX++; tempY++;
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
		#endregion

		return r;
	}
}

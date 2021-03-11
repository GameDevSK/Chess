using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chessman
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		Chessman c;

		//right
		int temp = CurrentX;
		while (true)
		{
			temp++;
			if (temp > 7)
				break;
			
			c = BoardManager.Instance.chessmans[temp, CurrentY];
			if(c == null)
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
		return r;
	}
}

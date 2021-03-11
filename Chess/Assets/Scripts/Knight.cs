using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chessman
{
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		//Upright
		KnightMovement(CurrentX + 1, CurrentY + 2, ref r);

		//UpLeft
		KnightMovement(CurrentX - 1, CurrentY + 2, ref r);

		//LeftUp
		KnightMovement(CurrentX - 2, CurrentY + 1, ref r);

		//LeftDown
		KnightMovement(CurrentX - 2, CurrentY - 1, ref r);

		//DownLeft
		KnightMovement(CurrentX - 1, CurrentY - 2, ref r);

		//DownRight
		KnightMovement(CurrentX + 1, CurrentY - 2, ref r);

		//RightDown
		KnightMovement(CurrentX + 2, CurrentY - 1, ref r);

		//RightUp
		KnightMovement(CurrentX + 2, CurrentY + 1, ref r);
		return r;
	}

	void KnightMovement(int x, int y, ref bool[,] r)
	{
		if((x >= 0 && x < 8) && (y >=0 && y < 8))
		{
			Chessman c = BoardManager.Instance.chessmans[x, y];
			if (c == null)
				r[x, y] = true;
			else if (c.isWhite != isWhite)
				r[x, y] = true;
		}
	}
}

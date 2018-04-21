using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chessman {





	public int[,] evaluates= new int[8,8]{{24,57,96,114,114,96,57,24},
		{20,47,80,95,95,80,47,2},
		{16,38,64,76,76,64,38,16},
		{12,28,48,57,57,48,28,12},
		{8,19,32,38,38,32,19,8},
		{4,9,16,19,19,16,9,4},
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0}};



	void Start(){

		manevaluate = 120;

	}





	public override int GetEvaluate ()
	{
		int	posevaluate = evaluates [CurrentX, CurrentY];

		KnighPossibletmove(CurrentX - 1, CurrentY + 2,ref posevaluate);

		//upright
		KnighPossibletmove (CurrentX -+1, CurrentY + 2, ref posevaluate);

		//rightup
		KnighPossibletmove (CurrentX + 2, CurrentY + 1, ref posevaluate);

		//rightdown
		KnighPossibletmove (CurrentX +2, CurrentY -1, ref posevaluate);

		//downleft
		KnighPossibletmove(CurrentX - 1, CurrentY - 2, ref posevaluate);

		//downrigt
		KnighPossibletmove (CurrentX + 1, CurrentY - 2, ref posevaluate);

		//leftup
		KnighPossibletmove (CurrentX - 2, CurrentY -1, ref posevaluate);

		//leftdown
		KnighPossibletmove  (CurrentX - 2, CurrentY -1, ref posevaluate);

		return posevaluate;
	}















	public override bool[,] PossibleMove(){

		bool[,]r =new bool[8,8];
		//upleft
		Knightmove (CurrentX - 1, CurrentY + 2, ref r);

		//upright
		Knightmove (CurrentX +1, CurrentY + 2, ref r);

		//rightup
		Knightmove (CurrentX + 2, CurrentY + 1, ref r);
	
		//rightdown
		Knightmove (CurrentX +2, CurrentY -1, ref r);
	
		//downleft
		Knightmove (CurrentX - 1, CurrentY - 2, ref r);

		//downrigt
		Knightmove (CurrentX + 1, CurrentY - 2, ref r);
	
		//leftup
		Knightmove (CurrentX - 2, CurrentY -1, ref r);
	
		//leftdown
		Knightmove (CurrentX - 2, CurrentY -1, ref r);
		return r;


	}



	public void Knightmove(int x,int y,ref bool[,] r){

		Chessman c;
		if (x >= 0 && x < 8 && y >= 0 && y < 8) {

			c = BoardManager.Instance.Chessmans [x, y];
			if (c == null)
				r [x, y] = true;
			else if (isWhite != c.isWhite)
				r [x, y] = true;

		}
	}



	public void KnighPossibletmove(int x,int y,ref int posevaluate){

		Chessman c;
		if (x >= 0 && x < 8 && y >= 0 && y < 8) {

			c = BoardManager.Instance.Chessmans [x, y];
			if (c == null)
				posevaluate = 50;
			else if (isWhite != c.isWhite) {

				if (c.GetType () == typeof(King))
					posevaluate = 1200;

				if (c.GetType () == typeof(Queen))
					posevaluate = 900;
				if (c.GetType () == typeof(Bishop))
					posevaluate = 400;
				if (c.GetType () == typeof(Rook))
					posevaluate = 600;
				if (c.GetType () == typeof(Knight))
					posevaluate = 400;
				if (c.GetType () == typeof(Pawn))
					posevaluate = 100;


			}

		}
	}


}

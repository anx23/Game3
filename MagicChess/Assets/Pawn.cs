using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman {


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



		///
		Chessman c, c2;

		if (isWhite) {

			if (CurrentX != 0 && CurrentY != 7) {
				c = BoardManager.Instance.Chessmans [CurrentY - 1, CurrentY + 1];
				if (c != null && !c.isWhite) {

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
			if (CurrentX != 7 && CurrentY != 7) {
				c = BoardManager.Instance.Chessmans [CurrentX+ 1, CurrentY + 1];

				if (c != null && !c.isWhite) {

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


			if (CurrentY != 7) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];

				if (c != null && !c.isWhite) {

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

			if (CurrentY == 1) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];
				c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 2];
				if (c == null && c2 == null)
					posevaluate = 50;
					//r [CurrentX , CurrentY + 2] = true;
			}


			//r [CurrentX , CurrentY + 1] = true;
		} else {

			if (CurrentX != 0 && CurrentY != 0) {
				c = BoardManager.Instance.Chessmans [CurrentY - 1, CurrentY -1];
				if (c != null && !c.isWhite) {

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

			if (CurrentX != 7 && CurrentY != 0) {
				c = BoardManager.Instance.Chessmans [CurrentX+ 1, CurrentY - 1];
				if (c != null && !c.isWhite) {

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


			if (CurrentY != 0) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 1];
				if (c == null)
					posevaluate = 50;
			}

			if (CurrentY == 6) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 1];
				c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 2];
				if (c == null && c2 == null)
					posevaluate = 50;
			}

		}







				return posevaluate;

	}



	public override bool[,] PossibleMove()
	{

		bool[,] r = new bool[8, 8];
		//r [3, 3] = true;

		Chessman c, c2;

		if (isWhite) {
			
			if (CurrentX != 0 && CurrentY != 7) {
				c = BoardManager.Instance.Chessmans [CurrentY - 1, CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX - 1, CurrentY + 1] = true;
			}

			if (CurrentX != 7 && CurrentY != 7) {
				c = BoardManager.Instance.Chessmans [CurrentX+ 1, CurrentY + 1];
				if (c != null && !c.isWhite)
					r [CurrentX + 1, CurrentY + 1] = true;
			}


			if (CurrentY != 7) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];
				if (c == null )
					r [CurrentX , CurrentY + 1] = true;
			}

			if (CurrentY == 1) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 1];
				c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY + 2];
				if (c == null &&c2==null)
					r [CurrentX , CurrentY + 2] = true;
			}


			//r [CurrentX , CurrentY + 1] = true;
		} else {

			if (CurrentX != 0 && CurrentY != 0) {
				c = BoardManager.Instance.Chessmans [CurrentY - 1, CurrentY -1];
				if (c != null && c.isWhite)
					r [CurrentX - 1, CurrentY - 1] = true;
			}

			if (CurrentX != 7 && CurrentY != 0) {
				c = BoardManager.Instance.Chessmans [CurrentX+ 1, CurrentY - 1];
				if (c != null && c.isWhite)
					r [CurrentX + 1, CurrentY -1] = true;
			}


			if (CurrentY != 0) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 1];
				if (c == null )
					r [CurrentX , CurrentY - 1] = true;
			}

			if (CurrentY == 6) {
				c = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 1];
				c2 = BoardManager.Instance.Chessmans [CurrentX, CurrentY - 2];
				if (c == null &&c2==null)
					r [CurrentX , CurrentY -2] = true;
			}

		}



		return r;

	}

}

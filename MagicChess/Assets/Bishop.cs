using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chessman {


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


		Chessman c;


		int i, j;

		//top left
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j++;
			if (i < 0 || j >= 8)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				posevaluate = 50;
			else {
				if (isWhite != c.isWhite)
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



				break;

			}

		}

		//top right
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j++;
			if (i >=8 || j >= 8)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				posevaluate = 50;
			else {
				if (isWhite != c.isWhite)
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



				break;

			}

		}

		//down left
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j--;
			if (i < 0 || j <0)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				posevaluate = 50;
			else {
				if (isWhite != c.isWhite)
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



				break;

			}

		}


		//down right
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j--;
			if (i >=8 || j <0)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				posevaluate = 50;
			else {
				if (isWhite != c.isWhite)
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



				break;

			}

		}


		return posevaluate;

	}








	public override bool[,] PossibleMove()
	{

		bool[,] r = new bool[8, 8];
		//r [3, 3] = true;

		Chessman c;


		int i, j;

		//top left
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j++;
			if (i < 0 || j >= 8)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;

			}

		}

		//top right
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j++;
			if (i >=8 || j >= 8)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;

			}

		}

		//down left
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i--;
			j--;
			if (i < 0 || j <0)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;

			}

		}


		//down right
		i=CurrentX;
		j = CurrentY;
		while (true) {
			i++;
			j--;
			if (i >=8 || j <0)
				break;

			c = BoardManager.Instance.Chessmans [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isWhite != c.isWhite)
					r [i, j] = true;

				break;

			}

		}
		return r;


	}
}

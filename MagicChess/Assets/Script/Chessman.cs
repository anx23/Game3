using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Chessman : MonoBehaviour {

	public int CurrentX{ set; get;}

	public int CurrentY{ set;get;}

	public bool isWhite;
	public int manevaluate;
	// Use this for initialization
//ai評価
	public int[] chessmanEva = new int[]{1000,1200,600,400,400,120 };



	public void Setposition(int x,int y){
		CurrentX = x;
		CurrentY = y;
	}

	//動ける範囲
	public virtual bool[,]  PossibleMove(){
		return new bool[8,8];
	

		//return true;
	}

	public virtual void PositionEvaluate(){
		

	}



	public virtual int GetEvaluate(){

		return  1;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChessAI : MonoBehaviour{

	// Use this for initialization


	public Chessman[,] selectableChessmans;
	private bool[,] allowedMove{ set; get; }

	public bool isBlack=true;
	Text turnText;
	bool isRunning;
	/*
	public int[,] evaluates= new int[8,8]{{24,57,96,114,114,96,57,24},
		{20,47,80,95,95,80,47,2},
		{16,38,64,76,76,64,38,16},
		{12,28,48,57,57,48,28,12},
		{8,19,32,38,38,32,19,8},
		{4,9,16,19,19,16,9,4},
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0}};

*/
	BoardManager manager;


	void Start () {
		manager = GetComponent<BoardManager> ();
		turnText = GameObject.Find ("Turn").GetComponent<Text> ();
		/*
		foreach(GameObject go in activeChessman){

			EnemyChessmansobj.Add (go);
		}


	*/
	}

	/*

	List<Chessman> PutabletChessman(){

		var putableChesmasns =new List<Chessman>();
		for (int i = 0; i <= 8; i++) {

			for (int j = 0; j <= 8; j++) {
				bool[,] allowedMove=EnemyChessmans [i, j].PossibleMove ();
				if (allowedMove[i,j]) {
					//selectableChessmans[i,j]
					putableChesmasns.Add(EnemyChessmans[i,j]);
				}

			}

			}
		return putableChesmasns;
	}
*/
	/*
	void PutChessman(){

	

		int max;
		max = 0;

		int selectx = 0, selecty = 0;
		int movex = 0, movey = 0;

	


	

		foreach (Chessman c in manager.EnemyChessmans) {

			allowedMove= c.PossibleMove ();

			//if(c.PossibleMove())
			for (int i = 0; i <8; i++) {

				for (int j = 0; j < 8; j++) {
					if (allowedMove [i, j]) {
						int ev=c.GetEvaluate();
						if (ev >= max) {
							max = ev;
						
							selectx = c.CurrentX;
							selecty = c.CurrentY;
							movex = i;
							movey = j;
						}

					}
				}
			}


		}

		Debug.Log ("選択"+selectx+":"+ selecty);
		Debug.Log ("移動"+movex+":"+ movey);

	}


	void SelectAattackaer(){
		int count = manager.EnemyChessmans.Count;

		int rand = Random.Range (0,count);
		manager.EnemyChessmans [rand].GetComponent<Character >().Attack ();
		//StartCoroutine ("ChangeTurn");
		manager.isWhiteTurn = true;
	}
	*/

	IEnumerator ChangeTurn(){
		if (isRunning)
			yield break;
		isRunning = true;

		int count = manager.EnemyChessmans.Count;
		int rand = Random.Range (0,count);
		manager.EnemyChessmans [rand].GetComponent<Character >().Attack ();
		yield return new WaitForSeconds (3.5f);
		turnText.text = "YOU";
		manager.isWhiteTurn = true;
		isRunning = false;
	}





	// Update is called once per frame
	void Update () {
		/*
		if (manager.turncount < 5) {
			if (!manager.isWhiteTurn) {
				Opening ();

				manager.turncount++;
				manager.isWhiteTurn = true;
			}
		} else {
			if (!manager.isWhiteTurn) {

				PutChessman ();
				//manager.isWhiteTurn = true;
			}
		}
		}*/

		if (!manager.isWhiteTurn) {
			StartCoroutine (ChangeTurn());
			//SelectAattackaer ();
			//manager.isWhiteTurn = true;
		}


	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlight : MonoBehaviour {


	public static BoardHighlight Instance{ set; get; }

	public  GameObject highlightPrefab;
	private List<GameObject> highlights;


	// Use this for initialization
	void Start () {
		Instance = this;
		highlights = new List<GameObject> ();
	}




	private GameObject GetHighlightObject(){
		
		GameObject go = highlights.Find (g=>!g.activeSelf);

		if (go == null) {
			go = Instantiate (highlightPrefab);
			highlights.Add (go);

		}
		return go;
	}

	//動ける場所表示
	public void HighlightAllowedMoves(bool[,] moves){
		for(int i=0;i<8;i++){
			for(int j=0;j<8;j++){
				if (moves [i, j]) {
					GameObject	go;
					//if (highlights [i, j] == null) {
							go = Instantiate (highlightPrefab);
						highlights.Add (go);

					//}
					//GameObject go = GetHighlightObject ();
					go.SetActive (true);
					go.transform.position = new Vector3 (i+0.5f,0,j+0.5f);
				}


			}


		}

	}



	public void Hidehighlits(){

		foreach (GameObject go in highlights)
			go.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}

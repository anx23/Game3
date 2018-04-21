using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLife : MonoBehaviour {


	public int hp=5;
	[SerializeField]
	bool isKing=false;
	GameObject resultPanel;
	BoardManager manager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//ダメージ処理
	public  void DedectHealth(int attack){
		Debug.Log ("damage");
		StartCoroutine ("ChangeMaterial");
		hp -= attack;

		if(hp<=0)
		DeathChessman ();
	}


	public void DeathChessman(){


			Destroy (gameObject);
		if (isKing) {
			Debug.Log ("LOSE");
			GameObject.Find ("GameManager").GetComponent<BoardManager>().EndGame("負け");
		
				//resultPanel.SetActive (true);


		}
	}

	IEnumerator ChangeMaterial(){
		GetComponent<MeshRenderer> ().material.color = Color.red;
		yield return new WaitForSeconds (0.5f);

		GetComponent<MeshRenderer> ().material.color = Color.white;
	}
}

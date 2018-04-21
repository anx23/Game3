using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack2 : MonoBehaviour {
	float time=3.0f;
	public bool hitdestroy;

	int power=1;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0)
			Destroy (gameObject);
		
	}

	void OnTriggerEnter(Collider col){
	//	Debug.Log ("hit");
		if (col.gameObject.tag == "Player") {
			Debug.Log ("hit");
				col.GetComponent<ChessLife> ().DedectHealth (power);
			if (hitdestroy)
				Destroy(gameObject);
		}

	}



}

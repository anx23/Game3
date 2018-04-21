using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack1 : MonoBehaviour {


	float time=10.0f;
	public bool hitdestroy;
	float speed=2.0f;
	public int power=1;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (transform.forward*Time.deltaTime*-speed);

		time -= Time.deltaTime;
		if (time <= 0)
			Destroy (gameObject);

	}

	void OnTriggerEnter(Collider col){
		

		if (col.gameObject.tag == "Player") {
			Debug.Log ("hit");
			col.GetComponent<ChessLife> ().DedectHealth (power);
			if (hitdestroy)
				Destroy (gameObject);


		}
	}







}

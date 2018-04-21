using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Character {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public override void Attack(){
		Debug.Log ("Attack2");
		//Instantiate (shot,muzzle.transform.position,muzzle.transform.rotation);
	}



}

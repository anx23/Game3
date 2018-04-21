using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 :Character {


	public GameObject shot;
	public Transform muzzle;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public override void Attack(){
		Debug.Log ("Attack1");
		Instantiate (shot,muzzle.transform.position,muzzle.transform.rotation);
	}




}

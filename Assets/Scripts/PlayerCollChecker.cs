using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollChecker : MonoBehaviour {

	private bool trespassing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Bar") {
			trespassing = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Bar") {
			trespassing = false;
		}
	}

	public bool GetTrespassingState(){
		return trespassing;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChecker2 : MonoBehaviour {


	public NPCradar npcScript;
	public NpcDownW npcControl;
	public LookAt islooking;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			npcScript.FieldOfViewEnter();
			islooking.isLooking = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			//Debug.Log ("OUT");
			npcScript.FieldOfViewExit();
			islooking.isLooking = false;
		}

	}
}

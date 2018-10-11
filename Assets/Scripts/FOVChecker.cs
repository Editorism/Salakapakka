using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			GetComponentInParent<NPCradar> ().FieldOfViewEnter ();
			if (col.GetComponent<PlayerCollChecker> ().GetTrespassingState () == true) {
				GetComponentInParent<NPCradar> ().PlayerTrespassing ();
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			GetComponentInParent<NPCradar> ().FieldOfViewExit ();
			GetComponentInParent<NPCradar> ().PlayerNotTrespassing ();
		}
	}
}

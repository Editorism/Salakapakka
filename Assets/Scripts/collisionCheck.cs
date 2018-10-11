using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionCheck : MonoBehaviour {

	public bool isColliding;

	// Use this for initialization
	void Start () {
		isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col) {
		if (col.transform.tag != "Floor" && col.transform.tag != "Player" && col.isTrigger == false) {
			isColliding = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.transform.tag != "Floor" && col.transform.tag != "Player" && col.isTrigger == false) {
			isColliding = false;
		}
	}
}

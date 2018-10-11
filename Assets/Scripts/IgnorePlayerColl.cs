using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerColl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.transform.tag == "Player") {
			Physics.IgnoreCollision(gameObject.GetComponent<CapsuleCollider>(), collision.transform.GetComponent<CapsuleCollider>());
		}
	}
}

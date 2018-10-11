using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetUp (OVRInput.Button.PrimaryIndexTrigger)) {
			Debug.Log ("Trigger up");
		
		}
	}
}

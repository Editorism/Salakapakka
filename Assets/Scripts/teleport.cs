using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public Transform playerChar;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){
			Vector3 fwd = transform.forward;
			playerChar.SetPositionAndRotation(fwd * 2, Quaternion.identity);
	}
}
}

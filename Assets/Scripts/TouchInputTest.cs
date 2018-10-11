using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchInputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).y < 0 && OVRInput.Get(OVRInput.Button.PrimaryTouchpad)) {
			SceneManager.LoadScene (0);
		}
		if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).y > 0 && OVRInput.Get(OVRInput.Button.PrimaryTouchpad)) {
			transform.position = new Vector3 (50,50,50);
		}

	}
}

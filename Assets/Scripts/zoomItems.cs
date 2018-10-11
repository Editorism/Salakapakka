using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zoomItems : MonoBehaviour {


	private rayTeleport rayScript;
	// Use this for initialization
	void Start () {
		rayScript = GetComponent<rayTeleport> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rayScript.grabbedObj != null) {
			if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).y < 0 && OVRInput.Get (OVRInput.Button.PrimaryTouchpad)) {
				rayScript.transform.position += (rayScript.transform.position - this.transform.position).normalized;
				SceneManager.LoadScene (0);
			}
			if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).y > 0 && OVRInput.Get (OVRInput.Button.PrimaryTouchpad)) {
				rayScript.transform.position -= (rayScript.transform.position - this.transform.position).normalized;
			}
		}
	}
}

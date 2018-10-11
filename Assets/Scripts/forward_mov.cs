using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forward_mov : MonoBehaviour {




	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {




		if (Input.GetKey (KeyCode.R))
			Application.LoadLevel (Application.loadedLevel);


		if (Input.GetKey (KeyCode.W)) {

			transform.GetComponent<Animator> ().applyRootMotion = false;
			transform.GetComponent<Animator> ().SetBool ("walk", true);
			transform.Translate (0, 0, Time.deltaTime, transform);
			transform.position = new Vector3 (0, transform.position.y, transform.position.z);


		}
		else
			transform.GetComponent<Animator> ().SetBool ("walk", false);



		
	}
}

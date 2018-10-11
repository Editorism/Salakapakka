using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	private GameObject character;
	private Camera cam;
	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectsWithTag ("Player") [0];
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 1) {
			this.transform.position = character.transform.position + cam.transform.forward.normalized * 2;
		}

		Vector3 lookPos = transform.position - character.transform.position;
		lookPos.y = 0;
		this.gameObject.transform.rotation = Quaternion.LookRotation (lookPos);
	}
}

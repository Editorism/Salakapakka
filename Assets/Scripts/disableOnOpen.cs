using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableOnOpen : MonoBehaviour {

	private GameController controller;
	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.orderMenu == true) {
			gameObject.SetActive (false);
		}
	}
}

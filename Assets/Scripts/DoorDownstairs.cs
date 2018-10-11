using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDownstairs : MonoBehaviour {

	private GameController controller;
	private Animator anim;


	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.bIndexList[5] == true) {
			anim.SetBool ("isOpen", true);
		}
	}


}

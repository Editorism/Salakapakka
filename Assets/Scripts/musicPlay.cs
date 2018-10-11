using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlay : MonoBehaviour {

	private AudioSource myAudio;
	private GameObject cafeAmbience;
	private List<AudioSource> ambientList;
	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource> ();
		cafeAmbience = GameObject.FindGameObjectWithTag ("Ambient");
		ambientList = new List<AudioSource> (cafeAmbience.GetComponents<AudioSource>());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			myAudio.mute = false;
			ambientList [1].mute = false;
			ambientList [0].mute = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			myAudio.mute = true;
			ambientList [1].mute = true;
			ambientList [0].mute = false;
		}
	}
}

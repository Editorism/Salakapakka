using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonState : MonoBehaviour{


	private Button but;
	private AudioSource aud;
	// Use this for initialization
	void Start () {
		but = GetComponent<Button> ();
		aud = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void playSound(){
		aud.Play ();
	}
		
}

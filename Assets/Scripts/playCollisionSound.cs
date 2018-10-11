using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playCollisionSound : MonoBehaviour {

	private AudioSource colSound;
	private Rigidbody rBody;
	// Use this for initialization
	void Start () {

		rBody = GetComponent<Rigidbody> ();
		colSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		colSound.volume = rBody.velocity.magnitude;
		colSound.Play();
	}
}

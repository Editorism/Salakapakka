using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour {

	public float smooth = 1f;
	private Vector3 targetAngles;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		targetAngles = this.transform.localEulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void openCredits(){
		anim.SetBool ("isCredits", true);
	}

	public void closeCredits(){
		anim.SetBool ("isCredits", false);
	}
}

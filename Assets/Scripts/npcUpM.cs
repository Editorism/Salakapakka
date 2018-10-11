using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcUpM : MonoBehaviour {


	private Animator anim;
	private bool isAlerted = false;
	private bool isStaggered = false;
	private LookAt look;
	private NPCradar alertLvl;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		look = GetComponent<LookAt> ();
		alertLvl = GetComponent<NPCradar> ();
	}
	
	// Update is called once per frame
	void Update () {
		int idleID = Random.Range(0,2);
		anim.SetInteger ("idleID", idleID);
		if (alertLvl.alertLevel <= 0) {
			isAlerted = false;
			anim.SetBool ("isAlerted", isAlerted);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.transform.tag == "Player"){
			Debug.Log ("Enter");
			isStaggered = false;
			isAlerted = true;
			anim.SetBool ("isLooking", true);
			anim.SetBool ("isAlerted", isAlerted);
			look.isLooking = true;
			look.t = 0;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.transform.tag == "Player") {
			Debug.Log ("Exit");
			isAlerted = false;
			anim.SetBool ("isLooking", false);
			anim.SetBool ("isAlerted", isAlerted);
			look.isLooking = false;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.transform.tag == "Grabbable") {
			isStaggered = true;
			isAlerted = true;
			anim.SetBool ("isAlerted", isAlerted);
			anim.SetBool ("isStaggered", isStaggered);
		}
	}

	void OnCollisionExit(Collision col){
		if (col.transform.tag == "Grabbable"){
			isStaggered = false;
			isAlerted = true;
			anim.SetBool ("isAlerted", isAlerted);
			anim.SetBool ("isStaggered", isStaggered);
		}
	}
		
}

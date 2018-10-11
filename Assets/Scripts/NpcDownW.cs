using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDownW : MonoBehaviour {

	private Animator anim;
	private LookAt look;
	private NPCradar alertLvl;
	private bool isAlerted = false;
	private bool isStaggered = false;
	private bool inFOV = false;
	private NPCradar myRadar;
	public bool isWalking = false;
	public Renderer rag;
	public Renderer glass;



	// Use this for initialization
	void Start () {

		myRadar = gameObject.GetComponent<NPCradar> ();
		anim = GetComponent<Animator> ();
		look = GetComponent<LookAt> ();
		alertLvl = GetComponent<NPCradar> ();
		alertLvl.isWalking = false;
	}
	
	// Update is called once per frame
	void Update () {
		alertLvl.isWalking = isWalking;
		int idleID = Random.Range(0,2);
		anim.SetInteger ("idleID", idleID);
		if (alertLvl.alertLevel <= 0) {
			
	//		Debug.Log ("not alerted");
			isAlerted = false;
			anim.SetBool ("isAlerted", isAlerted);
			anim.SetFloat ("mySpeed", 1.0f);
		} else if (isWalking) {

			isAlerted = true;
//			Debug.Log (isAlerted.ToString());
			anim.SetBool ("isAlerted", isAlerted);
			anim.GetBool ("isAlerted");
			anim.SetFloat ("mySpeed", 0.0f);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.transform.tag == "Grabbable") {
			anim.SetTrigger ("isStaggered");
		}
	}

	public void enablePolish(){
		rag.enabled = true;
		glass.enabled = true;
	}

	public void disablePolish(){
		rag.enabled = false;
		glass.enabled = false;
	}

/*	void OnTriggerEnter(Collider col){
		if (col.transform.tag == "Player"){
			isStaggered = false;
			isAlerted = true;
			anim.SetBool ("isAlerted", isAlerted);
			look.isLooking = true;
			look.t = 0;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.transform.tag == "Player") {
			isAlerted = false;
			anim.SetBool ("isAlerted", isAlerted);
			look.isLooking = false;
		}
	}*/
}

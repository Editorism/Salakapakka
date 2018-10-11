using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideShowObject : MonoBehaviour {

	public GameObject beltRag;
	public GameObject handRag;
	public GameObject glass;
	public int laskuri;  //katsotaan vain missä "tilassa" ollaan


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {



		//string s = GetComponent<Animator> ().GetCurrentAnimatorStateInfo ().normalizedTime.ToString ();

		//print ("----------------LASKURI----------------- "+ s);

		
	}


	void showhide(int objectsToHideShow){

		//this.gameObject.SetActive (false);

		//print ("NO JOHAN POMPPAS...");


		//wipe beltRag visible
		if (objectsToHideShow == 0) {
			beltRag.GetComponent<MeshRenderer> ().enabled = true;
			handRag.GetComponent<MeshRenderer> ().enabled = false;

			laskuri = 0;

		}


		//wipe handRag visible
		if (objectsToHideShow == 1) {
			handRag.GetComponent<MeshRenderer> ().enabled = true;
			beltRag.GetComponent<MeshRenderer> ().enabled = false;

			laskuri = 1;

		}


		//polish beltRag visible
		if (objectsToHideShow == 2) {
			beltRag.GetComponent<MeshRenderer> ().enabled = true;
			handRag.GetComponent<MeshRenderer> ().enabled = false;


			laskuri = 2;

		}

		 

		//polish handRag visible
		if (objectsToHideShow == 3) {
			handRag.GetComponent<MeshRenderer> ().enabled = true;
			beltRag.GetComponent<MeshRenderer> ().enabled = false;

			laskuri = 3;

		}



//		//handRag and Glass visible, beltrag invisible
//		if (objectsToHideShow == 2) {
//			handRag.GetComponent<MeshRenderer> ().enabled = true;
//			glass.GetComponent<MeshRenderer> ().enabled = true;
//			beltRag.GetComponent<MeshRenderer> ().enabled = false;
//
//			laskuri = 2;


//		}
			

	}

}

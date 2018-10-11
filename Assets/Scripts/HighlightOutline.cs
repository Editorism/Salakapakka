using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOutline : MonoBehaviour {

	private Material mat;

	// Use this for initialization
	void Start () {
		mat = this.GetComponent<Renderer> ().material;
		mat.SetFloat ("_Outline", 0.0f);
		enableOutline ();
	}
	
	// Update is called once per frame
	public void Update () {

	}

	public void enableOutline() {
		mat.SetFloat ("_Outline", 0.0115f);
		StartCoroutine (afterFlick());


	}

	public void disableOutline() {
		mat.SetFloat ("_Outline", 0.0f);
	}

	IEnumerator afterFlick() {
		yield return new WaitForSeconds (2);
		disableOutline ();
	}
}

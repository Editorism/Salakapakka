using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credits : MonoBehaviour {

	// Use this for initialization

	public Text[] textList;
	private int i = 0;
	void Start () {
		onClick ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		if (i > textList.Length) {
			this.enabled = false;
		}

		else {
			foreach (Text text in textList) {
				text.enabled = false;
			}
			Debug.Log ("Enabling text");
			textList [i].enabled = true;
			i += 1;
		}
	}
}

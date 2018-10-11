using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateUI : MonoBehaviour {


	public GameObject character;
	public Text text;
	private float timer;
	private bool isShowing;
	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectWithTag ("Player");
		isShowing = false;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CalculateRotation ();

		if (isShowing && timer < 5) {
			timer += Time.deltaTime;
		} else {
			text.text = "";
			isShowing = false;
			timer = 0;
		}
	}

	private void CalculateRotation(){
		Vector3 lookPos = transform.position - character.transform.position;
		lookPos.y = 0;
		this.transform.rotation = Quaternion.LookRotation (lookPos);
	}

	public void ShowSubtitle(string subtitle) {
		isShowing = true;
		text.text = subtitle;
		timer = 0;
	}


}

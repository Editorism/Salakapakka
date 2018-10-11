using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemUi : MonoBehaviour {


	private GameObject character;
	public float upSpeed;
	public string pickUpTextEng;
	public string pickUpTextFin;
	private Text textItem;
	public bool isEnabled = false;
	private bool isPlayed = false;
	private AudioSource audio;
	public float showTime = 2.5f;

	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectsWithTag ("Player") [0];
		textItem = this.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ();
		audio = GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("Language") > 0) {
			textItem.text = pickUpTextFin;
		} else {
			textItem.text = pickUpTextEng;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled) {
			CalculateRotation ();
			if (!audio.isPlaying && !isPlayed) {
				audio.Play();
				isPlayed = true;
			}
		}
	}

	public void CalculateRotation(){
		isEnabled = true;
		Vector3 lookPos = transform.position - character.transform.position;
		lookPos.y = 0;
		gameObject.transform.rotation = Quaternion.LookRotation (lookPos);
		gameObject.transform.eulerAngles = new Vector3 (0.0f, gameObject.transform.eulerAngles.y, 0.0f);
		transform.position += Vector3.up * upSpeed;
		StartCoroutine (MoveWait());

	}

	IEnumerator MoveWait(){
		yield return new WaitForSeconds (showTime);
		Destroy (gameObject);
	}

}


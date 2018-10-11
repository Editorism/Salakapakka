using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playHints : MonoBehaviour {

	public AudioSource hintSound;
	public AudioSource hintSound2;
	public string hint1fi;
	public string hint2fi;
	public string hint1en;
	public string hint2en;
	public rotateUI subtitleUI;

	private int playIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playHintSound(){
		if (GetComponent<LookAt> ().isLooking && !hintSound.isPlaying && !hintSound2.isPlaying) {
			if (playIndex == 0) {
				hintSound.Play ();

				if (PlayerPrefs.GetInt ("Language") == 1) {
					subtitleUI.ShowSubtitle (hint1fi);
				} else {
					subtitleUI.ShowSubtitle (hint1en);
				}

				Debug.Log ("hint sound1");
			} else {
				hintSound2.Play ();
				if (PlayerPrefs.GetInt ("Language") == 1) {
					subtitleUI.ShowSubtitle (hint2fi);
				} else {
					subtitleUI.ShowSubtitle (hint2en);
				}
				Debug.Log ("hint sound2");
			}
			playIndex += 1;
			playIndex = playIndex % 2;
		}
	}
}

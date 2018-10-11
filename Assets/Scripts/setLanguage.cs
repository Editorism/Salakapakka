using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setLanguage : MonoBehaviour {

	public string englishText;
	public string finnishText;
	private Text textObj;
	// Use this for initialization
	void Start () {
		if (tag != "Credits") {
			textObj = GetComponent<Text> ();
			if (PlayerPrefs.GetInt ("Language") > 0) {
				textObj.text = finnishText;
			} else {
				textObj.text = englishText;
			}
		}
		if (name == "PoliceSubtitles") {
			textObj.text = "";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetLanguage(int langID){
		if (tag != "Credits") {
			if (langID > 0) {
				textObj.text = finnishText;
			} else {
				textObj.text = englishText;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class virtualButton : MonoBehaviour {

	private Button button;
	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		button.onClick.AddListener(onClickEvent);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("asdasd");
			button.onClick.Invoke ();
		}
	}

	public void virtualClick(){
		button.onClick.Invoke ();
	}

	public void onClickEvent(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene (0);
	}

	public void virtualHover(){
		ColorBlock cb = button.colors;
		cb.normalColor = Color.grey;
		button.colors = cb;
	}

	public void virtualHoverEnd(){
		ColorBlock cb = button.colors;
		cb.normalColor = Color.white;
		button.colors = cb;
	}

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {
	private GameController myController;
	// Use this for initialization
	void Start () {
		myController = GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadStreet(){
			SceneManager.LoadScene ("Level_street");
	}
	public void QuitGame(){
		Application.Quit ();
	}

	public bool IsLvlMainMenu(){
		if (SceneManager.GetActiveScene ().name == "MainMenu") {
			return true;
		} else {
			return false;
		}
	}
}

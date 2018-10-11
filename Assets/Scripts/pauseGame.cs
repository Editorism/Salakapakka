using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour {


	public bool isPaused;
	public Transform cameraTrans;
	public Transform lookAtPos;
	private Vector3 myRot;
	private Animator bookAnim;
	public Transform bookTrans;
	public Canvas pauseCanvas;
	private Vector3 vecZero;
	private Vector3 vecId;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectsWithTag ("GameController")[0].GetComponent<GameController>();
		isPaused = false;
		bookAnim = GetComponentInChildren<Animator> ();
		vecZero = new Vector3 (0, 0, 0);
		vecId = Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown (OVRInput.Button.Back) && isPaused == false && !IsLvlMain()) {
			pauseG ();
		}
		else if (OVRInput.GetDown (OVRInput.Button.Back) && isPaused == true) {
			resumeG ();
		}


		if (Input.GetKeyDown (KeyCode.X) && isPaused == false) {
			pauseG ();
		}
		else if (Input.GetKeyDown(KeyCode.X) && isPaused == true) {
			resumeG ();
		}
	}

	public void resumeG(){
		CloseBook ();
		Time.timeScale = 1.0f;
		isPaused = false;
	}

	public void pauseG(){
		OpenBook ();
		myRot = transform.eulerAngles;
		myRot.y =  cameraTrans.eulerAngles.y;
		transform.eulerAngles = myRot;
		isPaused = true;
	}

	public void QuitG(){
		if (!gameController.DemoMode) {
			Application.Quit ();
		} else {
			SceneManager.LoadScene (0);
		}
	}

	public void RestartG(){
		resumeG ();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ReturnToMenu(){
		resumeG ();
		SceneManager.LoadScene("MainMenu");
	}

	public void updateBottles(int bIndex){
		Debug.Log ("collected: " + bIndex);
	}

	private void OpenBook(){
		bookAnim.SetBool ("open", true);
	}
	private void CloseBook(){
		bookAnim.SetBool ("open", false);
	}

	public void DisableBook(){
		bookTrans.localScale = vecZero;
		pauseCanvas.enabled = false;
	}

	public void EnableBook(){
		bookTrans.localScale = vecId;
		pauseCanvas.enabled = true;
	}

	private bool IsLvlMain(){
		if (SceneManager.GetActiveScene ().name == "MainMenu") {
			return true;
		} else {
			return false;
		}
	}
		
}

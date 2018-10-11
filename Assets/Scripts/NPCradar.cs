using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCradar : MonoBehaviour {

	private GameObject character;
	public Image alertExclamation;
	public Image alertImage;
	public Canvas NPCUi;
	public float alertLevel = 0;
	public float alertDampUp = 0.15f;
	public float alertDampDw = 0.15f;
	private LookAt look;
	private bool inFOV = false;
	private NpcDownW downWScript;
	public bool playerIsTrespassing = false;
	public bool isWalking = false;
	public AudioSource alertSound;

	// Use this for initialization
	void Start () {
		look = GetComponent<LookAt> ();
		character = GameObject.FindGameObjectsWithTag ("Player") [0];
		alertImage.rectTransform.anchoredPosition = new Vector2 (0, -1);
		downWScript = gameObject.GetComponent<NpcDownW> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alertLevel > 1) {
			alertLevel = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}
		if (alertLevel < 1 && look.isLooking && inFOV && isWalking) {
			alertLevel += 1 * Time.deltaTime*alertDampUp;
		}
		else if (alertLevel < 1 && inFOV && isWalking) {
			alertLevel += 1 * Time.deltaTime*alertDampUp;
		}
		else if (alertLevel > 0){
			alertLevel -= 1 * Time.deltaTime*alertDampDw;
		}
		CalculateRotation ();
		UpdateAlertLevel ();
	}

	private float CalculateDistance(){
		float distance = Vector3.Distance (character.transform.position, this.transform.position);
		//alertImage.rectTransform.anchoredPosition = new Vector2 (0, -distance/10);
		return distance;
	}

	private void CalculateRotation(){
		Vector3 lookPos = character.transform.position - transform.position;
		lookPos.y = 0;
		NPCUi.gameObject.transform.rotation = Quaternion.LookRotation (lookPos);
	}

	private void UpdateAlertLevel(){
		alertImage.rectTransform.anchoredPosition = new Vector2 (0, alertLevel);
		if (alertLevel <= 0) {
			alertExclamation.gameObject.SetActive(false);
		} else if(alertExclamation.gameObject.activeInHierarchy == false){
			if (alertSound != null) {
				alertSound.Play ();
			}
			alertExclamation.gameObject.SetActive (true);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Grabbable") {
			alertLevel += col.relativeVelocity.magnitude/10;
		}
	}

	public void FieldOfViewEnter(){
			inFOV = true;
	}

	public void FieldOfViewExit(){
		inFOV = false;
	}

	public void PlayerTrespassing(){
		if (gameObject.tag == "NPCDownWaiter") {
				playerIsTrespassing = true;
			}
		else {
			return;
		}
	}

	public void PlayerNotTrespassing(){
		if (gameObject.tag == "NPCDownWaiter") {
			playerIsTrespassing = false;
		}
		else {
			return;
		}
	}

	public bool isInFOV(){
		return inFOV;
	}
}

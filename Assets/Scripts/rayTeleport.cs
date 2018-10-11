using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rayTeleport : MonoBehaviour {

	public GameObject objectToTeleport;
	public GameObject aimer;
	public GameObject start;
	public GameObject end;
	public GameObject target;
	public Texture UITex;
	public Texture MoveTex;
	public Texture SpeakTex;
	public float rayMax = 1.0f;
	public float charHeight = 1.6f;

	private LineRenderer lineRen;
	private bool heldDown;
	private bool holdingObj;
	private Renderer targetRen;
	public GameObject grabbedObj;
	private Vector3 pos1;
	private Vector3 pos2;
	private Vector3 throwVelocity;
	public pauseGame pauseScript;
	private virtualButton btn;
	private collisionCheck targetCollision;
	public float zoomSpeed = 0.1f;
	private Vector3 distance;
	private GameController gameController;
	public bool isMenuScene;
	public float releaseTimer = 0.0f;
	private float releaseThreshold = 1.0f;

	// Use this for initialization
	void Start () {
		pauseScript = GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<pauseGame> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		lineRen = GetComponent<LineRenderer>();
		targetRen = target.GetComponent<Renderer> ();
		targetCollision = target.GetComponent<collisionCheck> ();
		lineRen.startWidth = 0.002f;
		lineRen.endWidth = 0.002f;
		heldDown = false;
		lineRen.enabled = true;
		//targetRen.enabled = false;

		RaycastHit hit;
		Ray ray = new Ray (aimer.transform.position, aimer.transform.forward);

		if (Physics.Raycast (ray, out hit)) {
			end.transform.position = hit.point;
		}
		lineRen.SetPosition (0, start.transform.position);
		lineRen.SetPosition (1, end.transform.position);
	}

	// Update is called once per frame
	void Update () {
		lineRen.SetPosition (0, start.transform.position);
		lineRen.SetPosition (1, end.transform.position);
		if (holdingObj) {
			distance = grabbedObj.transform.position - this.transform.position;
			if ((0.2f) <= Mathf.Abs (distance.magnitude) && Mathf.Abs (distance.magnitude) <= (rayMax)) {
				if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).y < -0.5 && OVRInput.Get (OVRInput.Button.PrimaryTouchpad)) {
					if (0.2f + zoomSpeed <= Mathf.Abs (distance.magnitude)) {
						grabbedObj.transform.position -= (grabbedObj.transform.position - this.transform.position).normalized * zoomSpeed * 0.5f;
					}
				}
				if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).y > 0.5 && OVRInput.Get (OVRInput.Button.PrimaryTouchpad)) {
					if (Mathf.Abs (distance.magnitude) <= rayMax - zoomSpeed) {
						grabbedObj.transform.position += (grabbedObj.transform.position - this.transform.position).normalized * zoomSpeed * 0.5f;
					}
				}
				if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).x > 0.5f && OVRInput.Get (OVRInput.Button.PrimaryTouchpad)) {

					Vector3 newRot = grabbedObj.transform.eulerAngles;
					newRot.y += 15f % 360;
					grabbedObj.transform.eulerAngles = newRot;
				}
				if (OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad).x < -0.5f && OVRInput.Get (OVRInput.Button.PrimaryTouchpad)) {

					Vector3 newRot = grabbedObj.transform.eulerAngles;
					newRot.y -= 15f % 360;
					grabbedObj.transform.eulerAngles = newRot;
				}
			}
		}

		MarkerGrabberUpdate ();
		releaseTimer += Time.deltaTime;

		if (OVRInput.GetDown (OVRInput.Button.PrimaryTouchpad)) {

		}


		if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger)) {
			if (holdingObj) {
				releaseObject ();
			} else {
				teleport ();
			}
		}

		if (OVRInput.GetUp (OVRInput.Button.PrimaryIndexTrigger)) {


		}

	}



	private Vector3 calculateVelocity(Vector3 lastPos, Vector3 currentPos) {
		Vector3 frameVelocity = (currentPos - lastPos) / Time.deltaTime;
		const int samples = 3;
		throwVelocity = throwVelocity * (samples - 1) / samples + frameVelocity / samples;
		return throwVelocity;
	}


	private void releaseObject(){
		if (holdingObj && Time.timeScale == 1) {

			releaseTimer = 0.0f;
			GameObject grabbedImportant = grabbedObj.gameObject;
			grabbedObj.transform.parent = null;
			grabbedObj.GetComponent<Rigidbody> ().isKinematic = false;
			objectToTeleport.GetComponent<Rigidbody> ().isKinematic = false;
			grabbedObj.GetComponent<Rigidbody> ().AddForce (throwVelocity, ForceMode.VelocityChange);

			if (grabbedObj.tag == "Bottle") {
				gameController.UpdateBottles (grabbedObj.GetComponent<bottleIndex>().bIndex);
				grabbedObj.GetComponent<PickupUi> ().RemoveParent ();
				//hit.transform.GetComponent<PickupUi> ().RemoveParent();
				Destroy (grabbedImportant);
			}
			holdingObj = false;
			releaseTimer = 0.0f;
		}
	}

	private void teleport(){
		//targetRen.enabled = false;
		targetRen.material.mainTexture = MoveTex;
		heldDown = false;

		RaycastHit hit;
		Ray ray = new Ray (aimer.transform.position, aimer.transform.forward);

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.tag == ("Floor") && Time.timeScale == 1 && !targetCollision.isColliding) {
				objectToTeleport.transform.position = hit.point;
				objectToTeleport.transform.position += Vector3.up * charHeight;
			} else if (hit.transform.tag == "OutsideDoor") {

				if (SceneManager.GetActiveScene ().name == "Level4" && gameController.bIndexList [0] == true) {
					SceneManager.LoadScene ("MainMenu");

				} else if (SceneManager.GetActiveScene ().name == "Level_street") {
					SceneManager.LoadScene ("Level4");
				}
			} else if (hit.transform.tag == "NPC" && hit.transform.GetComponent<playHints> () != null) {
				hit.transform.GetComponent<playHints> ().playHintSound();
				Debug.Log ("playhint");

			}
		}
	}

	private void MarkerGrabberUpdate(){
		RaycastHit hit;
		Ray ray = new Ray (aimer.transform.position, aimer.transform.forward);

		if (Physics.Raycast (ray, out hit)) {
			end.transform.position = hit.point;

			if (!holdingObj) {
				//Debug.Log (hit.transform.tag);
				if (hit.transform.tag == "Floor" && !targetCollision.isColliding) {
					targetRen.enabled = true;
					targetRen.material.color = Color.green;
					target.transform.position = hit.point + Vector3.up * 0.01f;
					target.transform.rotation = Quaternion.identity;
				} else if ((hit.transform.tag == "Grabbable" || hit.transform.tag == "Important" || hit.transform.tag == "Bottle") && releaseTimer >= releaseThreshold) {



					if (hit.transform.tag == "Bottle") {

					}

					if (hit.distance <= rayMax) {

						targetRen.enabled = false;
						hit.transform.parent = this.gameObject.transform;
						hit.transform.GetComponent<Rigidbody> ().isKinematic = true;
						objectToTeleport.GetComponent<Rigidbody> ().isKinematic = true;
						grabbedObj = hit.transform.gameObject;
						holdingObj = true;
						Physics.IgnoreCollision (objectToTeleport.GetComponent<CapsuleCollider> (), grabbedObj.GetComponent<Collider> ());

						pos1 = Vector3.zero;
						pos2 = Vector3.zero;

					} else {
						//Debug.Log ("Too far away to pick up!");
					}
				} else if (hit.transform.tag == "OutsideDoor") {
					targetRen.material.color = Color.green;
				} else if (hit.transform.tag == "NPC") {
					targetRen.material.mainTexture = SpeakTex;
					targetRen.material.color = Color.white;
					target.transform.position = hit.point + hit.normal * 0.01f;
					target.transform.rotation = Quaternion.FromToRotation (transform.up, hit.normal) * transform.rotation;
				}

				else {
					if (isMenuScene || pauseScript.isPaused == true) {
						//targetRen.enabled = false;
					}
					else if (hit.transform.tag == "UI") {
						//targetRen.enabled = false;
						targetRen.material.mainTexture = UITex;
						targetRen.material.color = Color.grey;
					}
					else {
						//targetRen.enabled = true;
						targetRen.material.mainTexture = MoveTex;

					}
					targetRen.enabled = true;
					if (targetRen.material.mainTexture == MoveTex)
					{
						targetRen.material.color = Color.red;
					}
					target.transform.position = hit.point + hit.normal * 0.01f;
					target.transform.rotation = Quaternion.FromToRotation (transform.up, hit.normal) * transform.rotation;

				}
			}

			else {
				pos1 = grabbedObj.transform.position;

				if (pos2 == Vector3.zero) {
					pos2 = pos1;
				}

				throwVelocity = calculateVelocity (pos2, pos1);
				pos2 = pos1;
			}
		}



	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickThrow : MonoBehaviour {


	public GameObject start;
	public GameObject end;
	public GameObject objectToTeleport;
	public GameObject aimer;
	private LineRenderer lineRen;
	private bool holdingObj;
	private GameObject grabbedObj;
	private Vector3 pos1;
	private Vector3 pos2;
	private Vector3 throwVelocity;
	public float rayMax = 2.5f;

	// Use this for initialization
	void Start () {
		lineRen = GetComponent<LineRenderer>();
		lineRen.startWidth = 0.1f;
		lineRen.endWidth = 0.1f;
		lineRen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
			lineRen.enabled = true;
			RaycastHit hit;
			Ray ray = new Ray (aimer.transform.position, aimer.transform.forward);

			if (Physics.Raycast (ray, out hit)) {
				end.transform.position = hit.point;
				if (!holdingObj) {
					if (hit.transform.tag == "Grabbable" || hit.transform.tag == "Important") {
						if (hit.distance <= rayMax) {
							hit.transform.parent = this.gameObject.transform;
							hit.transform.GetComponent<Rigidbody> ().isKinematic = true;
							grabbedObj = hit.transform.gameObject;
							holdingObj = true;
							Physics.IgnoreCollision (grabbedObj.GetComponent<Collider> (), objectToTeleport.GetComponent<CapsuleCollider> ());
							pos1 = end.transform.position;
						}
					}
				}
				else if (holdingObj){
					GameObject grabbedImportant = grabbedObj.gameObject;
					grabbedObj.transform.parent = null;
					grabbedObj.GetComponent<Rigidbody> ().isKinematic = false;
					grabbedObj.GetComponent<Rigidbody> ().AddForce (throwVelocity, ForceMode.VelocityChange);
					//Physics.IgnoreCollision (grabbedObj.GetComponent<Collider> (), objectToTeleport.GetComponent<CapsuleCollider> (), false);
					if (grabbedObj.tag == "Important") {
						Destroy (grabbedImportant);
					}
					holdingObj = false;
				}

			}


		}
		if (OVRInput.GetUp (OVRInput.Button.PrimaryIndexTrigger)) {
			lineRen.enabled = false;
		}

		if (holdingObj) {
			pos2 = end.transform.position;
			Vector3 frameVelocity = (pos2 - pos1) / Time.deltaTime;
			pos1 = end.transform.position;
			const int samples = 3;
			throwVelocity = throwVelocity * (samples - 1) / samples + frameVelocity / samples;
			Debug.Log (throwVelocity);
		}

		lineRen.SetPosition (0, start.transform.position);
		lineRen.SetPosition (1, end.transform.position);
	}


}

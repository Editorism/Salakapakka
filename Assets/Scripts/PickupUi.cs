using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUi : MonoBehaviour {

	private GameObject character;
	public Text pickupMessage;
	public Image alertImage;
	public Canvas pickupCanvas;

	// Use this for initialization
	void Start () {
		pickupCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void enableCanvas(){
		pickupCanvas.enabled = true;
	}

	public void RemoveParent(){
		pickupCanvas.GetComponent<itemUi> ().CalculateRotation ();
		pickupCanvas.enabled = true;
		pickupCanvas.transform.parent = null;
		pickupCanvas.transform.position = gameObject.transform.position;
		Debug.Log ("Call for the function to destroy UI in 5secs");
		Destroy (gameObject);
	}
}

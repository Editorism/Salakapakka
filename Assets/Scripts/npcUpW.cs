using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcUpW : MonoBehaviour {


	private Animator anim;
	private bool isAlerted = false;
	private bool isStaggered = false;
	private bool menuServe = false;
	private bool menuShow = false;
	private LookAt look;
	private NPCradar alertLvl;
	public List<GameObject> foodList = new List<GameObject> ();
	public List<GameObject> drinkList = new List<GameObject> ();
	private List<GameObject> orderList = new List<GameObject> ();
	private bool firstOrderDrink;
	public GameObject orderSpot01;
	public GameObject orderSpot02;
	private int firstOrderIndex = 99;
	private int secondOrderIndex = 99;
	private GameController controller;
	public int clickCount = 0;
	private bool firstOrderMade = false;
	private bool secondOrderMade = false;
	private bool isOrderTime = false;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		anim = GetComponent<Animator> ();
		look = GetComponent<LookAt> ();
		alertLvl = GetComponent<NPCradar> ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (isAlerted);
		firstOrderDrink = false;
		if (alertLvl.alertLevel <= 0) {
			isAlerted = false;
			anim.SetBool ("isAlerted", isAlerted);
		}
		else {
			isAlerted = true;
			anim.SetBool ("isAlerted", isAlerted);
		}
		if (isOrderTime) {
			timer += Time.deltaTime;
			if (timer > 4.0f) {
				IntantiateOrderDelay ();
				isOrderTime = false;
				timer = 0;
			}
		}


	}

	private void IntantiateOrderDelay(){
		Instantiate (orderList [0], orderSpot01.transform.position, orderSpot01.transform.rotation);
		Instantiate (orderList [1], orderSpot02.transform.position, orderSpot02.transform.rotation);
		orderList.Clear ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.tag == "Player") {
			look.isLooking = true;
			menuShow = true;
			anim.SetBool ("menuShow", menuShow);
			look.t = 0;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.transform.tag == "Player") {
			look.isLooking = false;
			menuShow = false;
			anim.SetBool ("menuShow", menuShow);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.transform.tag == "Grabbable") {
			isStaggered = true;
			isAlerted = true;
			anim.SetTrigger ("isStaggered");
			anim.SetBool ("isAlerted", isAlerted);
		}
	}

	public void InstantiateOrder(int orderIndex){

		Debug.Log (orderIndex);


		if (orderIndex >= 4) {
			orderList.Add (drinkList [orderIndex-4]);
		} else {
			orderList.Add (foodList[orderIndex]);
		}

		if (orderList.Count > 1) {
			isOrderTime = true;
			anim.SetTrigger ("menuServe");
		}



		if (firstOrderMade == true) {
			secondOrderIndex = orderIndex;
			secondOrderMade = true;
			Debug.Log ("second order index: " + secondOrderIndex);
		}

		if (firstOrderMade == false) {
			firstOrderIndex = orderIndex;
			firstOrderMade = true;
			Debug.Log ("first order index: " + firstOrderIndex);
		}

		if ((firstOrderIndex == 3 && secondOrderIndex == 4) || (firstOrderIndex == 4 && secondOrderIndex == 3)) {
			controller.orderMenu = true;
		}

		if (secondOrderMade == true) {
			firstOrderIndex = 99;
			secondOrderIndex = 99;
			secondOrderMade = false;
			firstOrderMade = false;
		}


	}

	public int OrderListCount(){

		return orderList.Count;
	}

	public int clickCounter(){
		clickCount++;
		return clickCount;

	}
	

		
}

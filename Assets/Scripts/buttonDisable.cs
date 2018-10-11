using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonDisable : MonoBehaviour {

	private Button but;
	private GameController controller;
	private npcUpW waiter;
	private GameObject foodMenu;
	private GameObject drinkMenu;
	// Use this for initialization
	void Start () {
		foodMenu = GameObject.FindGameObjectWithTag ("FoodMenu");
		drinkMenu = GameObject.FindGameObjectWithTag ("DrinkMenu");
		waiter = GameObject.FindGameObjectsWithTag ("NPCwaiter") [0].GetComponent<npcUpW>();
		but = GetComponent<Button> ();
		controller = GameObject.FindGameObjectsWithTag ("GameController") [0].GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.X)) {
			buttonClick ();
		}
	}

	public void buttonClick() {
		if (controller.but != null) {
			controller.but.interactable = true;
		}
		controller.but = but;
		if (waiter.OrderListCount () <= 1) {
			but.interactable = false;
		}
			
		if (waiter.clickCounter() >= 2) {
			resetMenuButtons ();
		}
	}

	public void resetMenuButtons(){
		buttonDisable[]foodButtonList = foodMenu.GetComponentsInChildren<buttonDisable>();
			for (int i = 0; i < foodButtonList.Length; i++) {
				foodButtonList [i].but.interactable = true;
		}
		buttonDisable[]drinkButtonList = drinkMenu.GetComponentsInChildren<buttonDisable>();
			for (int i = 0; i < drinkButtonList.Length; i++) {
				drinkButtonList [i].but.interactable = true;
		}
		waiter.clickCount = 0;
	}
}

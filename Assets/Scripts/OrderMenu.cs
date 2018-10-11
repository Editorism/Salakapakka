using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMenu : MonoBehaviour {

	private npcUpW waiter;
	public bool spawnCake;
	// Use this for initialization
	void Start () {
		waiter = GameObject.FindGameObjectsWithTag ("NPCwaiter") [0].GetComponent<npcUpW>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void menuClick(int orderIndex) {
		waiter.InstantiateOrder (orderIndex);
	}
		
}

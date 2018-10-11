using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{

	public bool isLooking;
	private Transform viewTarget;  //tähän hahmo tuijottaa
	protected Animator anim;  //referenssi hahmon Animator-komponenttiin
	private NPCradar myRadar;
	public float speed = 1;
	public float t;
	private float lookWeight = 0.5f;


	void Start()
	{
		myRadar = GetComponent<NPCradar> ();
		isLooking = false;
		t = 0;
		viewTarget = GameObject.FindGameObjectsWithTag ("Player")[0].transform;
		anim = GetComponent<Animator>();  //liitetään parametri hahmon Animator-komponenttiin

	}

	void  OnAnimatorIK()//LateUpdate()
	{
//		Debug.Log ("asd");
		if (viewTarget != null)  //eli jos kohdeobjekti on määritelty
		{
//			Debug.Log ("should look");
			anim.SetLookAtPosition(viewTarget.position);  //tässä tehdään varsinainen pään kääntyminen
			anim.SetLookAtWeight(Mathf.Lerp(0.0f, lookWeight, t));  //onko lookAt päällä ja miten paljon (0.0-1.0f)
		}
	}

	void Update() {
		if (t < 1 && isLooking) {
			t += speed * Time.deltaTime;
		} else if (t > 1) {
			t = 1;
		} else if (t > 0 && !isLooking) {
			t -= speed * Time.deltaTime*2;
		}
		

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && myRadar.isInFOV()) {
			isLooking = true;
			Debug.Log ("islooking");
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			isLooking = false;
//			Debug.Log ("is not looking");
		}
	}

}
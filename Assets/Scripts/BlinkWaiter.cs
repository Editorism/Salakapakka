using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkWaiter : MonoBehaviour {


	public Transform L_eye, R_eye;
	public float timerBlink, openBlink = 0.1f;
	public float blinkThreshold = 9.0f;
	bool closeParam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	
		timerBlink += Time.deltaTime;

		blinkThreshold = Random.Range (7f, 10f);

		if (timerBlink > blinkThreshold)
			BlinkWaiterEyes (true);
		
		if(timerBlink > (blinkThreshold + openBlink))
		
		{
			BlinkWaiterEyes (false);
			timerBlink = 0;

		}


//		if(timerBlink > blinkThreshold)
//		{
//			closeParam = true;
//			openBlink = 0;
//		}
//
//		if(openBlink > 0.5f)
//		{
//			closeParam = false;
//				timerBlink = 0;
//
//		}
//
//
//		if (closeParam == false) {
//			BlinkWaiterEyes (false);
//		}
//		else
//			BlinkWaiterEyes (true);
//


	}


	void BlinkWaiterEyes(bool close)
	{
		if (close == true) {
			L_eye.localScale = new Vector3 (1, 0.1f, 1);
			R_eye.localScale = new Vector3 (1, 0.1f, 1);
		} else {
			L_eye.localScale = Vector3.one;
			R_eye.localScale = Vector3.one;
		}
	}




}





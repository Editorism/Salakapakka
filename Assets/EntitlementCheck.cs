using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;

//note: Must have Oculus Platform SDK for Unity installed!

public class EntitlementCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Core.Initialize("1556971604391491");
		Entitlements.IsUserEntitledToApplication().OnComplete(
			(Message msg) =>
			{
				if (msg.IsError)
				{
					print("fired oculus platform, is not entitled");
					// User is NOT entitled.
					UnityEngine.Application.Quit();
					//showMessageThatTheUserDoesntOwnThis();
				} else 
				{

					print("Oculus platform enetitlement check passed");
					// User IS entitled
					//proceedAsNormal();
				}
			}
		);
	}
}
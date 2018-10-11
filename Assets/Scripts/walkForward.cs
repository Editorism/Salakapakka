using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkForward : StateMachineBehaviour {


	public float speed;
	private Transform characterTrans;
	private Vector3 newpos;
	private NPCradar alertLevel;
	private bool wDirection;
	private NpcDownW npcControl;
	private Vector3 roundRotation;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {


		roundRotation = animator.gameObject.transform.eulerAngles;
		roundRotation.x = Mathf.Round(roundRotation.x / 90) * 90;
		roundRotation.y = Mathf.Round(roundRotation.y / 90) * 90;
		roundRotation.z = Mathf.Round(roundRotation.z / 90) * 90;
		animator.gameObject.transform.eulerAngles = roundRotation;

		npcControl = animator.gameObject.GetComponent<NpcDownW> ();
		characterTrans = animator.gameObject.GetComponent<Transform> ();
		alertLevel = animator.gameObject.GetComponent<NPCradar> ();
		animator.applyRootMotion = false;
		wDirection = false;
		if (animator.gameObject.transform.position.x > 3.0f) {
			wDirection = true;
		}
		npcControl.isWalking = true;

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (alertLevel.alertLevel <= 0) {
			if (wDirection) {
				newpos = characterTrans.position + Vector3.left * speed * Time.deltaTime;
				characterTrans.position = newpos;
			} else {
				newpos = characterTrans.position + Vector3.right * speed * Time.deltaTime;
				characterTrans.position = newpos;
			}

		} else {

		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//animator.gameObject.GetComponent<NPCradar> ().isWalking = true;
		animator.applyRootMotion = true;
		npcControl.isWalking = false;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

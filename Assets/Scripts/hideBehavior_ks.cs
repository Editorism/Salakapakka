using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Kristian Simolin

objektin piilottaminen (meshRenderer) ja näkyväksi tekeminen


*/




public class hideBehavior_ks : StateMachineBehaviour {

	public bool hide=false;
	public bool HiddenAfterExit=false; 
	public string tag_hideable;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){


		MeshRenderer[] MR = animator.gameObject.GetComponentsInChildren<MeshRenderer> ();  //skinned KORJAA


		foreach (MeshRenderer mr in MR) {

			if (mr.gameObject.tag == tag_hideable && hide == true)
				mr.gameObject.GetComponent<MeshRenderer> ().enabled = false;

		}





	}




	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		MeshRenderer[] MR = animator.gameObject.GetComponentsInChildren<MeshRenderer> ();  //skinned KORJAA


		foreach (MeshRenderer mr in MR) {

			if (mr.gameObject.tag == tag_hideable && HiddenAfterExit == true)
				mr.gameObject.GetComponent<MeshRenderer> ().enabled = false;

			else if (mr.gameObject.tag == tag_hideable && HiddenAfterExit == false)
				mr.gameObject.GetComponent<MeshRenderer> ().enabled = true;








		}




		//        if (animator.gameObject.gameObject.activeSelf == true)
		//            animator.gameObject.gameObject.SetActive (false);
		//        else if ((animator.gameObject.gameObject.activeSelf == false))
		//            animator.gameObject.gameObject.SetActive (true);



	}




	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
	using UnityEditor;
#endif
/*
Kehitysehdotuksia: offset, eli ääni ei ala heti

Kristian Simolin, 2017

V.001

*/




public class playAudioBlendtree_ks : StateMachineBehaviour {



	//public string nameOfTheClip;

	public bool play0 = false;
	public float delay_in_s0;
	public bool loop0;
	public bool stop_on_exit0;

	public bool play1=false;
	public float delay_in_s1;
	public bool loop1;
	public bool stop_on_exit1;


	public bool play2=false;
	public float delay_in_s2;
	public bool loop2;
	public bool stop_on_exit2;



	//	public bool loop0=false, loop1=false, loop2=false;
	//
	//	public bool stop_onExit_0 =false, stop_onExit_1= false, stop_onExit_2=false;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {



		AudioSource[] audioSources = animator.gameObject.gameObject.GetComponents<AudioSource>();

		try
		{

		AudioSource audioSource0 = audioSources [0];
		AudioSource audioSource1 = audioSources [1];
		AudioSource audioSource2 = audioSources [2];

		//AudioSource audioSource3 = audioSources [3];




		audioSource0.mute = true;
		audioSource1.mute = true;
		audioSource2.mute = true;




		if (play0 == true) {
			audioSource0.mute = false;
			audioSource0.PlayDelayed (delay_in_s0);
				if(loop0 == true){
					audioSource0.loop = true;
				}
		}

		if (play1 == true)
		{
			audioSource1.mute = false;
			audioSource1.PlayDelayed(delay_in_s1);
				if(loop1 == true){
					audioSource1.loop = true;
				}
			}
		

		if (play2 == true)
		{
			audioSource2.mute = false;
			audioSource2.PlayDelayed (delay_in_s2);
			if(loop1 == true){
				audioSource2.loop = true;
			}
		}


		}

		catch(System.IndexOutOfRangeException e) {
		
			Debug.Log ("exception happened");
		}
			

		//		AudioSource audioSource = animator.gameObject.GetComponent<AudioSource>();
		//		//		AudioSource audioSource = animator.GetComponent<AudioSource>();
		//
		//		//audioSource.clip =  (AudioClip)Resources.Load(nameOfTheClip, typeof(AudioClip)); //Mainmenu_exit ;
		//
		//	
		//		audioSource.enabled = true;
		//		nameOfTheClip = "Audio/" + nameOfTheClip; //"Audio/Mainmenu_exit";
		//
		//		//if(audioSource.clip == null)
		//		audioSource.clip = (AudioClip)Resources.Load (nameOfTheClip, typeof(AudioClip));
		//
		//
		//		if (audioSource.isPlaying == false) {
		//			
		//			audioSource.Play ();
		//				
		//
		//		}
		//
		//		Debug.Log ("CLIPNAME: " + audioSource.clip.ToString());
	}


	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		AudioSource[] audioSources = animator.gameObject.gameObject.GetComponents<AudioSource>();

		if (stop_on_exit0 == true)
			audioSources [0].Stop();

		if (stop_on_exit1 == true)
			audioSources [1].Stop();

		if (stop_on_exit2 == true)
			audioSources [2].Stop();


		//		AudioSource audioSource = animator.GetComponent<AudioSource>();
		//		audioSource.enabled = true;
		//
		//		if(audioSource.isPlaying == true)
		//			audioSource.Stop();

	}





	// OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
	//
	//}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
	//
	//}
}

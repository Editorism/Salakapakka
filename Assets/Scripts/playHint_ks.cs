using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playHint_ks : MonoBehaviour {

	//kristian simolin

	//Sami: vihje (hint) tulee kun 1) pelaaja on hahmon edessä 2) hahmoa klikataan
	//


	[Header("Skriptillä tarkistetaan katsooko hahmo pelaajaa ja aktivoidaan vihjeitä")]
	[Header("isLooking arvo saadaan LookA -skriptistä")]
	[Space(10)]
	bool checkIsLooking;  //katsotaan katsooko hahmo pelaajaa
	AudioSource[] commments; 
	public int hintNumber=0;  //pidetään kirjaa montako vihjettä on annettu
	bool hintPlayingAlready;
	//public string hint_1, hint_2;  //tähän kirjoitetaan vihjeiden äänitiedostojen nimet
	AudioSource lastAudioSource;   //hahmon viimeistä audiosource käytetään vihjeisiin
	public AudioClip firstHintClip, secondHintClip;

	[Space(10)]
	[Header("tämä parametri on vain debuggausta varten")]

	public AudioClip lastAudioSource_clip; 

	// Use this for initialization
	void Start () {


		commments = this.gameObject.GetComponents<AudioSource>();
		lastAudioSource =commments[commments.Length-1];

		hintPlayingAlready = false;

	}
	
	// Update is called once per frame
	void Update () {



		lastAudioSource_clip = lastAudioSource.clip;  //tämä on vain debuggausta varten

		checkIsLooking = gameObject.GetComponent<LookAt> ().isLooking;

		print ("checkIsLooking " + checkIsLooking.ToString ());



		if(Input.GetMouseButtonUp(0) == true)  //VAIHDA TÄHÄN OIKEA SYY, NYT KÄYTTÄÄ VAIN MOUSEUPPIA!!!!! Sami: vihje (hint) tulee kun 1) pelaaja on hahmon edessä 2) hahmoa klikataan

		//if(checkIsLooking == true)
		{  //checkIsLooking == true
			

			print ("this.gameObject.name "+this.gameObject.name);

			if (lastAudioSource.isPlaying == false) {
				hintNumber++;

				if (hintNumber == 1) {
					lastAudioSource.clip = firstHintClip;
					this.lastAudioSource.Play ();
				} 
				else if (hintNumber == 2) {
					lastAudioSource.clip = secondHintClip;
					this.lastAudioSource.Play ();
					hintNumber = 0;
				}	
			
			
			}



	}
}


}

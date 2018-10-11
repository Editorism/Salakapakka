using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {




	public List<bool> bIndexList;
	public bool notebook; ////bindex 0
	public bool bottle_1; //bindex 1
	public bool bottle_2; //bindex 2
	public bool bottle_3; //bindex 3
	public bool bottle_4; //bindex 4
	public bool key; //bindex 5
	public bool flask; //bindex 6
	public bool orderMenu;
	public Button but;
	public Image menuCover;
	public CanvasGroup menuCoverText;
	public bool useTimescale = false;
	public int timescale;
	public float timeToSkip;
	private float skipTimer;

	public GameObject trackerAnchor;
	public AudioSource policeMonoAudio;
	public Camera mainCam;
	public pauseGame pauseMenu;
	public SelfWritingText policeSubs;
	private Text policeText;
	private setLanguage policeLang;
	private string policeStr;
	private float policeLtrPause;
	private levelManager myLvlManager;
	public bool DemoMode;
	private int i;
	private List<Text> textList;
	// Use this for initialization
	void Start () {
		myLvlManager = GetComponent<levelManager> ();
		if (myLvlManager.IsLvlMainMenu ()) {
			policeLang = policeSubs.GetComponent<setLanguage> ();
			policeText = policeSubs.GetComponent<Text> ();
		}
		timeToSkip = 3.0f;
		skipTimer = 0.0f;
		SetCanvases ();
		GetPauseMenu ();
		textList = new List<Text> (FindObjectsOfType<Text>());
	}
	
	// Update is called once per frame
	void Update (){
		if (OVRInput.GetDown (OVRInput.Button.Back)) {
			StopPoliceMonologue ();
		}
		if (myLvlManager.IsLvlMainMenu ()) {
			if (policeMonoAudio.isPlaying) {
				SkipMonologueChecker ();
			}
		}
		if (useTimescale) {
			Time.timeScale = timescale;
		}
	}

	void SetCanvases() {
		OVRRaycaster[] canvasItems = FindObjectsOfType (typeof(OVRRaycaster)) as OVRRaycaster[];
		foreach(OVRRaycaster item in canvasItems){
			item.pointer = trackerAnchor;
			item.GetComponent<Canvas> ().worldCamera = mainCam;

		}
	}

	void GetPauseMenu() {
		bIndexList = new List<bool> ();
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu").transform.GetComponent<pauseGame>();

		bIndexList.Add (notebook);
		bIndexList.Add (bottle_1);
		bIndexList.Add (bottle_2);
		bIndexList.Add (bottle_3);
		bIndexList.Add (bottle_4);
		bIndexList.Add (key);
		bIndexList.Add (flask);

	}

	public void UpdateBottles(int bIndex){
		pauseMenu.updateBottles (bIndex);
		bIndexList [bIndex] = true;

	}

	public void PlayPoliceMonologue(){
		if (!policeMonoAudio.isPlaying) {
			menuCoverText.alpha = 1;
			policeMonoAudio.Play ();
			if (PlayerPrefs.GetInt ("Language") == 0) {
				policeStr = policeLang.englishText;
				policeLtrPause = 0.09f;
			}
			else {
				policeStr = policeLang.finnishText;
				policeLtrPause = 0.058f;
			}
			policeSubs.WriteText(policeText, policeStr, policeLtrPause);
			StartCoroutine (WaitForMonologue ());
		}
	}

	public void StopPoliceMonologue(){
		if (policeMonoAudio.isPlaying) {
			policeSubs.StopText (policeText, policeStr, policeLtrPause);
			menuCoverText.alpha = 0;
			StopCoroutine (WaitForMonologue ());
			policeMonoAudio.Stop ();
		}
	}

	IEnumerator WaitForMonologue(){
		yield return new WaitForSeconds(policeMonoAudio.clip.length + 1.0f);
		menuCoverText.alpha = 0;
		myLvlManager.LoadStreet ();
	}

	public void SkipMonologueChecker(){
		if (Input.GetKeyUp (KeyCode.Space) || OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad)){
			skipTimer = 0;
			return;
		}
		else if(Input.GetKey (KeyCode.Space) || OVRInput.Get(OVRInput.Button.PrimaryTouchpad)) {
				skipTimer += Time.deltaTime;
				Debug.Log ("Time held down: " + skipTimer);
				if (skipTimer > timeToSkip) {
					menuCoverText.alpha = 0;
					myLvlManager.LoadStreet ();
				}
			}		
		}


	//0 = English, 1 = Finnish
	public void SetLanguage(int lanIndex){
		PlayerPrefs.SetInt ("Language", lanIndex);
		foreach(Text item in textList){
			item.transform.GetComponent<setLanguage> ().SetLanguage(lanIndex);
		}
	}
}

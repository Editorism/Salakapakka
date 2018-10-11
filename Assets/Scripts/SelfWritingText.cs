using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// © 2017 TheFlyingKeyboard
// theflyingkeyboard.net
//Writes text letter by letter with time step
public class SelfWritingText : MonoBehaviour {
	[SerializeField] private Text textToUse;
	[SerializeField] private bool useThisText = false;
	[SerializeField] private bool useThisTextText = false;
	[SerializeField] private float letterPause = 0.1f;
	[TextAreaAttribute(4, 15)]
	[SerializeField] private string textToShow;
	private string message;
	private void Start()
	{
	}
	private IEnumerator TypeText(Text text, string textText, float timePause)
	{
		for(int i = 0; i < textText.Length; i++)
		{
			text.text += textText[i];
			yield return 0;
			yield return new WaitForSeconds(timePause);
		}
	}
	public void WriteText(Text newText, string newTextToShow, float newLetterPause)
	{
		if(newText != null && newTextToShow != null && newLetterPause > 0.0f)
		{
			newText.text = "";
			StartCoroutine(TypeText(newText, newTextToShow, newLetterPause));
			return;
		}
		if(newText!= null && newTextToShow != null)
		{
			StartCoroutine(TypeText(newText, newTextToShow, letterPause));
			return;
		}
		if (newText != null && newLetterPause > 0.0f)
		{
			StartCoroutine(TypeText(newText, message, newLetterPause));
			return;
		}
		if (newTextToShow != null && newLetterPause > 0.0f)
		{
			StartCoroutine(TypeText(textToUse, newTextToShow, newLetterPause));
			return;
		}
		if (newTextToShow != null)
		{
			StartCoroutine(TypeText(textToUse, newTextToShow, letterPause));
			return;
		}
		if (newLetterPause > 0.0f)
		{
			StartCoroutine(TypeText(textToUse, message, letterPause));
			return;
		}
	}

	public void StopText(Text newText, string newTextToShow, float newLetterPause)
	{
		textToShow = "";
		StopAllCoroutines();
	}
}
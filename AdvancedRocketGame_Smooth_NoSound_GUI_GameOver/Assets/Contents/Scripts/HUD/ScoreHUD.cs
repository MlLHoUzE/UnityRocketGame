using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class ScoreHUD : MonoBehaviour
{
	[HideInInspector] public int Score = 0;

	void Update ()
	{
		// Set the score text.
		this.guiText.text = "Score: " + this.Score.ToString();
	}
}

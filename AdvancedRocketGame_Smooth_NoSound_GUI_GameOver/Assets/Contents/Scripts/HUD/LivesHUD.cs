using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class LivesHUD : MonoBehaviour 
{
	[HideInInspector] public int Lives;

	void OnGUI ()
	{
		// Set player lives text.
		if (this.Lives == 0)
		{
			this.guiText.text = "Game Over!";
		}
		else
		{
			this.guiText.text = "Health: " + this.Lives.ToString();
		}
	}
}

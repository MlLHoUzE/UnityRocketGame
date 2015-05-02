using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[SerializeField] private string levelToLoad;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Application.LoadLevel(this.levelToLoad);
		}
	}
}

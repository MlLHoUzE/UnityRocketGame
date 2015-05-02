using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	[SerializeField] private GameObject barrier;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			GameObject.Destroy(barrier);
		}
	}

}

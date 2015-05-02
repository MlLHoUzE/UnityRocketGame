using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
	[SerializeField] private Transform destination = null;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.transform.position = destination.position;
		}
	}
}

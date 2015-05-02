using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour 
{
	private GameObject player = null;

	public void SetPlayer (GameObject newPlayer)
	{
		this.player = newPlayer;
	}

	void Update ()
	{
		this.gameObject.transform.position = this.player.transform.position;
	}
}

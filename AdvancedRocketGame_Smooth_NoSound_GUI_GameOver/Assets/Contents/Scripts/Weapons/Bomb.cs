using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour 
{
	void Awake ()
	{
		PlayerData.Instance.WeaponUses = 3;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Barrier")
		{
			Object.Destroy(other.gameObject);

			PlayerData.Instance.WeaponUses--;
			PlayerData.Instance.Score++;

			if (PlayerData.Instance.WeaponUses <= 0)
			{
				Object.Destroy(this.gameObject);
			}
		}
	}
}

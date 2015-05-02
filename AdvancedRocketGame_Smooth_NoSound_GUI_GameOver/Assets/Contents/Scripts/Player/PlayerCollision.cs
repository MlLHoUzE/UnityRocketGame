using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	[SerializeField] private GameObject explosionPrefab = null;
	[SerializeField] private GameObject weaponPrefab = null;
	private PlayerWeapon weapon = null;
	private bool isInvulnerable = false;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Obstacle"
		    || other.gameObject.tag == "Wall"
		    || other.gameObject.tag == "Barrier")
		{
			if (other.gameObject.tag == "Barrier")
			{
				if (PlayerData.Instance.Lives > 0)
				{
					--PlayerData.Instance.Lives;

					if (PlayerData.Instance.Lives == 0)
					{
						DestroyMe();
					}
				}
			} 
			else
			{
				PlayerData.Instance.Lives = 0;
				DestroyMe();
			}
		}

		if (other.gameObject.tag == "Weapon")
		{
			Object.Destroy(other.gameObject);

			GameObject bomb = UnityEngine.Object.Instantiate(this.weaponPrefab) as GameObject;
			this.weapon = bomb.GetComponent<PlayerWeapon>();
			this.weapon.SetPlayer(this.gameObject);
		}
	}

	/// <summary>
	/// Destroy this object.
	/// </summary>
	private void DestroyMe ()
	{
		// Instantiate the explosion prefab and store it in the explostionObject local variable.
		GameObject explosionObject = Object.Instantiate(this.explosionPrefab) as GameObject;

		// Set the global position of the explosion to the global position of the player.
		explosionObject.transform.position = this.gameObject.transform.position;

		// Destroy the equipped weapon.
		if (this.weapon != null)
		{
			Object.Destroy(this.weapon.gameObject);
		}

		// Destroy the player.
		Object.Destroy(this.gameObject);
	}

	private IEnumerator Invulnerable ()
	{
		this.isInvulnerable = true;
		yield return new WaitForSeconds(1);
		this.isInvulnerable = false;
	}
}

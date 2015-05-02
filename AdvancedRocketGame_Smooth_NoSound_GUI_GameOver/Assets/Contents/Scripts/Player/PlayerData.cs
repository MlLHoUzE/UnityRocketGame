using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour 
{
	#region Game Object Singleton
	
	public static PlayerData Instance = null;
	
	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;
			GameObject hudObject = Object.Instantiate(this.hudPrefab) as GameObject;
			this.hud = hudObject.GetComponent<HUD>();
			Object.DontDestroyOnLoad(hudObject);
			Object.DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Object.Destroy(this.gameObject);
		}
	}
	
	#endregion Game Object Singleton


	[SerializeField] private GameObject hudPrefab = null;

	private HUD hud = null;

	private int score = 0;
	private int lives = 3;
	private int weaponUses = 0;

	public int Score
	{
		get { return this.score; }
		set { 
			this.score = value; 
			this.hud.SetScore(value);
		}
	}

	public int WeaponUses
	{
		get { return this.weaponUses; }
		set { 
			this.weaponUses = value; 
			this.hud.SetWeaponUses(value);
		}
	}

	public int Lives
	{
		get { return this.lives; }
		set { 
			this.lives = value; 
			this.hud.SetLives(value);
		}
	}
}

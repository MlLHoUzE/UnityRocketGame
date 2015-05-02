using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour 
{
	[SerializeField] private LivesHUD livesHUD = null;
	[SerializeField] private ScoreHUD scoreHUD = null;
	[SerializeField] private WeaponHUD weaponHUD = null;
	
	#region Game Object Singleton
	
	public static HUD Instance = null;
	
	void Awake ()
	{
		if (Instance == null)
		{
			Object.DontDestroyOnLoad(this.gameObject);
			Instance = this;
		}
		else
		{
			Object.Destroy(this.gameObject);
		}
	}
	
	#endregion Game Object Singleton

	public void SetLives (int lives)
	{
		this.livesHUD.Lives = lives;
	}

	public void SetScore (int score)
	{
		this.scoreHUD.Score = score;
	}

	public void SetWeaponUses (int usesRemaining)
	{
		this.weaponHUD.Uses = usesRemaining;
	}

}

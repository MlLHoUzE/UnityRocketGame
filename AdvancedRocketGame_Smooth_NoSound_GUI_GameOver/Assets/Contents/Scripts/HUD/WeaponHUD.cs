using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
[RequireComponent(typeof(GUITexture))]
public class WeaponHUD : MonoBehaviour 
{
	[SerializeField] private Texture weaponIcon = null;

	[HideInInspector] public int Uses = 0;

	void Awake ()
	{
		this.guiText.enabled = false;
		this.guiTexture.enabled = false;
		this.guiTexture.texture = this.weaponIcon;
	}

	void OnGUI ()
	{
		if (this.Uses > 0)
		{
			this.guiTexture.enabled = true;

			// Set weapon uses text.
			this.guiText.enabled = true;
			this.guiText.text = this.Uses.ToString();
		}
		else
		{
			this.guiTexture.enabled = false;
			this.guiText.enabled = false;
		}
	}
}

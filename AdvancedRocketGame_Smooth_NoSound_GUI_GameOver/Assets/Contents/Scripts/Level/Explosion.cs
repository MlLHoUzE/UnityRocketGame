using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
	private void DestroyMe ()
	{
		Object.Destroy(this.gameObject);
	}
}

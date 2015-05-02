using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour
{
	[SerializeField] private float rotationSpeed = 0;

	private float RotationPerFrame
	{
		get { return this.rotationSpeed * Time.deltaTime; }
	}

	void Update ()
	{
		Rotate();
	}
	
	private void Rotate ()
	{
		this.transform.Rotate(Vector3.back, this.RotationPerFrame);
	}
}


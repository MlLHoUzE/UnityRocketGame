using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] private GameObject thrusterSprite = null;
	[SerializeField] private float speed = 1;
	[SerializeField] private float angle = 0;
	[SerializeField] private Vector2 direction;

	public float SpeedPerFrame
	{
		get { return this.speed * Time.deltaTime; }
	}


	#region MonoBehaviour

	void Update ()
	{
		// Determine in which direction the player is moving.
		this.direction = DetectKeyboardInput();

		// Point the player in that direction.
		Point (this.direction);

		// Move the player in that direction.
		Move (this.direction);

		// Visualize the player thrust effect.
		VisualizeThrust();
	}

	#endregion MonoBehaviour


	private void VisualizeThrust ()
	{
		// If the player is moving, show the animated thrust sprite.
		if (this.direction != Vector2.zero
		    && this.thrusterSprite.activeSelf == false)
		{
			// Player is not standing still. Therefore, the player is moving.
			// Show the animated thruster sprite, if it is currently invisible.
			this.thrusterSprite.SetActive(true);

			// If the animated thruster sprite is currently visible, then we do not need to set it to visible.
			// The (this.thrusterSprite.activeSelf == false) condition check makes sure of that.
			// This saves a bit of performance each frame, by avoiding setting a visible sprite to visible.
		}
		else if (this.direction == Vector2.zero
		         && this.thrusterSprite.activeSelf == true)
		{
			// Player is standing still. Therefore, the player is not moving.
			// Hide the animated thruster sprite, if it is currently visible.
			this.thrusterSprite.SetActive(false);

			// If the animated thruster sprite is currently invisible, then we do not need to hide it.
			// The (this.thrusterSprite.activeSelf == true) condition check makes sure of that.
			// This saves a bit of performance each frame, by avoiding setting a hidden sprite to invisible.
		}
	}

	private Vector2 DetectKeyboardInput ()
	{
		// Set our direction vector to zero.
		// Here we use Vector2.zero, which is equivalent to (0, 0).
		Vector2 movementDirection = Vector2.zero;

		// Check which arrow key is pressed.
		// If all four arrow keys are pressed, the resulting vector will be (0, 0). 
		// This is because all four direction vectors added together cancel each other out.
		// For example: 
		// Pressing left and right keys results in (1, 0) + (-1, 0) = (0, 0)
		// Pressing up and down keys results in (0, 1) + (0, -1) = (0, 0)
		// Pressing all four direction keys results in (1, 0) + (-1, 0) + (0, 1) + (0, -1) = (0, 0)
		// This also means that pressing right and up key at the same time results in diagonal motion: 
		// (1, 0) + (0, 1) = (1, 1)
		if (Input.GetKey(KeyCode.UpArrow))
		{
			// Add direction vector (0, 1) to movement direction.
			movementDirection += Vector2.up;
		} 

		if (Input.GetKey(KeyCode.DownArrow))
		{
			// Add direction vector (0, -1) to movement direction.
			movementDirection += -1 * Vector2.up;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// Add direction vector (-1, 0) to movement direction.
			movementDirection += -1 * Vector2.right;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			// Add direction vector (1, 0) to movement direction.
			movementDirection += Vector2.right;
		}

		// Return the resulting movement direction, based on the keyboard input.
		return movementDirection;
	}

	/// <summary>
	/// Move this object towards the specified movement direction.
	/// </summary>
	/// <param name="movementDirection">Movement direction.</param>
	private void Move (Vector2 movementDirection)
	{
		// Move my game object in the specified direction.
		// Here we use += assignment operator which adds what's on the left side of the operator to what's on the left.
		// In other words, the amount by which this object moves this frame is added to the object's current position.
		// The amount of movement is provided by the SpeedPerFrame property.
		// The direction of movement is provided by the movementDirection parameter.
		this.gameObject.transform.localPosition 
			+= ((Vector3)movementDirection * this.SpeedPerFrame);

		// Alternatively, we could have written the above line as:
		// this.gameObject.transform.localPosition = 
		// 			this.gameObject.transform.localPosition + ((Vector3)movementDirection * this.SpeedPerFrame);
	}
	
	/// <summary>
	/// Rotates this object to point in the specified direction.
	/// </summary>
	/// <param name="direction">Direction.</param>
	private float Point (Vector2 movementDirection)
	{
		// If the movement direction is not specified.
		if (movementDirection == Vector2.zero)
		{
			// Do not alter the previous rotation.
			// Simply return the previous angle and exit the method's execution.
			return this.angle;
		}

		// At this point, we know that the movementDirection is a value other than Vector2.zero or (0, 0, 0).
		// Now we need to figure out how to rotate this object to point in the direction specified by movementDirection.

		// Determine the angle to rotate by.
		// We will use the arctangent function to get the angle from the provided direction.
		// NOTE: See Unity Scripting Reference for details about Atan2.
		float angleInRadians = Mathf.Atan2(movementDirection.x, movementDirection.y);

		// The resulting angle is in radian units. Pointing this object towards a direction means we need to rotate it.
		// Rotating objects in 3D space requires us to pass in a Vector3 value (x, y, z). 
		// Vector3 takes in degree units, so we must convert the angle's radian value to degree units. 
		// We do so by multiplying the radian angle value with the radians-to-degrees conversion constant, which is:
		// 360 / (PI * 2)
		// NOTE: See Unity Scripting Reference for details about Rad2Deg conversion constant.
		float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

		// Rotate this object by the calculated degree angle.
		// We are using Vector3.back to say we are rotating about the z axis that points away from the screen 
		// towards us.
		// Vector3.back is equivalent to (0, 0, -1);
		// NOTE: See Unity Scripting Reference for details about Vector3.back.
		this.gameObject.transform.eulerAngles = Vector3.back * angleInDegrees;

		// Return the rotation angle in degrees.
		return angleInDegrees;
	}

}

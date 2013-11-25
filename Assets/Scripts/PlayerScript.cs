using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior.
/// </summary>
public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50,50);

	void Start () {
		
	}
	
	void Update () {
		// Retrive axys information
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		// Movement per direction
		Vector3 movement = new Vector3 (
			speed.x * inputX,
			speed.y * inputY,
			0);

		// Relative to the time
		movement *= Time.deltaTime;

		// Move the object in game
		transform.Translate (movement);

		// Shooting
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) 
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// False because the player is not an enemy
				weapon.Attack(false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();
			}
		}

		// Keep player inside camera bounds
		// Since all of these methods works only with the center of the sprite,
		// here i get the size of the bounding box of the sprite and reducing the
		// boundaries of the screen i manage to keep all the ship in the view
		Vector3 playerSize = renderer.bounds.size;

		// Here is the definition of the boundary in world point
		var distance = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x + (playerSize.x/2);
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x - (playerSize.x/2);

		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).y + (playerSize.y/2);
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distance)).y - (playerSize.y/2);
	
		// Here the position of the player is clamped into the boundaries
		transform.position = (new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, bottomBorder, topBorder),
			transform.position.z)
		);
	}

	void OnDestroy () {
		// Game over
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediatly
		transform.parent.gameObject.AddComponent<GameOverScript> ();	
	}
}

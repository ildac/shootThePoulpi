using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior.
/// </summary>
public class PlayerScript : MonoBehaviour {

	/// <summary>
	/// 1 - the speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50,50);

	void Start () {
		
	}
	
	void Update () {
		// 2 - retrive axys information
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		// 3 - movement per direction
		Vector3 movement = new Vector3 (
			speed.x * inputX,
			speed.y * inputY,
			0);

		// 4 - Relative to the time
		movement *= Time.deltaTime;

		// 5 - Move the object in game
		transform.Translate (movement);

		// 6 - Shooting
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) 
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}

	}
}

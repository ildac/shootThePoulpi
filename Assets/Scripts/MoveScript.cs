using UnityEngine;
using System.Collections;

/// <summary>
/// Move script, simply moves the current game objects.
/// </summary>
public class MoveScript : MonoBehaviour {

	// 1 - Designer variables 

	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10,10);

	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1,0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 2 - Movement
		Vector3 movement = new Vector3 (
			speed.x * direction.x,
			speed.y * direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate (movement);
	}
}

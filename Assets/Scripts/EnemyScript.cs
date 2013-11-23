using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy script, generic behavior.
/// </summary>
public class EnemyScript : MonoBehaviour {

	private bool hasSpawn = false;
	private MoveScript moveScript;
	private WeaponScript[] weapons;

	void Awake() {
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript> ();

		// Retreive the script to disable when not spawn
		moveScript = GetComponent<MoveScript> ();
	}

	void Start () {
		// Disable everything
		// - collider
		collider2D.enabled = false;
		// - moving
		moveScript.enabled = false;
		// - shooting
		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if (hasSpawn == false) 
		{
			if (renderer.isVisibleFrom (Camera.main)) 
			{
				Spawn ();
			}
		} else 
		{
			foreach (WeaponScript weapon in weapons) 
			{
				// Auto-fire
				if (weapon != null && weapon.CanAttack) 
				{
					weapon.Attack (true);
				}
			}

			if (renderer.isVisibleFrom(Camera.main) == false) 
			{
				Destroy(gameObject);
			}
		}
	}

	private void Spawn () {
		hasSpawn = true;

		// Enable EveryThing
		// - collider
		collider2D.enabled = true;
		// - moving
		moveScript.enabled = true;
		// - shooting
		foreach (WeaponScript weapon in weapons) {
			weapon.enabled = true;
		}
	}
}
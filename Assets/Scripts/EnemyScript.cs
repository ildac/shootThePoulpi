using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy script, generic behavior.
/// </summary>
public class EnemyScript : MonoBehaviour {

	private WeaponScript[] weapons;

	void Awake() {
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (WeaponScript weapon in weapons)
		{
			// Auto-fire
			if (weapon != null && weapon.CanAttack) 
			{
				weapon.Attack(true);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

/// <summary>
/// Shot script, projectil behavior.
/// </summary>
public class ShotScript : MonoBehaviour {

	// 1 - Designer variable

	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		// 2 - Limit the time to live to avoid any leak
		Destroy (gameObject, 20); //20 sec
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

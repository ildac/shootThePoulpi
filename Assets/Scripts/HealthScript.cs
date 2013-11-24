﻿using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 2;
	
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				hp -= shot.damage;
				
				// Destroy the shot
				// Remember to always target the game object,
				// otherwise you will just remove the script.
				Destroy(shot.gameObject);
				
				if (hp <= 0)
				{	
					// Explode!
					SpecialEffectsHelper.Instance.Explosion (transform.position);

					// Sound!
					SoundEffectsHelper.Instance.MakeExplosionSound ();

					// Dead!
					Destroy (gameObject);
				}
			}
		}
	}
}
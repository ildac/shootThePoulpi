using UnityEngine;
using System.Collections;

/// <summary>
/// Special effects helper, creating instance of particles from code with no effort
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour {

	/// <summary>
	/// Singleton.
	/// </summary>
	public static SpecialEffectsHelper Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	void Awake() {
		//register the singleton
		if (Instance != null) {
			Debug.LogError("Multiple instances of Special Effects Helper");
		}

		Instance = this;
						
	}

	/// <summary>
	/// Explosion in the specified position.
	/// </summary>
	/// <param name="position">Position.</param>
	public void Explosion(Vector3 position) {
		instantiate (smokeEffect, position);
		instantiate (fireEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
		ParticleSystem newParticleSystem = Instantiate (
			prefab, 
			position,
			Quaternion.identity
		) as ParticleSystem;

		// Make sure it will be destroyed
		// destroy the object after some time
		Destroy (
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;
		
	}
}

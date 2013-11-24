using UnityEngine;
using System.Collections;

/// <summary>
/// Sound effects helper, creating instance of sounds from code with no effort.
/// </summary>
public class SoundEffectsHelper : MonoBehaviour {

	/// <summary>
	/// Singleton.
	/// </summary>
	public static SoundEffectsHelper Instance;

	public AudioClip explosionSound;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;

	void Awake () {
		//singleton
		if (Instance != null) {
			Debug.LogError("Multiple instance of SoundEffectsHelper");
		}

		Instance = this;
	}

	public void MakeExplosionSound() {
		MakeSound (explosionSound);
	}

	public void MakePlayerShotSound() {
		MakeSound (playerShotSound);
	}

	public void MakeEnemyShotSound() {
		MakeSound (enemyShotSound);
	}

	/// <summary>
	/// Makes the sound, play a given sound.
	/// </summary>
	/// <param name="originalClip">Original clip.</param>
	private void MakeSound (AudioClip originalClip) {
		//As it is not 3D audio clip, position doesn't matter
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}
}

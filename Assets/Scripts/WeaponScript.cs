using UnityEngine;
using System.Collections;

/// <summary>
/// Weapon script, launch projectile.
/// </summary>
public class WeaponScript : MonoBehaviour {

	// 1 - Designer variables

	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;

	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.25f;

	/// <summary>
	/// The size of the pool, how many projectile at the same moment on the screen.
	/// </summary>
	public int poolSize = 5;

	// The actual pool where are keep all the projectile on the screen
	private Transform[] shotPool = null;

	// The actual position of the pool
	private int actualPoolIndex = 0;

	// 2 - Cooldown
	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = Random.Range(0f,2f); 
	}

	void Awake() 
	{
		shotPool = new Transform[poolSize];
		
	}

	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) 
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	// 3 - Shooting from another script

	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	/// <param name="isEnemy">If set to <c>true</c> if is enemy.</param>
	public void Attack (bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// Assign position
			shotTransform.position = transform.position;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) 
			{
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite 
			}

			// Pool, to avoid too many projectile in the screen
			if (shotPool[actualPoolIndex] != null)
			{	
				Destroy(shotPool[actualPoolIndex].gameObject);
				shotPool[actualPoolIndex] = null;
			}

			// Metto il nouvo elemento nella pool
			shotPool[actualPoolIndex] = shotTransform;
			actualPoolIndex ++;

			// Se ho finito la pool inizio ad eliminare gli elementi più vecchi
			if (actualPoolIndex >= poolSize) actualPoolIndex = 0;
		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	/// <value><c>true</c> if can attack; otherwise, <c>false</c>.</value>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}

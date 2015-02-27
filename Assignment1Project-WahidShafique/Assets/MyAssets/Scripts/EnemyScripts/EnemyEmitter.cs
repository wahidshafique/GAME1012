using UnityEngine;
using System.Collections;

public class EnemyEmitter : MonoBehaviour { 
	//This controls the projectiles that emit from the enemy beaks
	public float lowerFireRange = 1f; //Ranges define random intervals for firerate
	public float higherFireRange = 5f;
	public GameObject birdSeedProjectile;
	private float nextFire = 0f;//controls first instance of instantiated object
	
	void Update () {
		float fireRate = Random.Range(lowerFireRange, higherFireRange);
		if ( Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector2 position = transform.position;
			Instantiate(birdSeedProjectile, position, transform.rotation);
		}
	}
}

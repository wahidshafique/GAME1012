using UnityEngine;
using System.Collections;

public class EnemyEmitter : MonoBehaviour {
	public float lowerFireRange = 1f;
	public float higherFireRange = 5f;
	public GameObject birdSeedProjectile;
	private float nextFire = 0f;
	
	void Update () {
		float fireRate = Random.Range(lowerFireRange, higherFireRange);
		if ( Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			Instantiate(birdSeedProjectile, position, transform.rotation);
		}
	}
}

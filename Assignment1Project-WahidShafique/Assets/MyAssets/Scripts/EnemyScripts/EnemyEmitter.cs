using UnityEngine;
using System.Collections;

public class EnemyEmitter : MonoBehaviour {
	public GameObject birdSeedProjectile;
	private float nextFire = 0f;
	
	void Update () {
		float fireRate = Random.Range(1f, 5f);
		if ( Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			GameObject bullet = (GameObject)Instantiate(birdSeedProjectile, position, transform.rotation);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	//a shared spawner used by enemies and powerups
	public float lowerFireRange;//Ranges define random intervals for firerate
	public float higherFireRange;
	public float nextFire = 0f;//controls first instance of instantiated object
	public GameObject spawn;
	
	void Update () {
		//randomly shoot the specified gameobjects from spawners 
		float fireRate = Random.Range(lowerFireRange, higherFireRange);
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			Instantiate(spawn, position, transform.rotation);
		}
	}
}


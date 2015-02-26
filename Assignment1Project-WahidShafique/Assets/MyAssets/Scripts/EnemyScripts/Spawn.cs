using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public float lowerFireRange;
	public float higherFireRange;
	public GameObject spawn;
	public float nextFire = 0f;//control first instance 
	
	void Update () {
		float fireRate = Random.Range(lowerFireRange, higherFireRange);
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			Instantiate(spawn, position, transform.rotation);
		}
	}
}


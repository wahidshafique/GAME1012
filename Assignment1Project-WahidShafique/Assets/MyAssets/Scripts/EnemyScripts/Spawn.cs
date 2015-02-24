using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public float lowerFireRange;
	public float higherFireRange;
	public GameObject enemy;
	private float nextFire = 0f;
	
	void Update () {
		float fireRate = Random.Range(lowerFireRange, higherFireRange);
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			GameObject bullet = (GameObject)Instantiate(enemy, position, transform.rotation);
		}
	}
}


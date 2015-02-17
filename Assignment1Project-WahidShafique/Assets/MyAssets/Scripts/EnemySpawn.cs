using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public GameObject enemy;
	private float nextFire = 0f;
	
	void Update () {
		float fireRate = Random.Range(3f, 5f);
		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			GameObject bullet = (GameObject)Instantiate(enemy, position, transform.rotation);
		}
		//Destroy(GameObject.Find("Projectile(Clone)"),3f); //destroys cloned projectiles after a set interval
	}
}


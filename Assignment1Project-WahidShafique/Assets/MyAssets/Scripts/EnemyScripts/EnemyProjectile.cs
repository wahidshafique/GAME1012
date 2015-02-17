using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
	private float speed = 15f;
	
	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Bound" || coll.gameObject.tag == "Bullet"){
			Destroy (gameObject);
		}
	}
}

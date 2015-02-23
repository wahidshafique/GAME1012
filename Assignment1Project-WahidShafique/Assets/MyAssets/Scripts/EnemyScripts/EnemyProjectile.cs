using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
	private float speed = 15f;
	
	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		tag = coll.gameObject.tag;
		if (tag == "Player" || tag == "Bound" || tag == "Bullet"){
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float speed = 10f;
	
	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy"){
			Destroy (gameObject);
		}
	}
}


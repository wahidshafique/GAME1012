using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	private float speed = 20f;

	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		tag = coll.gameObject.tag;
		if (tag == "Player" || tag == "Bound"){
			Destroy (gameObject);
		}
	}
}


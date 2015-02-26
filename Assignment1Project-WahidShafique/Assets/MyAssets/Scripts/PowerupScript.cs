using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	public float speed = 20f;

	void Update () {//shoot left 
		this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){//destroy powerup if it hits player or bound
		tag = coll.gameObject.tag;
		if (tag == "Player" || tag == "Bound"){
			Destroy (gameObject);
			print ("hit a player or bound ");
		}
	}
}


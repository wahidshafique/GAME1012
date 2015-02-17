using UnityEngine;
using System.Collections;

public class ShipHitCheck : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy"){
			Destroy (gameObject);
			Application.LoadLevel(0);
		}
	}
}

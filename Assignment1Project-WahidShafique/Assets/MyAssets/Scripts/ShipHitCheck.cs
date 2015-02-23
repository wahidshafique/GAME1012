﻿using UnityEngine;
using System.Collections;

public class ShipHitCheck : MonoBehaviour {
	public GameObject explosionPrefab = null;

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EnemyBullet"){
			DestroyMe();
		}
	}
		private void DestroyMe (){ //Creates explosion based on ships position
			Destroy (this.gameObject);
			GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
			explosionObject.transform.position = this.transform.position;
		}
}

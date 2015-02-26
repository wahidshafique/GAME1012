using UnityEngine;
using System.Collections;

public class ShipHitCheck : MonoBehaviour {
	public GameObject explosionPrefab = null;
	public GameObject rotator = null;
	public GameObject turret = null;
	public GameObject emitter = null;
	
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EnemyBullet"){

			DestroyMe();
		}
		if (coll.gameObject.tag == "BombPickup"){

			StartCoroutine(activateShield(rotator));
			print ("activate bomb");
		}
		if (coll.gameObject.tag == "TurretPickup"){

			StartCoroutine (activateShield(turret));
			print ("activate turret");
		}
	}
    void DestroyMe (){ //Creates explosion based on ships position
			Destroy (this.gameObject);
			GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
			explosionObject.transform.position = this.transform.position;
		}
	IEnumerator activateShield (GameObject input){//takes in gameObject (the powerups) and sets it active for 3 seconds
		input.SetActive(true);
		if (input == turret){
			emitter.SetActive (false);
		}

		yield return new WaitForSeconds(4f);

		if (input == turret){
			emitter.SetActive (true);
		}
		input.SetActive(false);
	}

}


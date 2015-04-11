using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {//script controlling the movement of elevator and the destruction of it 
	public GameObject explosion;//object to be activated when platform goes away
	private bool platActive = false; //platform starts inactive

	void Update () {
		if (platActive)//moves down if active (if you, the player, step on it
		transform.Translate(Vector3.down * Time.deltaTime, Space.World);//moves platform down in world space 
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Death"){//trigger explosion and destroy when plat in near fire 
			Destroy(this.gameObject);//destroys the elevator 
			explosion.SetActive(true);//sets a previously deactivated explosion object to true 
		}
		StartCoroutine (moveDown());//delay a bit once player in on plat, as to not jar the player
	}
	IEnumerator moveDown (){
		yield return new WaitForSeconds (0.5f);
		platActive = true; //once player is in trigger, sets the plat to active after a few secs 
	}
}

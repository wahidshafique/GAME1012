using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {//this script is the bombs collision and FX
	public GameObject explosionPrefab; //object to be instantiated when bomb gets destroyed

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Turret" || collision.collider.tag == "WallsFloor"){//bomb only explodes with room and turret
		Destroy(this.gameObject);//destroy said bomb
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;//create explosion at its last position
		explosionObject.transform.position = this.transform.position;
		}
	}
}

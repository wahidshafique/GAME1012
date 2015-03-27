using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Fire"){
			Destroy(this.gameObject);
			explosion.SetActive(true);
		}

	}
}

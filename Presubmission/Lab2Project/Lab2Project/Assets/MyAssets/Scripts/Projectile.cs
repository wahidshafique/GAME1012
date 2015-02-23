using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Rigidbody projectile;
	// Use this for initialization
	

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			Rigidbody clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 50);
		}

		Destroy(GameObject.Find("projectile(Clone)"),0.5f);
	}
}


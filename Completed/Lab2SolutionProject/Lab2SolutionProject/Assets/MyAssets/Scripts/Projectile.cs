using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1;
	public float lifeSpan = 3;

	void Update () 
	{
		this.transform.Translate(new Vector3(0, 0, this.speed));
		StartCoroutine(DestroyAfterDelay());
	}

	IEnumerator DestroyAfterDelay ()
	{
		yield return new WaitForSeconds(this.lifeSpan);
		GameObject.Destroy(this.gameObject);
	}
}

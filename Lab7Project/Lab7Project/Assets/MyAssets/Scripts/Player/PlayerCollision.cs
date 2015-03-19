using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	[SerializeField] private GameObject explosionPrefab = null;
	[SerializeField] private float impactTolerance = 7f;

	void Update () {
		if (PlayerData.Instance.Health <= 0) {
			DestroyMe();
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall")
		    || collision.gameObject.CompareTag("Barrier"))
		{
			if (collision.relativeVelocity.magnitude > this.impactTolerance)
			{
				AudioManager.Instance.PlayTooFastCollisionClip();
				DestroyMe ();
			}
			else
			{
				AudioManager.Instance.PlayCollisionClip();
				PlayerData.Instance.Health--;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Coin")
		{
			PlayerData.Instance.Score++;
			AudioManager.Instance.PlayCoinCollectClip();
			Destroy(other.gameObject);
		}
	}

	private void DestroyMe ()
	{
		Destroy (this.gameObject);
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
		explosionObject.transform.position = this.transform.position;
	}
}

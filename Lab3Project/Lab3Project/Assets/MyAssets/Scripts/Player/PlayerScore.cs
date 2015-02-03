using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Keeps track of player score and displays it on the screen.
/// </summary>
public class PlayerScore : MonoBehaviour 
{ 
	public Text myText;
	public int score = 0;
	void OnTriggerEnter2D (Collider2D other)
	{
		// Check if we collided with an object tagged "Coin".
		if (other.gameObject.tag == "Coin")
		{

			// We have collided with a coin. 
			// TODO: Increment our score.
			score++;
			// TODO: Display ssthe score.
			this.myText.text = "Score: " + score;
			// TODO: Destroy the coin.
			Destroy(other.gameObject);
		}
	}
	void Update () {

		if (score == 5)
			Application.LoadLevel(0);

	}
}

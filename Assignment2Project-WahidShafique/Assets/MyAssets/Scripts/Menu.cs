using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public bool manualLoad = false; //for animator; once you die it triggers and loads menu
	
	void Update () {
		if (manualLoad)
			Application.LoadLevel("MainMenu");
	}

	public void MainMenu () {
		Application.LoadLevel("MainMenu");
	}
	
	public void Level1 () {
		Application.LoadLevel("Level1");
	}
	
	public void Level2 () {
		Application.LoadLevel("Level2");
	}

	public void Level3 () {
		Application.LoadLevel("Level3");
	}
	
	public void Quit () {
		Application.Quit();
		print ("Quitting...");
	}
}

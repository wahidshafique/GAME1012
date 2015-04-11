using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {//controls all main and sub menu options (GUI)
	public bool manualLoad = false; //for animator; this bool is manually set to true after the death anim finishes
	
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

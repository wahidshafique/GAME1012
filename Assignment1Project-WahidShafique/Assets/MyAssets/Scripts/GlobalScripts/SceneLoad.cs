using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {
	//controls behaviour for all buttons and functions and features a manual loader when ship gets hit
	public bool manualLoad = false;

	void Update () {
		if (manualLoad)
		Application.LoadLevel(0);//constant check of whether you are still alive 
	}

	//exposed controls for GUI buttons
	public void Load(){
		Application.LoadLevel(1);
	}

	public void Back (){
		Application.LoadLevel(0);
	}

	public void Quit (){
	Application.Quit();
	print ("Quitting...");
	}
}

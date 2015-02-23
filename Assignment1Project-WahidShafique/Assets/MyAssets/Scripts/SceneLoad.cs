using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {
	//controls behaviour for all buttons and functions are manual loader when ship gets hit
	public bool manualLoad = false;
void Update (){
		if (manualLoad)
		Application.LoadLevel(0);
	}

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

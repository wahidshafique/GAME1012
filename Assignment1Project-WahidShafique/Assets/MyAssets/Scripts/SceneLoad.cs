using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {
	//controls behaviour for all buttons in game
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

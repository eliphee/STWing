using UnityEngine;
using System.Collections;

public class MainButtons : MonoBehaviour {

	// Start FleetManager
	public void startFM () 
	{
		Application.LoadLevel("FleetManager");
	}

	// Start Main
	public void startGame () 
	{
		Application.LoadLevel("Main");
	}
}

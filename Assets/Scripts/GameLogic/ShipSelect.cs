using UnityEngine;
using System.Collections;

public class ShipSelect : MonoBehaviour {

	/// <summary>
	/// Generates a movement pattern for debuging purposes.
	/// </summary>
	/// <returns>The pattern.</returns>
	private Ship.Maneuver[] debugPattern()
	{
		Ship.Maneuver[] debugManeuvers = new Ship.Maneuver[]
		{
			new Ship.Maneuver(1, "Straight", "green"),
			new Ship.Maneuver(1, "LeftBank", "green"),
			new Ship.Maneuver(1, "RightBank", "green"),
			new Ship.Maneuver(2, "Straight", "green"),
			new Ship.Maneuver(2, "LeftBank", "white"),
			new Ship.Maneuver(2, "LeftTurn", "white"),
			new Ship.Maneuver(2, "RightBank", "white"),
			new Ship.Maneuver(2, "RightTurn", "white"),
			new Ship.Maneuver(3, "Straight", "white"),
			new Ship.Maneuver(3, "LeftBank", "white"),
			new Ship.Maneuver(3, "LeftTurn", "red"),
			new Ship.Maneuver(3, "RightBank", "white"),
			new Ship.Maneuver(3, "RightTurn", "red"),
			new Ship.Maneuver(4, "Straight", "white"),
			new Ship.Maneuver(-1, "FullAstern", "red")
		};

		return debugManeuvers;
	}


	void OnMouseDown()
	{
		// Display movement pattern in GUI 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

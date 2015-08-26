using UnityEngine;
using System.Collections;

public class ShipLoader : MonoBehaviour {

	public const string path = "Assets\\GameData\\DataBaseHelper\\ShipsAlternativ.xml";

	// Use this for initialization
	void Start () 
	{
		ShipCollection sc = ShipCollection.Load(path);

		foreach (ShipClass ship in sc.shipClass)
		{
			print (ship.id);
			print (ship.shipName);
		}
	}

}


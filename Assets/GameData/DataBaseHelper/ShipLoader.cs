using UnityEngine;
using System.Collections;

public class ShipLoader : MonoBehaviour {

	public const string path = "..\\DataBaseHelper\\ShipsAlternativ.xml";

	// Use this for initialization
	void Start () 
	{
		ShipCollection sc = ShipCollection.Load(path);

		foreach (ShipClass ship in sc.shipClass)
		{
			print (ship.id);
		}
	}

}


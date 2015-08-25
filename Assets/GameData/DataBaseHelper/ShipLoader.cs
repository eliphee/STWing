using UnityEngine;
using System.Collections;

public class ShipLoader : MonoBehaviour {

	public const string path = "..\\DataBaseHelper\\ShipsAlternativ.xml";

	// Use this for initialization
	void Start () 
	{
		ShipColl sc = ShipColl.Load(path);

		foreach (ShipClass ship in sc.shipClass)
		{
			print (ship.id);
		}
	}

}


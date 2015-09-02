using UnityEngine;
using System.Collections;

//Vielleicht sinnvolle Altcodes

/*
foreach(XElement singleFleet in fleetDB.Elements().Elements())
{
	singleFleet.Remove();
}


foreach(XElement fleet in fleetDB.Elements())
		{
			foreach(XElement singleFleet in fleet.Elements())
			{
				//Prüft ob die FlottenID dem aktuellen Element entspricht
				if(singleFleet.Attribute("id").Value == _fleetID)
				{
					//entfernt die Flotte und speichert es in die Flotten-DB
					singleFleet.Remove();
					saveFleetDB(fleetDB);
					break;
				}
			}
		}


Debug.Log ("Test: " + singleShip.Name);
						Debug.Log ("Schiffe: "+singleShip.Attribute("fleetShip").Value + " = " + _fleetShipID);
						Debug.Log ("Karten: "+singleShip.Attribute("shipCard"));

*/
public class bla{
	// UNDER CONSTRUCTION
	public void savePlayerFleet (string name, float date, int[][] shipFleet) 
	{
		
	}

	// UNDER CONSTRUCTION
	public Fleet loadPlayerFleet () 
	{
		Fleet x = new Fleet();
		return x;
	}
}


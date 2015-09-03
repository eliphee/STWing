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



//UNDER CONSTRUCTION IMPORT FLEET!
	public void importFleet (XmlDocument _newFleet)
	{
		int i = 0;
		List<string> fleetIDs = new List<string>();
		//foreach(XmlElement dbFleets in newFleet.DocumentElement)
		//{
		//	i++;
		//}

		//i = 0;

//laden der Flotten-DB
XDocument fleetDB = loadFleetDB();
Debug.Log("Alle in der DB vorhandenen IDs: ");
foreach(XElement dbFleets in fleetDB.Elements())
{
	//fleetIDs.Add(dbFleets.GetAttribute("id"));
	Debug.Log("IDs: " + fleetIDs[i]);
	i++;
}

foreach(XmlElement newFleets in _newFleet.DocumentElement)
{
	for(int y = 0; y < fleetIDs.Count; y++)
	{
		if(fleetIDs[y] == newFleets.GetAttribute("id"))
		{
			fleetIDs.Sort();
			string test = fleetIDs[fleetIDs.Count-1];
			if(Int32.Parse(test) < 9)
			{
				test = "0"+(Int32.Parse(test)+1);
				Debug.Log(test);
			}
			else
			{
				test = (Int32.Parse(test)+1).ToString();
			}
			newFleets.SetAttribute("id", test);
			fleetIDs.Add(test);
		}
	}
}

}

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


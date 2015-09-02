using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;
using System.Xml.Linq;

public class PlayerDataHelper : MonoBehaviour {

	private XmlDocument loadTestDB()
	{
		XmlDocument myXmlDocument = new XmlDocument();
		myXmlDocument.Load ("Assets\\GameData\\PlayerData\\fleets2.xml");
		
		return myXmlDocument;
  	}

	private const string PATH = "Assets\\GameData\\PlayerData\\fleets.xml";

	// ZUM TESTEN!
	void Start()
	{
		/*XDocument test = loadFleetDB();
		foreach(XElement teil in test.Elements())
		{
			foreach(XElement unterTeil in teil.Elements())
			{
				Debug.Log("ID: "+unterTeil.Attribute("id").Value);
				Debug.Log("Name: "+unterTeil.Attribute("name").Value);
				if(unterTeil.Attribute("id").Value == "03")
				{
					unterTeil.SetAttributeValue("id", "04");
				}
				saveFleetDB(test);
			}
		}*/
		//deleteFleet("02");
		deleteCard("02", "1", "2");
		//emptyFleetDB();
		/*XDocument test = loadFleetDB();
		foreach(XElement teil in test.Elements())
		{
			foreach(XElement unterTeil in teil.Elements())
			{
				Debug.Log("ID: "+unterTeil.Attribute("id").Value);
				Debug.Log("Name: "+unterTeil.Attribute("name").Value);
			}
		}*/
		//importFleet(loadTestDB());
	}

	//UNDER CONSTRUCTION
	public void createFleet ()
	{

	}


	//UNDER CONSTRUCTION IMPORT FLEET!
	public void importFleet (XmlDocument _newFleet)
	{
		int i = 0;
		List<string> fleetIDs = new List<string>();
		/*foreach(XmlElement dbFleets in newFleet.DocumentElement)
		{
			i++;
		}

		i = 0;*/

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



	////
	// AB HIER FERTIG! (laden, speichern, löschen)
	////
	/// 

	/**
	 * Selektiert das durch die Flotten-ID angeforderte Flottenelement und gibt es als XElement zurück.
	 * 
	 * _fleetDB: Die zu durchsuchende DB
	 * _fleetID: Die zu suchende Flotten-ID
	 */
	private XElement selectElement(XDocument _fleetDB, string _fleetID)
	{
		foreach(XElement singleFleet in _fleetDB.Elements().Elements())
		{
			if(singleFleet.Attribute("fleetID").Value == _fleetID)
			{
				return singleFleet;
			}
		}
		return null;
	}

	/**
	 * Selektiert das durch die Flotten-ID und Schiff-ID angeforderte Schiffselement und gibt es als XElement zurück.
	 * 
	 * _fleetDB: Die zu durchsuchende DB
	 * _fleetID: Die zu suchende Flotten-ID
	 * _fleetShipID: Die zu suchende Schiffs-ID
	 */
	private XElement selectElement(XDocument _fleetDB, string _fleetID, string _fleetShipID)
	{
		if(check (selectElement(_fleetDB, _fleetID)))
		{
			foreach(XElement singleShip in selectElement(_fleetDB, _fleetID).Elements())
			{
				//Prüft ob die FlottenID dem aktuellen Element entspricht
				if(singleShip.Attribute("fleetShip").Value == _fleetShipID)
				{
					return singleShip;
				}
			}
		}
		return null;
	}

	/**
	 * Selektiert das durch die Flotten-ID, Schiff-ID und Card-ID angeforderte Kartenelement und gibt es als XElement zurück.
	 * 
	 * _fleetDB: Die zu durchsuchende DB
	 * _fleetID: Die zu suchende Flotten-ID
	 * _fleetShipID: Die zu suchende Schiffs-ID
	 * _shipCard: Die gesuchte Karten-ID
	 */
	private XElement selectElement(XDocument _fleetDB, string _fleetID, string _fleetShipID, string _shipCard)
	{
		if(check (selectElement(_fleetDB, _fleetID, _fleetShipID)))
		{
			foreach(XElement singleCard in selectElement(_fleetDB, _fleetID, _fleetShipID).Elements())
			{
				//Prüft ob die FlottenID dem aktuellen Element entspricht
				if(singleCard.Attribute("shipCard").Value == _shipCard)
				{
					return singleCard;
				}							
			}
		}
		return null;
	}

	public bool check(XElement _element)
	{
		if(_element == null)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	/**
	 * Löscht ein Schiff aus einer Flotte.
	 * 
	 * fleetID: Die ID der Flotte, aus der das Schiff gelöscht werden soll.
	 * shipID: Ist die ID des zu löschenden Schiffs.
	 */
	public void deleteShip(string _fleetID, string _fleetShipID)
	{
		XDocument fleetDB = loadFleetDB();
		XElement ship = selectElement(fleetDB, _fleetID, _fleetShipID);
		if(check (ship))
			ship.Remove();
		//entfernt die Flotte und speichert es in die Flotten-DB
		saveFleetDB(fleetDB);
	}

	/**
	 * Löscht eine Update-Karte aus einem Schiff der Flotte.
	 * 
	 * _fleetID: Die ID der Flotte.
	 * _fleetShipID: Die ID des Schiffes.
	 * _shipCard: Die ID der zu löschenden Update-Karte
	 */
	public void deleteCard(string _fleetID, string _fleetShipID, string _shipCard)
	{
		XDocument fleetDB = loadFleetDB();
		XElement card = selectElement(fleetDB, _fleetID, _fleetShipID, _shipCard);
		if(check (card))
			card.Remove();
		//entfernt die Flotte und speichert es in die Flotten-DB
		saveFleetDB(fleetDB);
	}

	/**
	 * Löscht eine komplette Flotte aus der Flotten-DB.
	 * 
	 * _fleetID: Ist die ID der zu löschenden Flotte.
	 */
	public void deleteFleet(string _fleetID)
	{
		XDocument fleetDB = loadFleetDB();
		XElement fleet = selectElement(fleetDB, _fleetID);
		if(check (fleet))
			fleet.Remove();
		//entfernt die Flotte und speichert es in die Flotten-DB
		saveFleetDB(fleetDB);
	}

	/**
	 * Lädt die aktuell existierende "fleets.xml" und gibt diese als XmlDocument zurück
	 */
	private XDocument loadFleetDB()
	{
		return XDocument.Load(PATH);
	}
	
	/**
	 * Speichert das übergebene XDocument auf den Fleet-DB Pfad
	 */
	private void saveFleetDB(XDocument _fleetDB)
	{
		_fleetDB.Save(PATH);
	}	

	/**
	 * Löscht alle Flotten aus der DB.
	 */
	public void emptyFleetDB()
	{
		XDocument fleetDB = loadFleetDB();

		fleetDB.Elements().Elements().Remove();

		saveFleetDB(fleetDB);
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;
using System.Xml.Linq;
using System.Linq;

/**
 * Die Klasse PlayerDataHelper stellt die Bearbeitungsfunktionen der FleetManagerDB zur Verfügung. 
 * 
 * Flotten/Schiffe/Karten hinzufügen und löschen 
 * Flotten-Namen ändern
 * Die komplette DB leeren.
 */
public class PlayerDataHelper : MonoBehaviour {

	private const string PATH = "Assets\\GameData\\PlayerData\\fleets.xml";
	private const string testDB = "Assets\\GameData\\PlayerData\\fleets2.xml";

	// ZUM TESTEN!
	/*void Start()
	{
		XDocument test = loadFleetDB();
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
		//deleteFleet("2");
		//addFleet("Testing1");
		//addCard("5", "2", "01");
		//deleteShip("4", "1");
		//emptyFleetDB();
		//changeFleetName("5", "wennsklappt");
		/*XDocument test = loadFleetDB();
		foreach(XElement teil in test.Elements())
		{
			foreach(XElement unterTeil in teil.Elements())
			{
				Debug.Log("ID: "+unterTeil.Attribute("id").Value);
				Debug.Log("Name: "+unterTeil.Attribute("name").Value);
			}
		}
	}*/

	//UNDER CONSTRUCTION
	//Comment fehlt, müsste aber schon funktionieren. 
	public XDocument loadImportDB(string _path)
	{
		XDocument importDB = XDocument.Load (_path);
		return importDB;
	}


	////
	// AB HIER FERTIG! (Hinzufügen, laden, speichern, löschen, umbenennen)
	////

	/**
	 * Fügt eine neue Flotte, mit Namen, der DB hinzu.
	 * 
	 * _name: Name der neuen Flotte
	 */
	public void addFleet (string _name)
	{
		XDocument fleetDB = loadFleetDB();
		XElement fleetList = fleetDB.Element("fleetList");
		int fleetID = fleetList.Elements("fleet").Count()+1;
		
		fleetList.Add(new XElement("fleet", new XAttribute("fleetID", fleetID), new XAttribute("name", _name), ""));
		
		saveFleetDB(fleetDB);
	}
	
	/**
	 * Fügt eine neues Schiff der gewünschten Flotte hinzu.
	 * 
	 * _fleetID: ID der Flotte
	 * _cardID: Datenbank-ID der Karte
	 */
	public void addCard (string _fleetID, string _cardID)
	{
		XDocument fleetDB = loadFleetDB();
		XElement fleet = selectElement(fleetDB, _fleetID);
		int fleetShip = fleet.Elements("ship").Count()+1;
		
		fleet.Add(new XElement("ship", new XAttribute("shipID", _cardID), new XAttribute("fleetShip", fleetShip), ""));
		
		saveFleetDB(fleetDB);
	}
	
	/**
	 * Fügt eine neue Karte dem gewünschten Schiff hinzu.
	 * 
	 * _fleetID: ID der Flotte
	 * _shipID: ID des Schiffes
	 * _cardID: Datenbank-ID der Karte
	 */
	public void addCard (string _fleetID, string _shipID, string _cardID)
	{
		XDocument fleetDB = loadFleetDB();
		XElement fleetShip = selectElement(fleetDB, _fleetID, _shipID);
		int shipCard = fleetShip.Elements("card").Count()+1;
		
		fleetShip.Add(new XElement("card", new XAttribute("cardID", _cardID), new XAttribute("shipCard", shipCard)));
		
		saveFleetDB(fleetDB);
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
		{
			ship.Remove();
			//entfernt die Flotte und speichert es in die Flotten-DB
			saveFleetDB(fleetDB);

			sortElement(fleetDB, _fleetID);
		}
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
		{
			card.Remove();
			//entfernt die Flotte und speichert es in die Flotten-DB
			saveFleetDB(fleetDB);

			sortElement(fleetDB, _fleetID, _fleetShipID);
		}
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
		{
			fleet.Remove();
			//entfernt die Flotte und speichert es in die Flotten-DB
			saveFleetDB(fleetDB);
			sortElement(fleetDB);
		}
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

	/**
	 * Ändert den Flottennamen der gewünschten Flotte
	 * 
	 * _fleetID: ID der zu ändernden Flotte
	 * _newName: neuer Name
	 */
	public void changeFleetName(string _fleetID, string _newName)
	{
		XDocument fleetDB = loadFleetDB();
		selectElement(fleetDB, _fleetID).SetAttributeValue("name", _newName);
		saveFleetDB(fleetDB);
	}

	///////
	/// Private Methoden
	///////

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
	 * "Fleet" im übergebenen XDocument wird aufsteigend sortiert.
	 * 
	 * _fleetDB: Zu sortierende Datenbank
	 */
	private void sortElement(XDocument _fleetDB)
	{
		int i = 1;
		foreach(XElement sort in _fleetDB.Elements().Elements())
		{
			sort.SetAttributeValue("fleetID", i);
			i++;
		}
		
		saveFleetDB(_fleetDB);
	}
	
	/**
	 * "Ship" in der angegebenen Fleet wird aufsteigend sortiert
	 * 
	 * _fleetDB: Datenbank
	 * _fleetID: zu sortierende Fleet
	 */
	private void sortElement(XDocument _fleetDB, string _fleetID)
	{
		int i = 1;
		foreach(XElement sort in selectElement(_fleetDB, _fleetID).Elements())
		{
			sort.SetAttributeValue("fleetShip", i);
			i++;
		}
		
		saveFleetDB(_fleetDB);
	}
	
	/**
	 * "Card" im ausgewählten Schiff der angegebenen Fleet wird aufsteigend sortiert
	 * 
	 * _fleetDB: Datenbank
	 * _fleetID: ausgewählte Fleet
	 * _shipID: zu sortierendes Schiff
	 */
	private void sortElement(XDocument _fleetDB, string _fleetID, string _shipID)
	{
		int i = 1;
		foreach(XElement sort in selectElement(_fleetDB, _fleetID, _shipID).Elements())
		{
			sort.SetAttributeValue("shipCard", i);
			i++;
		}
		
		saveFleetDB(_fleetDB);
	}

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
	
	/**
	 * Prüft ob das übergebene XElement 'null' ist.
	 * 
	 * Element = null -> return: false
	 */
	private bool check(XElement _element)
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
}
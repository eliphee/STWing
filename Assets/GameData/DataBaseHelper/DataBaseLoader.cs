using UnityEngine;
using System.Collections;

public class DataBaseLoader : MonoBehaviour {

	public const string constPath = "Assets\\GameData\\Data\\";
	public const string SHIPPATH = "Ships.xml";
	public const string CREWPATH = "UpgradesCrew.xml";

	void Start ()
	{
		//gibt ne Warning, muss korrigiert werden!
		new DataBaseLoader(SHIPPATH);
	}

	// Use this for initialization
	public DataBaseLoader (string type) 
	{
		string endPath = constPath + type;
		switch (type)
		{
			case SHIPPATH:
				shipLoad(endPath);
			break;
			case CREWPATH:
				crewLoad(endPath);
			break;

			default:
				SendMessage("DataBaseLoader kann die Datenbank nicht finden!");
			break;
		}

	}

	private ShipCollection shipLoad(string path)
	{
		ShipCollection sc = ShipCollection.Load(path);

		//nur zum testen, sonst unnötig
		foreach (ShipClass ship in sc.shipClass)
		{
			print (ship.id);
		}
		return sc;
	}

	private CrewCollection crewLoad(string path)
	{
		CrewCollection cc = CrewCollection.Load(path);
		return cc;
	}
}
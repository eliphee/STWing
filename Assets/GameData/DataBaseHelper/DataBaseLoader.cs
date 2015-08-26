using UnityEngine;
using System.Collections;

public class DataBaseLoader : MonoBehaviour{

	public const string PATH = "Assets\\GameData\\Data\\";
	public const string SHIPPATH = "Ships.xml";
	public const string CREWPATH = "UpgradesCrew.xml";
	public const string WEAPONPATH = "UpgradesWeapons.xml";
	public const string TECHPATH = "UpgradesTech.xml";
	public const string SHIPABILITYPATH = "ShipAbilities.xml";
	public const string CAPTAINPATH = "Captains.xml";
	public const string CAPTAINUPGRADEPATH = "CaptainUpgrades.xml";


	void Start ()
	{
		//gibt ne Warning, muss korrigiert werden!
		new DataBaseLoader(SHIPPATH);
	}

	// Use this for initialization
	public DataBaseLoader (string type) 
	{
		string endPath = PATH + type;
		switch (type)
		{
			case SHIPPATH:
				shipLoad(endPath);
			break;
			case CREWPATH:
				crewLoad(endPath);
			break;
			case WEAPONPATH:
				weaponLoad(endPath);
			break;
			case TECHPATH:
				techLoad(endPath);
			break;
			case SHIPABILITYPATH:
				shipAbilityLoad(endPath);
			break;
			case CAPTAINPATH:
				captainLoad(endPath);
			break;
			case CAPTAINUPGRADEPATH:
				captainUpgradeLoad(endPath);
			break;
			default:
				Debug.Log("DataBaseLoader kann die angegebene Datenbank nicht finden!");
			break;
		}
	}

	private ShipCollection shipLoad(string path)
	{
		ShipCollection sc = ShipCollection.Load(path);

		//nur zum testen, sonst unnötig
		foreach (ShipClass ship in sc.shipClass)
		{
			Debug.Log (ship.id);
		}
		return sc;
	}

	private CrewCollection crewLoad(string path)
	{
		return CrewCollection.Load(path);
	}

	private TechCollection techLoad(string path)
	{
		return TechCollection.Load(path);
	}

	private WeaponCollection weaponLoad(string path)
	{
		return WeaponCollection.Load(path);
	}

	private CaptainCollection captainLoad(string path)
	{
		return CaptainCollection.Load(path);
	}

	private ShipAbilityCollection shipAbilityLoad(string path)
	{
		return ShipAbilityCollection.Load(path);
	}

	private CaptainUpgradeCollection captainUpgradeLoad(string path)
	{
		return CaptainUpgradeCollection.Load(path);
	}
}
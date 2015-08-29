using UnityEngine;
using System.Collections;

/**
 * Der DataBaseLoader stellt die verschiedenen Load-Klassen für die XML-Datenbanken zur Verfügung.
 */
public class DataBaseLoader : MonoBehaviour{

	public const string PATH = "Assets\\GameData\\Data\\";
	public const string SHIPPATH = "Ships.xml";
	public const string CREWPATH = "UpgradesCrew.xml";
	public const string WEAPONPATH = "UpgradesWeapons.xml";
	public const string TECHPATH = "UpgradesTech.xml";
	public const string SHIPABILITYPATH = "ShipAbilities.xml";
	public const string CAPTAINPATH = "Captains.xml";
	public const string CAPTAINUPGRADEPATH = "CaptainUpgrades.xml";
	public const string MOVEMENTPATH = "MovementPatterns.xml";


	/*void Start ()
	{
		//gibt ne Warning, muss korrigiert werden!
		new DataBaseLoader(MOVEMENTPATH);
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
			case MOVEMENTPATH:
				movementLoad(endPath);
			break;
			default:
				Debug.Log("DataBaseLoader kann die angegebene Datenbank nicht finden!");
			break;
		}
	}*/

	/**
	 * Gibt alle Schiffe als ShipCollection zurück
	 * 
	 */
	public ShipCollection shipLoad()
	{
		return ShipCollection.Load(PATH+SHIPPATH);
	}

	/**
	 * Gibt alle Crew-Cards als CrewCollection zurück
	 * 
	 */
	public CrewCollection crewLoad()
	{
		return CrewCollection.Load(PATH+CREWPATH);
	}

	/**
	 * Gibt alle Tech-Cards als TechCollection zurück
	 * 
	 */
	public TechCollection techLoad()
	{
		return TechCollection.Load(PATH+TECHPATH);
	}

	/**
	 * Gibt alle Weapon-Cards als WeaponCollection zurück
	 * 
	 */
	public WeaponCollection weaponLoad()
	{
		return WeaponCollection.Load(PATH+WEAPONPATH);
	}

	/**
	 * Gibt alle Captain-Cards als CaptainCollection zurück
	 * 
	 */
	public CaptainCollection captainLoad()
	{
		return CaptainCollection.Load(PATH+CAPTAINPATH);
	}

	/**
	 * Gibt alle ShipAbility-Cards als ShipAbilityCollection zurück
	 * 
	 */
	public ShipAbilityCollection shipAbilityLoad()
	{
		return ShipAbilityCollection.Load(PATH+SHIPABILITYPATH);
	}

	/**
	 * Gibt alle CaptainUpgrade-Cards als CaptainUpgradeCollection zurück
	 * 
	 */
	public CaptainUpgradeCollection captainUpgradeLoad()
	{
		return CaptainUpgradeCollection.Load(PATH+CAPTAINUPGRADEPATH);
	}

	/**
	 * Gibt ALLE MovementPattern in einer MovementCollection zurück.
	 * Die MovementCollection beinhaltet eine Liste von Pattern-ID und einen Array mit dazugehörigen Maneuvern.
	 * Durch den Zugriff auf den Maneuver-Array erhält man:
	 * - speed
	 * - difficulty
	 * - bearing
	 */
	public MovementCollection movementLoad(string path)
	{
		return MovementCollection.Load(path);
	}
}
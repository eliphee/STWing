using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class ShipClass {

	[XmlAttribute("id")]
	public int id;

	[XmlElement("shipName")]
	public string shipName;

	[XmlElement("shipClass")]
	public string shipClass;

	[XmlElement("faction")]
	public string faction;

	[XmlElement("unique")]
	public bool unique;

	[XmlElement("squadronPoints")]
	public int squadronPoints;
	
	[XmlElement("weapon")]
	public int weapon;
	
	[XmlElement("agility")]
	public int agility;
	
	[XmlElement("hull")]
	public int hull;

	[XmlElement("shields")]
	public int shields;
	
	[XmlElement("firingArc")]
	public int firingArc;
	
	[XmlElement("rearArc")]
	public int rearArc;

	//Action Bar und Upgrades fehlen

	[XmlElement("ability")]
	public string ability;

	[XmlElement("abilityID")]
	public int abilityID;
	
	[XmlElement("maneuverTemplate")]
	public int maneuverTemplate;
	
	[XmlElement("baseSize")]
	public int baseSize;
}

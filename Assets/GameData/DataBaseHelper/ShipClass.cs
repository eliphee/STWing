using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class ShipClass {

	[XmlAttribute("id")]
	public float id;

	[XmlElement("shipName")]
	public string shipName;

	[XmlElement("shipClass")]
	public string shipClass;

	[XmlElement("faction")]
	public string faction;

	[XmlElement("unique")]
	public bool unique;

	[XmlElement("squadronPoints")]
	public float squadronPoints;
	
	[XmlElement("weapon")]
	public float weapon;
	
	[XmlElement("agility")]
	public float agility;
	
	[XmlElement("hull")]
	public float hull;

	[XmlElement("shields")]
	public float shields;
	
	[XmlElement("firingArc")]
	public float firingArc;
	
	[XmlElement("rearArc")]
	public float rearArc;

	//Action Bar und Upgrades fehlen

	[XmlElement("ability")]
	public string ability;

	[XmlElement("abilityID")]
	public float abilityID;
	
	[XmlElement("maneuverTemplate")]
	public float maneuverTemplate;
	
	[XmlElement("baseSize")]
	public float baseSize;
}

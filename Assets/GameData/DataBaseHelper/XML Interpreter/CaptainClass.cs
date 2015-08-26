using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class CaptainClass {
	
	[XmlAttribute("id")]
	public float id;
	
	[XmlElement("name")]
	public string name;
	
	[XmlElement("faction")]
	public string faction;
	
	[XmlElement("unique")]
	public bool unique;
	
	[XmlElement("shipUnique")]
	public bool shipUnique;

	[XmlAttribute("skill")]
	public float skill;

	[XmlAttribute("talentSlots")]
	public float talentSlots;
	
	[XmlElement("squadronPoints")]
	public float squadronPoints;
	
	[XmlElement("restriction")]
	public string restriction;
	
	[XmlElement("restrictionPenalty")]
	public float restrictionPenalty;
}

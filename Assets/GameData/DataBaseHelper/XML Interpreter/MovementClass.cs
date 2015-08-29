using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class MovementClass {

	[XmlAttribute("id")]
	public float id;

	[XmlElement("maneuver")]
	public maneuverClass[] maneuver;
}

public class maneuverClass {

	[XmlAttribute("speed")]
	public float speed;
	
	[XmlAttribute("bearing")]
	public string bearing;
	
	[XmlAttribute("difficulty")]
	public string difficulty;
}
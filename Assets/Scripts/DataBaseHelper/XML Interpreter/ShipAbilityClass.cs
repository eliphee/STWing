using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class ShipAbilityClass {
	
	[XmlAttribute("id")]
	public float id;

	[XmlElement("costs")]
	public string costs;
	
	[XmlElement("activation")]
	public string activation;
	
	[XmlElement("phase")]
	public string phase;
	
	[XmlElement("trigger")]
	public string trigger;
	
	[XmlElement("effect")]
	public string effect;
	
	[XmlElement("text")]
	public string text;	
}
